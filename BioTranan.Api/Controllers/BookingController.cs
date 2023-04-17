using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Api.Controllers;

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
            var isSeatAvailable = await _bookingRepository.VerifySeatBooking(createBookingDto);

            if (!isSeatAvailable)
            {
                return Conflict();
            }

            var result = await _bookingRepository.CreateBooking(createBookingDto);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel vid skapande av bokning");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Booking>>> GetBookings()
    {
        try
        {
            var results = await _bookingRepository.GetAllBookings();

            if (results == null || results.Count == 0)
            {
                return NotFound();
            }

            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Fel vid hämtning av bokningar");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Booking>>> GetBookingsByShowId(int id)
    {
        try
        {
            var results = await _bookingRepository.GetBookingsByShow(id);

            if (results == null || results.Count == 0)
            {
                return NotFound();
            }

            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, "Showen du söker finns inte");
        }
    }
}