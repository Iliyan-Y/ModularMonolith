namespace ModularMono.App.User.Api;

public class UserApi
{

  private readonly WebApplication app;

  public UserApi(WebApplicationBuilder builder)
  {
    builder.AddUserBackend();
    builder.AddUserHost();
    builder.AddUserApiExplorer();

    app = builder.Build();
    app.UseUserBackend();
    app.UseUserApiExplorer();

    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", () =>
    {
      var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
      return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();
  }

  public void RunUserHost() => app.RunUserHost();
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
