using BioTranan.Core.ViewModels;

namespace BioTranan.Core.Services.Contracts;

public interface IShowsService
{
    Task<IEnumerable<ShowDetailsDto>> GetSchemas();
    // Task<MovieDetailsDto> GetMovieDetails(int id);
}