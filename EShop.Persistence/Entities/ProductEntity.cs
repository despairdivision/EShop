using System.ComponentModel.DataAnnotations;

namespace EShop.Persistence.Entities;
public class ProductEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public string ImageUrl { get; set; }
}
