using AutoMapper;
using EShop.Core.Abstractions.Repositories;
using EShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories;
public class ProductRepository(ApplicationContext context, IMapper mapper) : IProductRepository
{
    public async Task Add(Product product)
    {
        var productEntity = mapper.Map<Product>(product);

        await context.AddAsync(productEntity);

        await context.SaveChangesAsync(); 
    }

    public async Task<Product> Get(string title)
    {
        var productEntity = await context.Products.FirstOrDefaultAsync(p => p.Title
                                                  .Contains(title, StringComparison.OrdinalIgnoreCase));

        if (productEntity == null)
            throw new ArgumentNullException(nameof(productEntity), "Invalid product id");

        var product = mapper.Map<Product>(productEntity);

        return product;
    }
}
