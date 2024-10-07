using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.DataContext;

namespace MovieApi.MovieService
{
    public class MoviesService(ApplicationDbContext context) : IMoviesInterface
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ServiceResponse<List<MovieModel>>> GetMovies()
        {
            ServiceResponse<List<MovieModel>> serviceResponse = new ServiceResponse<List<MovieModel>>();

            try
            {
                serviceResponse.Data = await _context.Movies.ToListAsync();

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum filme cadastrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<MovieModel>> CreateMovie(MovieModel newMovie)
        {
            ServiceResponse<MovieModel> serviceResponse = new ServiceResponse<MovieModel>();

            try
            {
                if (newMovie == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado inserido!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                newMovie.Created_at = DateTime.Now.ToLocalTime();
                newMovie.Updated_at = DateTime.Now.ToLocalTime();

                _context.Add(newMovie);
                await _context.SaveChangesAsync();

                serviceResponse.Message = "Novo filme adicionado";
                serviceResponse.Data = newMovie;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MovieModel>> GetMovieById(int id)
        {
            ServiceResponse<MovieModel> serviceResponse = new ServiceResponse<MovieModel>();

            try
            {
                MovieModel movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
                if (movie == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum filme encontrado";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                serviceResponse.Data = movie;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<MovieModel>> SoftDelete(int id)
        {
            ServiceResponse<MovieModel> serviceResponse = new ServiceResponse<MovieModel>();

            try
            {
                MovieModel movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
                if (movie == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum filme encontrado";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                
                movie.Active = false;
                movie.Updated_at = DateTime.Now.ToLocalTime();
                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();

                serviceResponse.Data = null;
                serviceResponse.Message = "Movie deleted successfully";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<MovieModel>> UpdateMovie(MovieModel updatedMovie)
        {
            ServiceResponse<MovieModel> serviceResponse = new ServiceResponse<MovieModel>();
            try
            {
                MovieModel movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == updatedMovie.Id);
                if (movie == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum filme encontrado";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                movie.Updated_at = DateTime.Now.ToLocalTime();
                _context.Movies.Update(updatedMovie);
                await _context.SaveChangesAsync();

                serviceResponse.Data = updatedMovie;



            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MovieModel>>> DeleteMovie(int id)
        {
            ServiceResponse<List<MovieModel>> serviceResponse = new ServiceResponse<List<MovieModel>>();

            try
            {
                MovieModel funcionario = _context.Movies.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }


                _context.Movies.Remove(funcionario);
                await _context.SaveChangesAsync();


                serviceResponse.Data = _context.Movies.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}