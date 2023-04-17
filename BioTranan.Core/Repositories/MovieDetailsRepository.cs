using BioTranan.Core.Data;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace BioTranan.Core.Repositories;

public class MovieDetailsRepository : IMovieDetailsRepository
{
    private readonly BioTrananDbContext _context;

    public MovieDetailsRepository(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await this._context.Movies.ToListAsync();
    }

    public async Task<IEnumerable<Salon>> GetSalons()
    {
        return await this._context.Salons.ToListAsync();
    }

    public async Task<IEnumerable<Show>> GetShows()
    {
        var currentDateTime = DateTime.Now;

        var shows = await this._context.Shows
            .Where(s => s.StartTime > currentDateTime)
            .ToListAsync();

        return shows;
    }
    public async Task<IEnumerable<Booking>> GetBookings()
    {
        return await this._context.Bookings.ToListAsync();
    }

    public async Task<Show> GetShow(int id)
    {
        return await this._context.Shows.FindAsync(id);
    }

    public async Task<Salon> GetSalon(int id)
    {
        return await this._context.Salons.FindAsync(id);
    }

    public async Task<Movie> GetMovie(int id)
    {
        return await this._context.Movies.FindAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetBookings(int id)
    {
        return await this._context.Bookings.Where(b => b.Show!.Id == id).ToListAsync();
    }
}