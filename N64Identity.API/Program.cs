using N64Identity.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigurAsync();

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
