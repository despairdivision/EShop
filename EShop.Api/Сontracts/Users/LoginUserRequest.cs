namespace EShop.Api.Сontracts.Users;

public record LoginUserRequest(
        string email,
        string password
    );

