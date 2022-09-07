﻿using Movie.API.Models;

namespace Movie.API.Data;


public class MoviesContextSeed
{
    public static void SeedAsync(MoviesContext moviesContext)
    {
        if (!moviesContext.Movies.Any())
        {
            var movies = new List<MovieModel>
            {
                new MovieModel
                {
                    Id = 1,
                    Genre = "Drama",
                    Title = "The Shawshank Redemption",
                    Rating = "9.3",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1994, 5, 5),
                    Owner = "alice"
                },
                new MovieModel
                {
                    Id = 2,
                    Genre = "Crime",
                    Title = "The Godfather",
                    Rating = "9.2",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1972, 5, 5),
                    Owner = "alice"
                },
                new MovieModel
                {
                    Id = 3,
                    Genre = "Action",
                    Title = "The Dark Knight",
                    Rating = "9.1",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(2008, 5, 5),
                    Owner = "bob"
                },
                new MovieModel
                {
                    Id = 4,
                    Genre = "Crime",
                    Title = "12 Angry Men",
                    Rating = "8.9",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1957, 5, 5),
                    Owner = "bob"
                },
                new MovieModel
                {
                    Id = 5,
                    Genre = "Biography",
                    Title = "Schindler's List",
                    Rating = "8.9",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1993, 5, 5),
                    Owner = "alice"
                },
                new MovieModel
                {
                    Id = 6,
                    Genre = "Drama",
                    Title = "Pulp Fiction",
                    Rating = "8.9",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1994, 5, 5),
                    Owner = "alice"
                },
                new MovieModel
                {
                    Id = 7,
                    Genre = "Drama",
                    Title = "Fight Club",
                    Rating = "8.8",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1999, 5, 5),
                    Owner = "bob"
                },
                new MovieModel
                {
                    Id = 8,
                    Genre = "Romance",
                    Title = "Forrest Gump",
                    Rating = "8.8",
                    ImageUrl = "images/src",
                    ReleaseDate = new DateTime(1994, 5, 5),
                    Owner = "bob"
                }
            };
            moviesContext.Movies.AddRange(movies);
            moviesContext.SaveChanges();
        }
    }
}