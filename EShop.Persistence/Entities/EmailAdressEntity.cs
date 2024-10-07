using EShop.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Persistence.Entities;
public class EmailAdressEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public EmailAdress Adress { get; set; }

    [Required]
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]    
    public virtual UserEntity User { get; set; }
}
