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
}