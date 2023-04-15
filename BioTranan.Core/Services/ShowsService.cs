using BioTranan.Core.Data;
using BioTranan.Core.Dto;
using BioTranan.Core.Extensions;
using BioTranan.Web.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BioTranan.Web.Services;

public class ShowsService : IShowsService
{
    private readonly BioTrananDbContext _context;

    public ShowsService(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task<MovieDetailsDto> GetMovieDetails(int id)
    {
        var show = await _context.Shows.FindAsync(id);
        var movie = await _context.Movies.FindAsync(show!.MovieId);
        var salon = await _context.Salons.FindAsync(show.SalonId);
        var bookings = await _context.Bookings.Where(b => b.Show!.Id == id).ToListAsync();

        var movieDetailsDto = show.ConvertToDto(movie, salon, bookings);
        return movieDetailsDto;
    }

    public async Task<IEnumerable<ShowDetailsDto>> GetSchemas()
    {
        var movies = await _context.Movies.ToListAsync();
        var salons = await _context.Salons.ToListAsync();
        var shows = await _context.Shows.ToListAsync();
        var bookings = await _context.Bookings.ToListAsync();

        var schemas = shows.ConvertToDto(movies, salons, bookings);
        return schemas;
    }
}