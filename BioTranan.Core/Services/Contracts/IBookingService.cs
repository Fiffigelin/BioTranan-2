using BioTranan.Core.Dto;

namespace BioTranan.Core.Services.Contracts;

public interface IBookingService
{
    Task CreateBooking(CreateBookingDto createBooking);
}

