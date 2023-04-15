using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BioTranan.Core.Dto;

public class CreateMovieDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genres Genre { get; set; }
    public string? Director { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? AgeRestrictions { get; set; }
    [Required]
    public int MaximumShows { get; set; }
}

public enum Genres
{
    Familj = 1,
    Skräck,
    Action,
    Thriller,
    Komedi,
    Romantisk,
    Äventyr,
    Drama,
    Fantasy
}