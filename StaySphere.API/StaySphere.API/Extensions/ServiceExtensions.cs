using Microsoft.EntityFrameworkCore;
using StaySphere.Infrastructure.Data;
using StaySphere.Application.Interfaces;
using StaySphere.Application.Services;
using StaySphere.Infrastructure.Repositories;
using StaySphere.Application.Interfaces.PropertyInterfaces;
using StaySphere.Infrastructure.Services;


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
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IAwsService, AwsService>();
    }
}
