using EShop.Api.Endpoints;
using EShop.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EShop.Api;

public static class ApiExtensions
{
    public static IEndpointRouteBuilder AddMappedEndpoint(this IEndpointRouteBuilder app) 
    {
        app.MapUsersEndpoints();
        app.MapProductEndpoints();

        return app;
    }

    public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                                                .GetBytes(jwtOptions!.SecretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>  
                    {
                        context.Token = context.Request.Cookies["ckckck"];

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }

}
