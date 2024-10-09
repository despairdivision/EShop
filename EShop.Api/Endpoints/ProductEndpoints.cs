using EShop.Api.Сontracts.Products;
using EShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/products", AddProduct).RequireAuthorization();
        app.MapGet("/products/{title}", GetByTitle).RequireAuthorization();

        return app;
    }

    private static async Task<IResult> AddProduct(
        [FromBody] AddProductRequest request,
        IProductService productService
        ) 
    {
        await productService.AddAsync(Product.Create(request.title,
                                                     request.description,
                                                     request.imageUrl));

        return Results.NoContent();
    }

    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        IProductService productService) 
    {
        var product = productService.GetByTitleAsync(title);

        return Results.Ok(product);
    }
}
