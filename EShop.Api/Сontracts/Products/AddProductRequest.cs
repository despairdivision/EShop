using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Сontracts.Products;

public record AddProductRequest([Required] string title,
                                [Required] string description,
                                [Required] string imageUrl);

