using Microsoft.EntityFrameworkCore;
using BioTranan.Core.Entities;

namespace BioTranan.Core.Data;

public class BioTrananDbContext : DbContext
{
    public BioTrananDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movie>().HasData(new Movie
        {
            Id = 1,
            Title = "Schindler's List",
            Description = "Oscar Schindler är en tysk affärsman under andra världskrigets slutskede som profiterar nazisternas utnyttjande av fängslande judar. Schindler växer till en hjälte som är beredd att ta stora risker för att hjälpa och skydda de judar han beslutar sig för att rädda.",
            ReleaseYear = 1993,
            DurationMinutes = 195,
            Genre = "Drama",
            Director = "Steven Spielberg",
            OriginalLanguage = "Engelska",
            AgeRestrictions = "15 år",
            MaximumShows = 10,
        });

        modelBuilder.Entity<Salon>().HasData(new Salon
        {
            Id = 1,
            Name = "Salong 1",
            MaxSeats = 45
        });

        modelBuilder.Entity<Salon>().HasData(new Salon
        {
            Id = 2,
            Name = "Salong 2",
            MaxSeats = 45
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            Id = 1,
            MovieId = 1,
            Language = "Eng tal",
            Subtitles = "Sve text",
            SalonId = 1,
            Price = 90,
            StartTime = new DateTime(2023, 04, 20, 15, 00, 00),
            EndTime = new DateTime(2023, 04, 20, 15, 00, 00).AddMinutes(255),
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Email = "user123@mail.com"
        });
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
}