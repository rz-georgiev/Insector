using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Main
{
    internal class Program
    {
        private static IConfiguration _configuration;
        private static IServiceCollection _services;
        private static string _corsOrigins = "_corsOrigins";

        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json");

            _configuration = configurationBuilder.Build();

            var builder = WebApplication.CreateBuilder(args);
            _services = builder.Services;

            ConfigureIdentity();
            ConfigureJwt();
            ConfigureServices();
            ConfigureDbContext();
            ConfigureAutoMapper();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(); 

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseAuthentication();
            app.UseCors(_corsOrigins);
            app.UseAuthorization();
            app.Run();
        }

        private static void ConfigureIdentity()
        {
            _services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                               .RequireAuthenticatedUser()
                               .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            _services.AddEndpointsApiExplorer();
            _services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void ConfigureJwt()
        {
            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    };
                });
        }

        private static void ConfigureServices()
        {
            _services.AddSingleton<IPasswordHasher, PasswordHasher>();
            _services.AddTransient<IAuthService, AuthService>();
            _services.AddTransient<IProgressTypeService, ProgressTypeService>();
            _services.AddTransient<IProjectService, ProjectService>();
            _services.AddTransient<IRoleService, RoleService>();
            _services.AddTransient<ITaskService, TaskService>();
            _services.AddTransient<ITaskTypeService, TaskTypeService>();
            _services.AddTransient<ITeamService, TeamService>();

            _services.AddCors(options =>
            {
                options.AddPolicy(name: _corsOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }

        private static void ConfigureDbContext()
        {
            var connectionString = _configuration.GetConnectionString("Insector");
            var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);

            _services.AddDbContext<InsectorDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }

        private static void ConfigureAutoMapper()
        {
            _services.AddAutoMapper(typeof(Program));
        }
    }
}