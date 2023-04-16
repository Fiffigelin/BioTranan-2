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
        var booking = await this._client.PostAsJsonAsync("api/Booking", createBooking);
    }

    public async Task<Booking> GetBookingById(int id)
    {
        var response = await this._client.GetAsync($"api/Booking/{id}");
        return await response.Content.ReadFromJsonAsync<Booking>();
    }
}