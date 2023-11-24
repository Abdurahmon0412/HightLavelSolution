using BackroundServices.BackroundServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BackroundServiceIHostService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

