using Insector.Data;
using Microsoft.EntityFrameworkCore;

namespace Main
{
    internal class Program
    {
        private static IConfiguration _configuration;

        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json");

            _configuration = configurationBuilder.Build();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfigureServices(builder.Services);
            ConfigureDbContext(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("Insector");
            var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);

            services.AddDbContext<InsectorDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }
    }
}