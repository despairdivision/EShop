using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace EShop.Core.Models;
public class PhoneNumber : ValueObject
{
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    public string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static PhoneNumber Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input), "Phone number cannot be null or empty");

        if (Regex.IsMatch(input, phoneRegex) == false)
            throw new ArgumentException(nameof(input), "Ivalid phone number");

        return new PhoneNumber(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}
