using MovieApi.Models;

namespace MovieApi.MovieService
{
    public interface IMoviesInterface
    {
        Task<ServiceResponse<List<MovieModel>>> GetMovies();
        Task<ServiceResponse<MovieModel>> CreateMovie(MovieModel newMovie);
        Task<ServiceResponse<MovieModel>> GetMovieById(int id);
        Task<ServiceResponse<MovieModel>> UpdateMovie(MovieModel updatedMovie);
        Task<ServiceResponse<List<MovieModel>>> DeleteMovie(int id);
        Task<ServiceResponse<MovieModel>> SoftDelete(int id);
    }
}