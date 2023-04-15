namespace BioTranan.Core.ViewModels;

public class ShowDetailsDto
{
    public int MovieId { get; set; }
    public string? MovieTitle { get; set; }
    public string? MovieGenre { get; set; }
    public string? MovieAgeRestriction { get; set; }
    public int ShowId { get; set; }
    public DateTime ShowStartTime { get; set; }
    public int ShowDurationHours { get; set; }
    public int ShowDurationMinutes { get; set; }
    public string? SpokenLanguage { get; set; }
    public string? Subtitles { get; set; }
    public int SalonId { get; set; }
    public int SalonSeats { get; set; }
    public int AvailableSeats { get; set; }
}