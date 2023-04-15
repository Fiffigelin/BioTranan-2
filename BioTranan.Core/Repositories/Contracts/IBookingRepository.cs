using BioTranan.Core.Entities;
using BioTranan.Core.Dto;

namespace BioTranan.Core.Repositories.Contracts;

public interface IBookingRepository
{
    Task<Booking> CreateBooking(CreateBookingDto createBooking);
    Task<List<Booking>> GetAllBookings();
    Task<List<Booking>> GetBookingsByShow(int id);
    Task<bool> VerifySeatBooking(CreateBookingDto createBooking);
}