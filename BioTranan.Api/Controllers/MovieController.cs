using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Api.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _movieRepository;

        public MovieController(ILogger<MovieController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie([FromBody] CreateMovieDto movie)
        {
            var result = await this._movieRepository.CreateMovie(movie);

            if (movie == null) return NoContent();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var results = await this._movieRepository.GetMovieList();

            if (results == null) return NotFound();

            return Ok(results);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var result = await this._movieRepository.DeleteMovie(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}