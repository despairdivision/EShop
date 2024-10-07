using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;
using EShop.Api.Сontracts.Users;
using Microsoft.AspNetCore.Mvc;
using EShop.Core.Abstractions.Services;

namespace EShop.Api.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        app.MapGet("test", () => Results.Text("Hello world")).RequireAuthorization();

        return app;
    }

    private static async Task<IResult> Register(
            [FromBody] RegisterUserRequest request,
            IUserService userService
        )
    {
        await userService.Register(
               request.firstName,
               request.lastName,
               request.age,
               request.emails,
               request.phones,
               request.password
            );

        return Results.NoContent();
    }

    private static async Task<IResult> Login(
            [FromBody] LoginUserRequest request,
            IUserService userService,
            HttpContext context
        )
    {
        var token = await userService.Login(request.email, request.password);

        context.Response.Cookies.Append("ckckck", token);

        return Results.Ok();
    }
}
