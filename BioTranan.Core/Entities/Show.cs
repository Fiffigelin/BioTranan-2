namespace BioTranan.Core.Entities;

public class Show
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public string? Language { get; set; }
    public string? Subtitles { get; set; }
    public int SalonId { get; set; }
    public Salon? Salon { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ICollection<Booking>? Shows = new List<Booking>();
}