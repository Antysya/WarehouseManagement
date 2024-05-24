using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WarehouseManagerClient
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILogger<IdentityAuthenticationStateProvider> _logger;
        private readonly ILocalStorageService _localStorage;

        public IdentityAuthenticationStateProvider(ILogger<IdentityAuthenticationStateProvider> logger, ILocalStorageService localStorage)
        {
            _logger = logger;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _localStorage.GetItemAsStringAsync("token");
                token = token?.Trim('"');
                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();

                    // Проверяем, что токен может быть прочитан
                    if (handler.CanReadToken(token))
                    {
                        var jsonToken = handler.ReadJwtToken(token);

                        var claims = jsonToken.Claims.Select(claim =>
                            new Claim(claim.Type, claim.Value)
                        );

                        var identity = new ClaimsIdentity(claims, "jwt");
                        var user = new ClaimsPrincipal(identity);

                        return new AuthenticationState(user);
                    }
                    else
                    {
                        _logger.LogError("Невозможно прочитать токен JWT. Формат токена некорректен.");
                    }
                }

                return new AuthenticationState(new ClaimsPrincipal());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при получении состояния аутентификации: {ex.Message}");
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }

        public void MarkUserAsAuthenticated(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                token = token?.Trim('"');
                // Проверяем, что токен может быть прочитан перед его обработкой
                if (handler.CanReadToken(token))
                {
                    var jsonToken = handler.ReadJwtToken(token);

                    var claims = jsonToken.Claims.Select(claim =>
                        new Claim(claim.Type, claim.Value)
                    );

                    var identity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(identity);

                    var authState = Task.FromResult(new AuthenticationState(user));
                    NotifyAuthenticationStateChanged(authState);
                }
                else
                {
                    _logger.LogError("Невозможно прочитать токен JWT. Формат токена некорректен.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при обработке токена: {ex.Message}");
            }
        }
        public async Task<bool> UserHasRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }

            var authenticationState = await GetAuthenticationStateAsync();
            if (authenticationState == null || !authenticationState.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var user = authenticationState.User;
            var roleIdClaim = user.FindFirst(c => c.Type == "roleId");

            if (roleIdClaim != null && roleIdClaim.Value == roleId)
            {
                return true;
            }

            return false;
        }

        public async Task<string> UserLogin()
        {
            try
            {
                // Получение состояния аутентификации
                var authenticationState = await GetAuthenticationStateAsync();

                // Проверка на аутентифицированного пользователя
                if (authenticationState.User.Identity.IsAuthenticated)
                {
                    // Получение данных о пользователе
                    var user = authenticationState.User;

                    // Проверка на наличие утверждения "login"
                    var loginClaim = user.Claims.FirstOrDefault(c => c.Type == "login");

                    // Проверка на наличие значения в утверждении
                    if (loginClaim != null && !string.IsNullOrEmpty(loginClaim.Value))
                    {
                        return loginClaim.Value;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных о пользователе: {ex.Message}");
                return null;
            }
        }
    }
}
