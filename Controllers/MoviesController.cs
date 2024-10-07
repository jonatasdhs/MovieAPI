using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.MovieService;

namespace MovieApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInterface _moviesInterface;
        public MoviesController(IMoviesInterface moviesInterface)
        {
            _moviesInterface = moviesInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MovieModel>>>> GetMovies()
        {
            return Ok(await _moviesInterface.GetMovies());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<MovieModel>>> CreateMovie(MovieModel newMovie)
        {
            return Ok(await _moviesInterface.CreateMovie(newMovie));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MovieModel>>> GetMovieById(int id)
        {
            return Ok(await _moviesInterface.GetMovieById(id));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<MovieModel>>> UpdateMovie(MovieModel updatedMovie)
        {
            return Ok(await _moviesInterface.UpdateMovie(updatedMovie));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<MovieModel>>>> DeleteMovie(int id)
        {
            return Ok(await _moviesInterface.DeleteMovie(id));
        }
        [HttpPut("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<MovieModel>>> SoftDelete(int id)
        {
            return Ok(await _moviesInterface.SoftDelete(id));
        }
    }
}