using Microsoft.AspNetCore.Mvc;
using UserAuthentAppi.Models;
using UserAuthentAppi.Services;

namespace UserAuthentAppi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Регистрация нового пользователя
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Имя пользователя и пароль обязательны.");

            bool result = _userService.Register(user.Username, user.Password);
            return result ? Ok("Пользователь зарегистрирован.") : BadRequest("Пользователь уже существует.");
        }

        // Авторизация пользователя
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Имя пользователя и пароль обязательны.");

            bool result = _userService.Authenticate(user.Username, user.Password);
            return result ? Ok("Авторизация успешна.") : Unauthorized("Неверное имя пользователя или пароль.");
        }
    }
}
