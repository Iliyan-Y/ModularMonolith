using Serilog;

namespace ModularMono.App.User.Api;

internal static class UserStartupHost
{
  public static void AddUserHost(this WebApplicationBuilder builder)
  {
    var logConfig = new LoggerConfiguration()
      .WriteTo.Console()
      .Enrich.WithEnvironmentName();
    if (builder.Environment.IsDevelopment())
      logConfig
        .WriteTo.Debug()
        .MinimumLevel.Debug();
    else
      logConfig
        .MinimumLevel.Information();

    Log.Logger = logConfig.CreateLogger();

    builder.Host.UseSerilog();
  }

  public static void RunUserHost(this WebApplication app)
  {
    try
    {
      Log.Information("Starting User API");
      app.UseSerilogRequestLogging();
      app.Run();
    }
    catch (Exception ex)
    {
      Log.Fatal(ex, "User API terminated unexpectedly");
    }
    finally
    {
      Log.CloseAndFlush();
    }
  }
}