namespace BioTranan.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public ICollection<Booking>? Shows = new List<Booking>();
}