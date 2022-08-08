using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Insector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration,
            IUserService userService)
        {
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetStuff();
            return Ok($"Hi mdafcka {currentUser.Email}");
        }

        [HttpGet()]
        public UserLoginResponse GetStuff()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claims = identity.Claims;
                return new UserLoginResponse
                {
                    Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,        
                };
            }
            return null;
        }
    }
}