using EShop.Core.Models;

public interface IProductService
{
    Task AddAsync(Product product);

    Task<Product> GetByTitleAsync(string title);
}
