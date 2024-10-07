using EShop.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Persistence.Entities;
public class PhoneNumberEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(32)]
    public PhoneNumber Number { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserEntity User { get; set; }

}
