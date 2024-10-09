using EShop.Core.Abstractions.Services;
using EShop.Application.Auth;
using EShop.Core.Models;
using EShop.Core.Abstractions.Repositories;

namespace EShop.Application.Services;

public class UserService(IPasswordHasher passwordHasher,
                         IUserRepository userRepository,
                         IJwtProvider jwtProvider) : IUserService
{
    public async Task Register(string firstName,
                         string lastName,
                         int age,
                         string email,
                         List<string> phones,
                         string password)
    {
        var hashedPassword = passwordHasher.Generate(password);

        var emailAdress = EmailAdress.Create(email);
        var phoneNumbers = phones?.Select(PhoneNumber.Create).ToList();

        var user = User.Create(
                firstName,
                lastName,
                age,
                hashedPassword,
                new List<EmailAdress> { emailAdress },
                phoneNumbers
            );

        await userRepository.Add(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var emailAdress = EmailAdress.Create(email);

        var user = await userRepository.GetByEmail(emailAdress);

        var result = passwordHasher.Verify(password, user.PasswordHash);

        if (result == false)
            throw new ArgumentException(nameof(email), "Failed to login");

        var token = jwtProvider.GenerateToken(user);

        return token;
    }

}
