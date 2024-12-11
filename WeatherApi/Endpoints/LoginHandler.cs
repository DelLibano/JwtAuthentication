using Microsoft.AspNetCore.Identity.Data;
using WeatherApi.Configuration;
using WeatherApi.Services;

namespace WeatherApi.Endpoints
{
    static class LoginHandler
    {
        public static IResult Login(LoginRequest request, TokenGenerator tokenGenerator, IConfiguration configuration)
        {
            string? key = configuration.GetValue<string>(Constants.SecretKeyName);
            //Change the below test to check the credential from a DB
            if (key is not null && request.Email == "user@xyz.com" && request.Password == "password")
                return Results.Ok(tokenGenerator.GenerateToken(request.Email, request.Password, System.Text.Encoding.UTF8.GetBytes(key)));
            return Results.Unauthorized();
        }
    }
}
