using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json");

            _configuration = configurationBuilder.Build();


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                               .RequireAuthenticatedUser()
                               .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddMvc(); // ?
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    };
                });


            ConfigureServices(builder.Services);
            ConfigureDbContext(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();          
            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
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