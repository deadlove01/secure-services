using IdentityServer.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigServices();


var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();