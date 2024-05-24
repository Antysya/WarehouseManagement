using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataModel.Contracts;
using Server.Repositories;
using Server.Repositories.Interfaces;
using Server.Service;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                await _userService.Register(request.Login, request.Password, request.Role);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при регистрации пользователя: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest request)
        {
            try
            {
                var token = await _userService.Login(request.Login, request.Password);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Неверные учетные данные");
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при входе пользователя: {ex.Message}");
            }
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Users>> GetUsers(CancellationToken cancellationToken)
        {
            return await _userService.GetAll(cancellationToken);
        }

        [HttpGet("update")]
        public async Task UpdateUser(Users user, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(user, cancellationToken);
        }


    }
}
