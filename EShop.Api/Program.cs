using EShop.Api;
using EShop.Infrastructure;
using EShop.Infrastructure.Auth;
using EShop.Persistence;
using EShop.Application;
using Eshop.Persistence.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence().
                 AddInfrastructure().
                 AddApplication();

builder.Services.AddAutoMapper(options => {
    options.AddProfile<DataBaseMappings>();
},typeof(Program).Assembly);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddApiAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddMappedEndpoint();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();