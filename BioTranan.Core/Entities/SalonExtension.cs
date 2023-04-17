namespace BioTranan.Core.Entities;

public class SalonExtensions
{
    public int Id { get; set; }
    public int AvailableSeats { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsClosed { get; set; } = false;
}