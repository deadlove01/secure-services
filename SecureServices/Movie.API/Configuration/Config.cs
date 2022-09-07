using Microsoft.EntityFrameworkCore;
using Movie.API.Data;

namespace Movie.API.Configuration;

public static class Config
{
    public static void SeedDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var moviesContext = services.GetRequiredService<MoviesContext>();
            MoviesContextSeed.SeedAsync(moviesContext);
        }
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<MoviesContext>(opt => opt.UseInMemoryDatabase("Movies"));
    }
}