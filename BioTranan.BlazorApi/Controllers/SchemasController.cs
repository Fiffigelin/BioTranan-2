using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using BioTranan.Core.ViewModels;

namespace BioTranan.BlazorApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchemasController : ControllerBase
{
    private readonly IMovieDetailsRepository _schemasRepository;

    public SchemasController(IMovieDetailsRepository webRepository)
    {
        _schemasRepository = webRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowDetailsDto>>> GetSchema()
    {
        try
        {
            var movies = await _schemasRepository.GetMovies();
            var salons = await _schemasRepository.GetSalons();
            var shows = await _schemasRepository.GetShows();
            var bookings = await _schemasRepository.GetBookings();

            if (movies == null || salons == null || shows == null)
            {
                return NotFound();
            }

            var schemas = shows.ConvertToDto(movies, salons, bookings).OrderBy(s => s.ShowStartTime);
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
            var show = await _schemasRepository.GetShow(id);
            var movie = await _schemasRepository.GetMovie(show?.MovieId ?? -1);
            var salon = await _schemasRepository.GetSalon(show?.SalonId ?? -1);
            var bookings = await _schemasRepository.GetBookings(show?.Id ?? -1);

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