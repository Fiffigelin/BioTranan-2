namespace BioTranan.Core.Entities;

public class SalonExtensions
{
    public int Id { get; set; }
    public int AvailableSeats { get; set; }
    public bool IsClosed { get; set; } = false;
}