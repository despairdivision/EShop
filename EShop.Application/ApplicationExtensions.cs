using EShop.Application.Services;
using EShop.Core.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Application;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
