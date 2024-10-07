using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace EShop.Core.Models;

public class EmailAdress : ValueObject
{
    private const string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public string Adress { get; }

    private EmailAdress(string adress)
    {
        Adress = adress;
    }

    public static EmailAdress Create(string input) 
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "Email adress cannot be null or empty");
        if (!Regex.IsMatch(input, emailRegex))
            throw new ArgumentException(nameof(input), "Email adress is invalid");

        return new EmailAdress(input);

    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Adress;
    }
}
