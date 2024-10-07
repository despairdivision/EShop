using EShop.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Сontracts.Users;

public record RegisterUserRequest([Required] string firstName,
                                  [Required] string lastName,
                                  [Required] int age,
                                  [Required] List<string> emails,
                                  [Required] List<string> phones,
                                  [Required] string password);

