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
        var IsSeatAvailable = await this._bookingRepository.VerifySeatBooking(createBookingDto);

        if (IsSeatAvailable == false) return Conflict();

        var result = await this._bookingRepository.CreateBooking(createBookingDto);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Booking>> GetBookingByBookingId(int id)
    {
        var results = await this._bookingRepository.GetBookingById(id);

        if (results == null) return NotFound();

        return Ok(results);
    }
}