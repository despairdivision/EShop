using EShop.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Сontracts.Users;

public record RegisterUserRequest([Required] string firstName,
                                  [Required] string lastName,
                                  [Required] int age,
                                  [Required] string email,
                                  [Required] string password,
                                  List<string> phones = null);

