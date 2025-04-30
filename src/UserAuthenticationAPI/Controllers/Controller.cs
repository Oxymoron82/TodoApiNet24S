using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        // Внедрение зависимостей через конструктор
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userService.Register(user.Username, user.Password);
            if (result)
            {
                return Ok("Пользователь зарегистрирован.");
            }
            else
            {
                return BadRequest("Пользователь с таким именем уже существует.");
            }
        }

        // POST api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var result = _userService.Authenticate(user.Username, user.Password);
            if (result)
            {
                return Ok("Авторизация успешна.");
            }
            else
            {
                return Unauthorized("Неверные имя пользователя или пароль.");
            }
        }
    }
}
