using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insector.Services
{
    public class UserService : IUserService
    {
        private readonly InsectorDbContext _context;

        public UserService(InsectorDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(string email, string password, string avatarUrl, string nickname, IEnumerable<Role> roles)
        {
            var newUser = new User
            {
                Email = email,
                Password = password,
                AvatarUrl = avatarUrl,
                Nickname = nickname,
                Roles = roles,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            return user;
        }
    }
}
