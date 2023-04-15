using BioTranan.Core.Dto;

namespace BioTranan.Web.Services.Contracts;

public interface IShowsService
{
    Task<IEnumerable<ShowDetailsDto>> GetSchemas();
    Task<MovieDetailsDto> GetMovieDetails(int id);
}