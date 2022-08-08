using Insector.Data.Interfaces;
using Insector.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Insector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration,
            IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest login)
        {
            var user = await AuthenticateAsync(login);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [HttpGet("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return null;
        }

        private async Task<UserLoginResponse> AuthenticateAsync(UserLoginRequest login)
        {
            var currentUser = await _userService.GetByEmailAndPasswordAsync(login.Email, login.Password);
            if (currentUser != null)
            {
                var response = new UserLoginResponse
                {
                    Email = currentUser.Email,
                    Nickname = currentUser.Nickname,
                    Roles = currentUser.Roles,
                };
                return response;
            }
            return null;
        }

        private string Generate(UserLoginResponse user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Nickname),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Title));
            }

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}