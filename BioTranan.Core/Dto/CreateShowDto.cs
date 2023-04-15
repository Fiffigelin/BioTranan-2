namespace BioTranan.Core.Dto;

public class CreateShowDto
{
    public int MovieId { get; set; }
    public string? Language { get; set; }
    public string? Subtitles { get; set; }
    public int SalonId { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
}