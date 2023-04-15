using BioTranan.Core.Data;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace BioTranan.Core.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BioTrananDbContext _context;
    private readonly IUserRepository _userRepository;

    public BookingRepository(BioTrananDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }
    public async Task<Booking> CreateBooking(CreateBookingDto createBooking)
    {
        var show = _context.Shows.FirstOrDefault(s => s.Id == createBooking.ShowId);
        if (show == null) return null;

        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == createBooking.UserEmail);
        if (existingUser == null)
        {
            existingUser = await _userRepository.CreateUser(createBooking.UserEmail!);
        }

        show.Movie = _context.Movies.FirstOrDefault(m => m.Id == show.MovieId);
        show.Salon = _context.Salons.FirstOrDefault(s => s.Id == show.SalonId);

        var result = new Booking
        {
            ShowId = createBooking.ShowId,
            Show = show,
            AmountSeat = createBooking.AmountSeat,
            TotalPrice = show.Price * createBooking.AmountSeat,
            UserEmail = existingUser.Email,
        };

        result.BookingCode = Guid.NewGuid().ToString("N");

        await _context.Bookings.AddAsync(result);
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<List<Booking>> GetAllBookings()
    {
        var result = await _context.Bookings.ToListAsync();

        if (result == null) return null;

        return result;
    }

    public async Task<List<Booking>> GetBookingsByShow(int id)
    {
        var result = await _context.Bookings.Where(s => s.ShowId == id).ToListAsync();

        if (result == null) return null;

        return result;
    }

    public async Task<bool> VerifySeatBooking(CreateBookingDto createBooking)
    {
        var bookingsForShow = await _context.Bookings.Where(b => b.ShowId == createBooking.ShowId).ToListAsync();
        var show = await _context.Shows.FindAsync(createBooking.ShowId);
        var salon = await _context.Salons.FindAsync(show.SalonId);

        int availableSeats = salon.MaxSeats;
        foreach (var booking in bookingsForShow)
        {
            availableSeats -= booking.AmountSeat;
        }

        if (availableSeats >= createBooking.AmountSeat) return true;

        return false;
    }
}