using System.ComponentModel.DataAnnotations;

namespace EShop.Persistence.Entities;

public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(35)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(35)]
    public string LastName { get; set; }

    [Required]
    [Range(14, 120)]
    public int Age { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public virtual ICollection<EmailAddressEntity> EmailAdresses { get; set; } = new List<EmailAddressEntity>();

    public virtual ICollection<PhoneNumberEntity>? PhoneNumbers { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; } = [];
}

