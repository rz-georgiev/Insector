using Insector.Data.Interfaces;
using Insector.Shared.WebAppViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest login)
        {
            var token = await _authService.LoginAsync(login);
            return token != null ? Ok(token) : BadRequest("Unsuccessful login");
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return result ? Ok("Registered") : BadRequest("Unsuccessful registration");
        }

        [HttpGet("Roles")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _authService.GetRolesAsync();
            return Ok(roles);
        }
    }
}