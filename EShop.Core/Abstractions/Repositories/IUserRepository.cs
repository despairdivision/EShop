using EShop.Core.Models;

namespace EShop.Core.Abstractions.Repositories;
public interface IUserRepository
{
    Task Add(User user);

    Task<User> GetByEmail(EmailAdress email);
}
