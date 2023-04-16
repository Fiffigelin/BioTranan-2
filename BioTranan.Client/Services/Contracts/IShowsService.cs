using BioTranan.Core.ViewModels;

namespace BioTranan.Client.Services.Contracts;

public interface IShowsService
{
    Task<IEnumerable<ShowDetailsDto>> GetSchemas();
    Task<MovieDetailsDto> GetMovieDetails(int id);
}