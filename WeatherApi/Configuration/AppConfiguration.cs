﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WeatherApi.Services;

namespace WeatherApi.Configuration
{
    static class AppConfiguration
    {
        public static void AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenApi();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetValue<string>(nameof(Constants.SecretKeyName), string.Empty))),
                        ValidIssuer = Constants.JwtIssuerAndAudience,
                        ValidAudience = Constants.JwtIssuerAndAudience,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                });
        }

        public static void AddJWTServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenGenerator>();
        }

    }
}
