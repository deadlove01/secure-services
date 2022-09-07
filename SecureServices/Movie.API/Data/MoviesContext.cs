using Microsoft.EntityFrameworkCore;

namespace Movie.API.Data;

public class MoviesContext : DbContext
{
    public MoviesContext (DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Movie> Movie { get; set; }
}