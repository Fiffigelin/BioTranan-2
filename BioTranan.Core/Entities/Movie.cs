using System.ComponentModel.DataAnnotations;

namespace BioTranan.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? HeroImageUrl { get; set; }
    public int ReleaseYear { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? AgeRestrictions { get; set; }
    [Required]
    public int MaximumShows { get; set; }
    public ICollection<Show>? Shows = new List<Show>();
}