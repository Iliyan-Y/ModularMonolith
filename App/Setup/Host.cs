using Serilog;

namespace ModularMono.App;

internal static class StartupHost
{
  public static void AddHost(this WebApplicationBuilder builder)
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

  public static void RunHost(this WebApplication app)
  {
    try
    {
      Log.Information("Starting API");
      app.UseSerilogRequestLogging();
      app.Run();
    }
    catch (Exception ex)
    {
      Log.Fatal(ex, " API terminated unexpectedly");
    }
    finally
    {
      Log.CloseAndFlush();
    }
  }
}