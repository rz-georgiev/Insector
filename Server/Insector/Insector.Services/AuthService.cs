using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Insector.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly InsectorDbContext _context;

        public AuthService(IConfiguration configuration,
             IPasswordHasher passwordHasher,
             IMapper mapper,
             InsectorDbContext dbContext)
        {
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<string> LoginAsync(UserLoginRequest request)
        {
            var user = await _context.Users
                //.Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == request.Email
                                     && x.IsActive
                                     && x.IsEmailConfirmed);
            if (user == null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user.PasswordHash, request.Password);
            var isPasswordValid = result == PasswordVerificationResult.Success
                || result == PasswordVerificationResult.SuccessRehashNeeded;

            return isPasswordValid ? GenerateToken(user) : null;
        }

        public async Task<bool> RegisterAsync(UserRegisterRequest request)
        {
            var newUser = new User
            {
                Email = request.Email,
                Nickname = request.Nickname,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                AvatarUrl = request.AvatarUrl,
                IsActive = true,
                IsEmailConfirmed = false,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            //var userRoles = request.RolesIds.Select(x => new UserRole
            //{
            //    UserId = newUser.Id,
            //    RoleId = x.Id,
            //});

            //await _context.UserRoles.AddRangeAsync(userRoles);
            await _context.SaveChangesAsync();

            return newUser.Id != 0;
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            var models = _mapper.Map<IEnumerable<RoleResponse>>(roles);
            return models;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Nickname)
            };

            //foreach (var role in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Title));
            //}

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}