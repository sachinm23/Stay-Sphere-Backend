using Microsoft.EntityFrameworkCore;
using StaySphere.Infrastructure.Data;
using StaySphere.Application.Interfaces;
using StaySphere.Application.Services;
using StaySphere.Infrastructure.Repositories;

namespace StaySphere.API.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StaySphereDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}
