using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StaySphere.Domain.Entities;
using System.Security.Claims;
using System.Text;

namespace StaySphere.API.Extensions;

public static class AuthExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(
                configuration.GetSection("JwtSettings"));

            var jwtSettings = configuration
                .GetSection("JwtSettings")
                .Get<JwtSettings>()
                ?? throw new Exception("JwtSettings not configured");
                
            //  Console.WriteLine($"JwtSettings configured: {jwtSettings.SecretKey}");   

        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(key),
                RoleClaimType = ClaimTypes.Role    
            };
        });

        services.AddAuthorization();
    }
}
