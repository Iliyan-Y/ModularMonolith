using System.Reflection;
using Serilog;

namespace ModularMono.App.User.Api;

internal static class ApiExplorer
{

  public static void AddUserApiExplorer(this WebApplicationBuilder builder)
  {
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
      options.SupportNonNullableReferenceTypes();
      var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
      if
      (File.Exists(xmlPath)) options.IncludeXmlComments(xmlPath);
      else
        Log.Logger.Warning("Unable to find swagger xml file at {xnlPath}", xmlPath);
    });
  }

  public static void UseUserApiExplorer(this WebApplication app)
  {
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
  }
}