using System.Text.Json;
using BioTranan.Core.Dto;
using BioTranan.Core.Entities;
using BioTranan.Core.Data;
using BioTranan.Client.Services.Contracts;

namespace BioTranan.Client.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _client;

    public BookingService(HttpClient client)
    {
        _client = client;
    }

    public async Task CreateBooking(CreateBookingDto createBooking)
    {
        await this._client.PostAsJsonAsync("api/Booking", createBooking);

    }

    public async Task<Booking> GetBooking(int id)
    {
        try
        {
            var response = await this._client.GetAsync($"api/Booking/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var booking = JsonSerializer.Deserialize<Booking>(json, new JsonSerializerOptions { });

            return booking;
        }
        catch (Exception ex)
        {
            throw new Exception("Ett fel inträffade vid hämtning av bokning.", ex);
        }
    }
}