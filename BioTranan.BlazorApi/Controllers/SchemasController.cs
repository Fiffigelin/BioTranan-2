using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
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
        { // Gus! I have seen this in a tutorial! How can I minimize my try block?
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
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel när data försökte hämtas från databasen");
        }
    }
}