using EShop.Core.Abstractions.Repositories;
using EShop.Core.Models;

namespace EShop.Application.Services;
public class ProductService(IProductRepository productReposiory) : IProductService
{
    public async Task AddAsync(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Product cannot be null");

        await productReposiory.Add(product);
    }

    public async Task<Product> GetByTitleAsync(string title)
    {
        var product = await productReposiory.Get(title);

        return product;
    }
}
