using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EShop.Core.Models;
public class User
{

    private User(string firstName,
                 string lastName,
                 int age,
                 string passwordHash,
                 List<EmailAdress> emailAdresses,
                 List<PhoneNumber> phoneNumbers)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        PasswordHash = passwordHash;
        EmailAdresses = emailAdresses;
        PhoneNumbers = phoneNumbers;
    }
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public int Age { get; set; }

    public string PasswordHash { get; set; }

    public ICollection<EmailAdress> EmailAdresses { get; set; }

    public ICollection<PhoneNumber> PhoneNumbers { get; set; }

    public static User Create(string firstName,
                 string lastName,
                 int age,
                 string passwordHash,
                 List<EmailAdress> emailAdresses,
                 List<PhoneNumber> phoneNumbers)
    {
        return new User(firstName, lastName, age, passwordHash, emailAdresses, phoneNumbers);
    }
}
