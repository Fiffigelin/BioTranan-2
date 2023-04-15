using BioTranan.Core.Data;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace BioTranan.Api.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly BioTrananDbContext _context;

    public MovieRepository(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateMovie(CreateMovieDto createdMovie)
    {
        var result = new Movie
        {
            Title = createdMovie.Title,
            Description = createdMovie.Description,
            ReleaseYear = createdMovie.ReleaseYear,
            DurationMinutes = createdMovie.DurationMinutes,
            Genre = createdMovie.Genre.ToString(),
            Director = createdMovie.Director,
            OriginalLanguage = createdMovie.OriginalLanguage,
            AgeRestrictions = createdMovie.AgeRestrictions,
            MaximumShows = createdMovie.MaximumShows
        };
        await _context.Movies.AddAsync(result);
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<Movie> DeleteMovie(int id)
    {
        var result = await _context.Movies.FindAsync(id);

        if (result != null)
        {
            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();
        }

        return result!;
    }

    public async Task<List<Movie>> GetMovieList()
    {
        var result = await _context.Movies.ToListAsync();
        return result;
    }
}