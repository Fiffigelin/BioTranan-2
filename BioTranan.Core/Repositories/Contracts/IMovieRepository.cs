using BioTranan.Core.Entities;
using BioTranan.Api.Dto;

namespace BioTranan.Core.Repositories.Contracts;

public interface IMovieRepository
{
    Task<Movie> CreateMovie(CreateMovieDto createdMovie);
    Task<List<Movie>> GetMovieList();
    Task<Movie> DeleteMovie(int id);
    // void UpdateShowCounter(int id);
}