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
        var IsSeatAvailable = await this._bookingRepository.VerifySeatBooking(createBookingDto);

        if (IsSeatAvailable == false) return Conflict();

        var result = await this._bookingRepository.CreateBooking(createBookingDto);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<Booking>>> GetBookings()
    {
        var results = await this._bookingRepository.GetAllBookings();

        if (results == null) return NotFound();

        return Ok(results);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Booking>>> GetBookingsByShowId(int id)
    {
        var results = await this._bookingRepository.GetBookingsByShow(id);

        if (results == null) return NotFound();

        return Ok(results);
    }
}