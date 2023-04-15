using BioTranan.Core.Entities;

namespace BioTranan.Core.Repositories.Contracts;

public interface IMovieDetailsRepository
{
    public Task<IEnumerable<Movie>> GetMovies();
    public Task<IEnumerable<Salon>> GetSalons();
    public Task<IEnumerable<Show>> GetShows();
    public Task<IEnumerable<Booking>> GetBookings();
    public Task<Show> GetShow(int id);
    public Task<Salon> GetSalon(int id);
    public Task<Movie> GetMovie(int id);
    public Task<IEnumerable<Booking>> GetBookings(int id);
}