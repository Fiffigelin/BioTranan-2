using BioTranan.Core.Dto;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.BlazorApi.Controllers;

[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;

    public BookingController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking([FromBody] CreateBookingDto createBookingDto)
    {
        try
        {
            var isSeatAvailable = await this._bookingRepository.VerifySeatBooking(createBookingDto);

            if (!isSeatAvailable)
            {
                return Conflict();
            }

            var result = await this._bookingRepository.CreateBooking(createBookingDto);
            await this._bookingRepository.GetBookingById(result.Id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Booking>> GetBookingByBookingId(int id)
    {
        try
        {
            var result = await this._bookingRepository.GetBookingById(id);

            if (result == null)
            {
                return NotFound(); // Returnera HTTP 404 Not Found om bokningen inte hittas
            }

            return Ok(result); // Returnera HTTP 200 OK med bokningsresultatet
        }
        catch (Exception ex) // Fånga alla exceptions som kan uppstå
        {
            // Hantera exceptions och returnera lämplig HTTP-statuskod och meddelande
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }
}
