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
            if (movie == null)
            {
                return BadRequest("Ogiltig begäran");
            }

            var result = await _movieRepository.CreateMovie(movie);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fel vid skapandet av filmen");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var results = await _movieRepository.GetMovieList();

            if (results == null || results.Count == 0)
            {
                return NotFound("Inga filmer hittades");
            }

            return Ok(results);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var result = await _movieRepository.DeleteMovie(id);

            if (result == null)
            {
                return NotFound("Filmen kunde inte hittas");
            }

            return Ok(result);
        }
    }
}