using Microsoft.EntityFrameworkCore;
using MovieClient.Data;
using MovieClient.Models;
using Newtonsoft.Json;

namespace MovieClient.ApiServices;

public class MovieApiService : IMovieApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly MovieClientContext _movieClientContext;

    public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, 
        MovieClientContext movieClientContext)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
        _movieClientContext = movieClientContext;
    }
    
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _movieClientContext.Movies.ToListAsync();
        
        var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            "/movies");

        var response = await httpClient.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
        return movieList;

    }

    public Task<Movie> GetMovie(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> CreateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserInfoViewModel> GetUserInfo()
    {
        throw new NotImplementedException();
    }
}