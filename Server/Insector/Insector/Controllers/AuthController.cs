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
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration,
            IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest login)
        {
            var token = await _authService.LoginAsync(login);
            return token != null ? Ok(token) : NotFound("User not found");
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return result ? Ok("Registered") : NotFound("Not registered");
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