using ModularMono.App.User.Api;

var builder = WebApplication.CreateBuilder(args);

var userModule = new UserApi(builder);

userModule.RunUserHost();
