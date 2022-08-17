using Insector.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Insector.Data
{
    public class InsectorDbContext : DbContext
    {
        public InsectorDbContext(DbContextOptions<InsectorDbContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var users = GetDeserializedObjects<User>(SeedingResources.Users);
            var roles = GetDeserializedObjects<Role>(SeedingResources.Roles);
            //var usersRoles = GetDeserializedObjects<UserRole>(SeedingResources.UsersRoles);

            builder.Entity<User>().HasData(users);
            builder.Entity<Role>().HasData(roles);
            //builder.Entity<UserRole>().HasData(usersRoles);
        }

        private IEnumerable<T> GetDeserializedObjects<T>(string resourceValue) where T : class
        {
            var objects = JsonConvert.DeserializeObject<List<T>>(resourceValue);
            return objects;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<ProgressType> ProgressTypes { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}