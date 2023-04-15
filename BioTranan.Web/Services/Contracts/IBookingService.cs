using BioTranan.Models.Dtos;

using BioTranan.Web.Services.Contracts;

public interface IBookingService
{
    Task CreateBooking(CreateBookingDto createBooking);
}

