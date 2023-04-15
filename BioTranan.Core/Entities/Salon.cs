namespace BioTranan.Core.Entities;

public class Salon
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int MaxSeats { get; set; }
    public ICollection<Show>? Shows = new List<Show>();
    public ICollection<SalonExtensions>? Extensions = new List<SalonExtensions>();
}