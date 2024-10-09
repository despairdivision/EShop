using EShop.Core.Abstractions.Repositories;
using EShop.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace EShop.Persistence;
public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services) 
    {
        services.AddDbContext<ApplicationContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
