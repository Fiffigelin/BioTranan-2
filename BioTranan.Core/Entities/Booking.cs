namespace BioTranan.Core.Entities;

public class Booking
{
    public int Id { get; set; }
    public int ShowId { get; set; }
    public Show? Show { get; set; }
    public int AmountSeat { get; set; }
    public decimal TotalPrice { get; set; }
    public string? UserEmail { get; set; }
    public string? BookingCode { get; set; }
}