// using System.Text;
// using System.Text.Json;
// using BioTranan.Core.Data;
// using BioTranan.Core.Services.Contracts;
// using BioTranan.Core.Entities;
// using BioTranan.Core.Dto;

// namespace BioTranan.Core.Services;

// public class BookingService : IBookingService
// {
//     private readonly BioTrananDbContext _context;

//     public BookingService(BioTrananDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Booking> CreateBooking(CreateBookingDto createBooking)
//     {
//         // var response = await this._client.PostAsJsonAsync<CreateBookingDto>("api/Booking", createBooking);
//         try
//         {
//             var json = JsonSerializer.Serialize(createBooking);
//             var content = new StringContent(json, Encoding.UTF8, "application/json");
//             var response = await _client.PostAsync("api/Booking", content); // Skicka HTTP POST-förfrågan till API:et
//         }
//         catch (System.Exception)
//         {
//             throw;
//         }
//     }
// }