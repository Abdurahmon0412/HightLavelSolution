namespace N64Identity.API.Configuration;

public static partial  class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigurAsync(this WebApplicationBuilder builder)
    {
        builder.AddIdentityInfrastructure().AddDevTools().AddExposers();
        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseIdentityInfrastructure().UseDevTools().UseExposers();

        return new(app);
    }
}