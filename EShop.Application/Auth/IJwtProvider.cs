using EShop.Core.Models;

namespace EShop.Application.Auth;
public interface IJwtProvider
{
    string GenerateToken(User user);
}