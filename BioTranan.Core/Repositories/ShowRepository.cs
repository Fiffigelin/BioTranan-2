using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Entities;
using BioTranan.Core.Data;
using BioTranan.Core.Dto;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace BioTranan.Core.Repositories;

public class ShowRepository : IShowRepository
{
    private readonly BioTrananDbContext _context;
    private readonly IMovieRepository _movieRepository;

    public ShowRepository(BioTrananDbContext context, IMovieRepository movieRepository)
    {
        _context = context;
        _movieRepository = movieRepository;
    }

    public async Task<Show> CreateShow(CreateShowDto showDTO)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == showDTO.MovieId);
        var salon = _context.Salons.FirstOrDefault(s => s.Id == showDTO.SalonId);

        var result = new Show
        {
            MovieId = showDTO.MovieId,
            Movie = movie,
            Language = showDTO.Language,
            Subtitles = showDTO.Subtitles,
            SalonId = showDTO.SalonId,
            Salon = salon,
            Price = showDTO.Price,
            StartTime = showDTO.StartTime,
            EndTime = showDTO.StartTime.AddMinutes(movie!.DurationMinutes + 60)
        };

        var overlappingShow = await _context.Shows.FirstOrDefaultAsync(s =>
                s.SalonId == result.SalonId &&
                s.StartTime < result.EndTime &&
                s.EndTime > result.StartTime);

        List<Show> movieList = await _context.Shows.Where(s => s.MovieId == movie.Id).ToListAsync();

        if (overlappingShow == null && movieList.Count < movie.MaximumShows)
        {
            await _context.Shows.AddAsync(result);
            await _context.SaveChangesAsync();

            return result;
        }

        return null;
    }
}