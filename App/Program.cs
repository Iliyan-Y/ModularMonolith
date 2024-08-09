using ModularMono.App;
using ModularMono.App.Books.Api;
using ModularMono.App.User.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiExplorer();
builder.AddHost();
builder.AddUserBackend();
builder.AddBooksBackend();

var app = builder.Build();

app.UseUserBackend();
app.UseBooksBackend();
app.UseApiExplorer();

app.RunHost();


