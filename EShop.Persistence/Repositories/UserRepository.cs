using AutoMapper;
using EShop.Core.Abstractions.Repositories;
using EShop.Core.Models;
using EShop.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories;

public class UserRepository(ApplicationContext context, IMapper mapper) : IUserRepository
{
    public async Task Add(User user)
    {
        var userEntity = mapper.Map<UserEntity>(user);
        await context.Users.AddAsync(userEntity);

        await context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(EmailAdress email)
    {
        var userEntity = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(
                u => u.EmailAdresses.Any(a => a.Address == email)
                );

        if (userEntity == null)
            throw new ArgumentNullException(nameof(userEntity), "User not found");

        var user = mapper.Map<User>(userEntity);

        return user;
    }
}
