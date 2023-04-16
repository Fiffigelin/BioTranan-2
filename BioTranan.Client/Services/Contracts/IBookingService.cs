using BioTranan.Core.Dto;
using BioTranan.Core.Entities;

namespace BioTranan.Client.Services.Contracts;

public interface IBookingService
{
    Task CreateBooking(CreateBookingDto createBooking);
    Task<Booking> GetBookingById(int id);
}

