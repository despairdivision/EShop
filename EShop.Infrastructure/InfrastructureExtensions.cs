using EShop.Application.Auth;
using EShop.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Infrastructure;
public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
