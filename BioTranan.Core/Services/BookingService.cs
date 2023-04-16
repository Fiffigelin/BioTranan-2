using System.Text;
using System.Text.Json;
using BioTranan.Core.Services.Contracts;
using BioTranan.Core.Dto;

namespace BioTranan.Core.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _client;

    public BookingService(HttpClient client)
    {
        _client = client;
    }

    public async Task CreateBooking(CreateBookingDto createBooking)
    {
        try
        {
            var json = JsonSerializer.Serialize(createBooking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Booking", content);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}