using Blazored.LocalStorage;
using DataModel.Contracts;
using HttpApiClient;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WarehouseManagerClient
{
    public class AuthorizeApi
    {
        private readonly ILogger<AuthorizeApi> _logger;
        private readonly ILocalStorageService _localStorage;
        private IdentityAuthenticationStateProvider _authenticationStateProvider;
        private readonly WarehouseApiClient _warehouseApiClient;
        public AuthorizeApi(ILogger<AuthorizeApi> logger, 
                            AuthenticationStateProvider authenticationStateProvider, 
                            ILocalStorageService localStorage, 
                            WarehouseApiClient warehouseApiClient)
        {
            _logger = logger;
            _localStorage = localStorage;
            _authenticationStateProvider = (IdentityAuthenticationStateProvider)authenticationStateProvider;
            _warehouseApiClient = warehouseApiClient;
        }

        public async Task<bool> Login(string login, string password)
        {
            var request = new LoginUserRequest(login, password);

            //отправить запрос на сервер
            try
            {
                // Отправляем запрос на сервер для аутентификации
                var token = await _warehouseApiClient.Authenticate(request);

                // Проверяем полученный токен
                if (!string.IsNullOrEmpty(token))
                {
                    // Сохраняем токен в локальное хранилище
                    await _localStorage.SetItemAsync("token", token);

                    // Помечаем пользователя как аутентифицированного
                    _authenticationStateProvider.MarkUserAsAuthenticated(token);

                    // Возвращаем true, чтобы показать успешную аутентификацию
                    return true;
                }
                else
                {
                    // Если токен не получен, возвращаем false
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при аутентификации: {ex.Message}");
                return false;
            }
        }

        public async Task Register(string login, string password, int role)
        {
            var request = new RegisterUserRequest(login, password, role);

            //отправить запрос на сервер
            try
            {
                // Отправляем запрос на сервер для регистрации
                await _warehouseApiClient.Register(request);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при регистрации: {ex.Message}");
            }
        }
    }
}
