using IdentityApi;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddSingleton<TokenGenerator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/login", (LoginRequest request, TokenGenerator tokenGenerator) =>
{
    return new
    {
        access_token = tokenGenerator.GenerateToken(request.Email, request.Password,
            builder.Configuration.GetValue<string>("ValidIssuer", string.Empty),
            builder.Configuration.GetValue<string>("ValidAudience", string.Empty),
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>(nameof(SymmetricSecurityKey), string.Empty)))
    };
});

app.Run();
