using Microsoft.EntityFrameworkCore;
using Movie.API.Models;

namespace Movie.API.Data;

public class MoviesContext : DbContext
{
    public MoviesContext (DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public DbSet<MovieModel> Movies { get; set; }
}