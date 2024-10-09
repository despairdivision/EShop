using EShop.Core.Models;

namespace EShop.Core.Abstractions.Services;
public interface IUserService
{
    Task<string> Login(string email, string password);

    Task Register(string firstName, 
                  string lastName, 
                  int age, 
                  string emails, 
                  List<string> phones, 
                  string password);
}
