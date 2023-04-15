using BioTranan.Core.Data;
using BioTranan.Core.ViewModels;
using BioTranan.Core.Services.Contracts;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BioTranan.Core.Services;

public class ShowsService : IShowsService
{
    private readonly BioTrananDbContext _context;

    public ShowsService(BioTrananDbContext context)
    {
        _context = context;
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