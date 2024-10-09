using EShop.Core.Models;

namespace EShop.Core.Abstractions.Repositories;
public interface IProductRepository
{
    Task Add(Product product);

    Task<Product> Get(string title);
}
