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
        PhoneNumbers = phoneNumbers ?? new List<PhoneNumber>();
    }
    public Guid Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public int Age { get; }

    public string PasswordHash { get; }

    public ICollection<EmailAdress> EmailAdresses { get; }

    public ICollection<PhoneNumber> PhoneNumbers { get; } = new List<PhoneNumber>();

    public static User Create(string firstName,
                 string lastName,
                 int age,
                 string passwordHash,
                 List<EmailAdress> emailAdresses,
                 List<PhoneNumber> phoneNumbers = null)
    {
        return new User(firstName, lastName, age, passwordHash, emailAdresses, phoneNumbers);
    }
}
