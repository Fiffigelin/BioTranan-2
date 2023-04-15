using System.Text;
using System.Text.Json;
using BioTranan.Core.Data;
using BioTranan.Core.Dto;
using BioTranan.Core.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BioTranan.Web.Services;

public class BookingService : IBookingService
{
    private readonly BioTrananDbContext _context;

    public BookingService(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task CreateBooking(CreateBookingDto createBooking)
    {
        // var response = await this._client.PostAsJsonAsync<CreateBookingDto>("api/Booking", createBooking);
        try
        {
            var json = JsonSerializer.Serialize(createBooking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Booking", content); // Skicka HTTP POST-förfrågan till API:et
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}