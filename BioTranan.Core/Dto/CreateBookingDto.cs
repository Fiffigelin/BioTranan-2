namespace BioTranan.Core.Dto;

public class CreateBookingDto
{
    public int ShowId { get; set; }
    public int AmountSeat { get; set; }
    public string? UserEmail { get; set; }
    public string? BookingCode { get; set; }
}