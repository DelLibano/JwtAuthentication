using WeatherApi;
using WeatherApi.Configuration;
using WeatherApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices(builder.Configuration);
builder.Services.AddJWTServices();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", LoginHandler.Login).WithName(UriHelper.Login);
app.MapGet("/weather", WeatherHandler.Get).RequireAuthorization().WithName(UriHelper.Weather);

app.Run();
