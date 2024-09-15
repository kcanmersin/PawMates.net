using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Core.Service.JWT;
using MediatR;
using System.Reflection;
using FluentValidation;
using Hangfire;
using Quartz;
using Hangfire.PostgreSql;
using Core.Service.Email;
using Core.Middlewares.ExceptionHandling;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using HealthChecks.Hangfire;
using Core.Features;
using Core.Data.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using RabbitMQ.Client;
using HealthChecks.Kafka;
using Pawmates.Core.Data;

namespace Core.Extensions
{
    public static class CoreLayerExtensions
    {
        public static IServiceCollection LoadCoreLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
            })
            .AddRoleManager<RoleManager<AppRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        


            services.AddScoped<IEmailService, EmailService>();

            var defaultConnectionString = Environment.GetEnvironmentVariable("PAWMATES_ConnectionStrings__DefaultConnection") ?? configuration["PAWMATES_ConnectionStrings__DefaultConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(defaultConnectionString));

            var jwtSettings = new JwtSettings
            {
                Secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? configuration["JwtSettings:Secret"],
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["JwtSettings:Issuer"],
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["JwtSettings:Audience"],
                ExpiryMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRYMINUTES"), out var expiryMinutes)
                                ? expiryMinutes
                                : int.Parse(configuration["JwtSettings:ExpiryMinutes"])
            };
            services.AddSingleton(jwtSettings);

            services.AddScoped<IJwtService, JwtService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IApplicationBuilder UseCoreLayerRecurringJobs(this IApplicationBuilder app)
        {



            return app;
        }
    }
}
