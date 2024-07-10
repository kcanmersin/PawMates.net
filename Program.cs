using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.SwaggerGen;
using AutoMapper;
using PawMates.net.Models;
using PawMates.net.Interfaces;
using PawMates.net.Repository;
using PawMates.net.Service;
using api.Service;
using api.Interfaces;
using PawMates.net;
using PawMates.Data;

var builder = WebApplication.CreateBuilder(args);

// Basic MVC and API Services
ConfigureBasicServices(builder.Services);

// Swagger and API Documentation
ConfigureSwaggerServices(builder.Services);

// Entity Framework and Identity Configuration
ConfigureEntityFrameworkServices(builder.Services, builder.Configuration);

// Authentication and Authorization
ConfigureAuthenticationServices(builder.Services, builder.Configuration);

// Application Services
ConfigureApplicationServices(builder.Services);

// AutoMapper Configuration
ConfigureAutoMapper(builder.Services);

var app = builder.Build();

// Application Middleware Configuration
ConfigureMiddleware(app);

app.Run();

void ConfigureBasicServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
     services.AddSignalR();
    services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
}

void ConfigureSwaggerServices(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "PawMates API", Version = "v1" });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });

        options.OperationFilter<SwaggerFileUploadOperationFilter>();
    });
}

void ConfigureEntityFrameworkServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    services.AddIdentity<AppUser, IdentityRole>(opts =>
    {
        opts.Password.RequireDigit = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequiredLength = 4;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
}

void ConfigureAuthenticationServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
            )
        };
    });
}

void ConfigureApplicationServices(IServiceCollection services)
{
    services.AddScoped<IPetRepository, PetRepository>();
    services.AddScoped<IAdRepository, AdRepository>();
    services.AddScoped<IJobAdRepository, JobAdRepository>();
    services.AddScoped<ILostAdRepository, LostAdRepository>();
    services.AddScoped<IAdoptionAdRepository, AdoptionAdRepository>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IImageStorageService, LocalImageStorageService>();
}

void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(ApplicationMappingProfile));
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "PawMates API V1");
        });
    }

    app.UseHttpsRedirection();
    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.UseStaticFiles();
    app.MapHub<NotificationHub>("/notifications");  // Map the SignalR Hub to a path
}
