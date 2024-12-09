using Microsoft.AspNetCore.Identity.Data;
using WeatherApi.Services;

namespace WeatherApi.Endpoints
{
    static class LoginHandler
    {
        public static string Login(LoginRequest request, TokenGenerator tokenGenerator, IConfiguration configuration)
        {
            string issuer = configuration.GetValue<string>("ValidIssuer", string.Empty);
            string audience = configuration.GetValue<string>("ValidAudience", string.Empty);
            string key = configuration.GetValue<string>("SymmetricSecurityKey", string.Empty);
            return tokenGenerator.GenerateToken(request.Email, request.Password, issuer, audience, System.Text.Encoding.UTF8.GetBytes(key));
        }
    }
}
