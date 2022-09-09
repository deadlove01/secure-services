using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Config;

public static class ConfigDI
{
    public static IServiceCollection ConfigServices(this IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddTestUsers(Config.TestUsers)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddDeveloperSigningCredential()
            ;

        return services;
    }
}