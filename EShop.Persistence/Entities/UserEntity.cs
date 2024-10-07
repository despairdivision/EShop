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
    public ICollection<EmailAdressEntity> EmailAdresses { get; set; }

    [Required]
    public ICollection<PhoneNumberEntity> PhoneNumbers { get; set; }
}

