using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using BioTranan.Core.ViewModels;

namespace BioTranan.BlazorApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchemasController : ControllerBase
{
    private readonly IMovieDetailsRepository _webRepository;

    public SchemasController(IMovieDetailsRepository webRepository)
    {
        _webRepository = webRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowDetailsDto>>> GetSchema()
    {
        try
        {
            var movies = await _webRepository.GetMovies();
            var salons = await _webRepository.GetSalons();
            var shows = await _webRepository.GetShows();
            var bookings = await _webRepository.GetBookings();

            if (movies == null || salons == null || shows == null)
            {
                return NotFound();
            }

            var schemas = shows.ConvertToDto(movies, salons, bookings);
            return Ok(schemas);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel när data försökte hämtas från databasen");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<ShowDetailsDto>>> GetMovieDetails(int id)
    {
        try
        {
            var show = await _webRepository.GetShow(id);
            var movie = await _webRepository.GetMovie(show?.MovieId ?? -1);
            var salon = await _webRepository.GetSalon(show?.SalonId ?? -1);
            var bookings = await _webRepository.GetBookings(show?.Id ?? -1);

            if (movie == null || salon == null || show == null)
            {
                return NotFound();
            }

            var movieDetailsDto = show.ConvertToDto(movie, salon, bookings);
            return Ok(movieDetailsDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel när data försökte hämtas från databasen");
        }
    }
}