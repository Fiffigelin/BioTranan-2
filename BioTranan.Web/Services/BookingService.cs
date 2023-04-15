using System.Text;
using System.Text.Json;
using BioTranan.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace BioTranan.Web.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _client;
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public BookingService(HttpClient client)
    {
        _client = client;
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