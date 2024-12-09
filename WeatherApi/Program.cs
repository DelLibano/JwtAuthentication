using WeatherApi;
using WeatherApi.Configuration;
using WeatherApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/weather", RootHandlers.Get).RequireAuthorization().WithName(UriHelper.Weather).WithOpenApi();

app.Run();
