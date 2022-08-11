using Insector.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Insector.Data
{
    public class InsectorDbContext : DbContext
    {
        public InsectorDbContext(DbContextOptions<InsectorDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}