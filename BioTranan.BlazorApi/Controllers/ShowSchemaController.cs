using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
using BioTranan.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using BioTranan.Core.ViewModels;

namespace BioTranan.BlazorApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShowSchemaController : ControllerBase
{
    private readonly IMovieDetailsRepository _webRepository;

    public ShowSchemaController(IMovieDetailsRepository webRepository)
    {
        _webRepository = webRepository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<ShowDetailsDto>>> GetMovieDetails(int id)
    {
        try
        {
            var show = await _webRepository.GetShow(id);
            var movie = await _webRepository.GetMovie(show.MovieId);
            var salon = await _webRepository.GetSalon(show.SalonId);
            var bookings = await _webRepository.GetBookings(show.Id);

            if (movie == null || salon == null || show == null)
            {
                return NotFound();
            }

            var movieDetailsDto = show.ConvertToDto(movie, salon, bookings);
            return Ok(movieDetailsDto);
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel när data försökte hämtas från databasen");
        }
    }

}