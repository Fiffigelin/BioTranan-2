using BioTranan.Core.Entities;
using BioTranan.Core.ViewModels;

namespace BioTranan.Core.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ShowDetailsDto> ConvertToDto(this IEnumerable<Show> shows,
                                                                IEnumerable<Movie> movies,
                                                                IEnumerable<Salon> salons,
                                                                IEnumerable<Booking> bookings)
    {


        return (from show in shows
                join movie in movies
                on show.MovieId equals movie.Id
                join salon in salons
                on show.SalonId equals salon.Id

                // let booking = bookings.FirstOrDefault(b => b.ShowId == show.Id)
                select new ShowDetailsDto
                {
                    MovieId = movie.Id,
                    MovieTitle = movie.Title,
                    MovieGenre = movie.Genre,
                    MovieAgeRestriction = movie.AgeRestrictions,
                    ShowId = show.Id,
                    ShowStartTime = show.StartTime,
                    ShowDurationHours = (int)TimeSpan.FromMinutes(movie.DurationMinutes).TotalHours,
                    ShowDurationMinutes = movie.DurationMinutes % 60,
                    SpokenLanguage = show.Language,
                    Subtitles = show.Subtitles,
                    SalonId = salon.Id,
                    SalonSeats = salon.MaxSeats,
                    AvailableSeats = salon.MaxSeats - bookings.Where(booking => booking.ShowId == show.Id)
                                                              .Sum(booking => booking.AmountSeat)
                }).ToList();
    }

    public static MovieDetailsDto ConvertToDto(this Show show,
                                                Movie movie,
                                                Salon salon,
                                                IEnumerable<Booking> bookings)
    {
        return new MovieDetailsDto
        {
            MovieId = movie.Id,
            MovieTitle = movie.Title,
            MovieDirector = movie.Director,
            MovieGenre = movie.Genre,
            MovieDescription = movie.Description,
            MovieAgeRestriction = movie.AgeRestrictions,
            ShowId = show.Id,
            ShowStartTime = show.StartTime,
            ShowDurationHours = (int)TimeSpan.FromMinutes(movie.DurationMinutes).TotalHours,
            ShowDurationMinutes = movie.DurationMinutes % 60,
            SpokenLanguage = show.Language,
            Subtitles = show.Subtitles,
            PricePerTicket = show.Price,
            SalonId = salon.Id,
            SalonName = salon.Name,
            SalonSeats = salon.MaxSeats,
            AvailableSeats = salon.MaxSeats - bookings.Where(booking => booking.ShowId == show.Id)
                                                              .Sum(booking => booking.AmountSeat)

        };
    }
}