using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BioTranan.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? AgeRestrictions { get; set; }
    [Required]
    public int MaximumShows { get; set; }
    public ICollection<Show>? Shows;
}

// public enum Genres
// {
//     Familj = 1,
//     Skräck,
//     Action,
//     Thriller,
//     Komedi,
//     Romantisk,
//     Äventyr,
//     Drama,
//     Fantasy
// }

// JsonStringEnumConverter : https://code-maze.com/csharp-serialize-enum-to-string/