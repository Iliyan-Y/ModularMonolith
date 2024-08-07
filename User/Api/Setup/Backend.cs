// using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ModularMono.App.User.Api;

internal static class SetupBackend
{
  public static void AddUserBackend(this WebApplicationBuilder builder)
  {

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

    // builder.Services.AddDomain();

    // var sqlConnection = builder.Configuration.GetSqlConnection();
    // builder.Services.AddDatabase(options => options.UseSqlServer(sqlConnection));
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    // builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Domain).Assembly);
  }

  private static string GetSqlConnection(this IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    var apiPath = Directory.GetCurrentDirectory();
    var rootPath = Directory.GetParent(apiPath)?.ToString();
    var dbPath = Path.Combine(rootPath!, "LocalDb");

    if (!string.IsNullOrWhiteSpace(connectionString))
      return connectionString.Replace("{DataDirectory}", dbPath);

    const string error = "SQL Connection String has not been configured";
    Log.Logger.Fatal(error);
    throw new InvalidOperationException(error);
  }

  public static void UseUserBackend(this WebApplication app)
  {
    app.MapControllers();
  }
}