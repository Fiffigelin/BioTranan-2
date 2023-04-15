using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BioTranan.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    AgeRestrictions = table.Column<string>(type: "TEXT", nullable: true),
                    MaximumShows = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MaxSeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Subtitles = table.Column<string>(type: "TEXT", nullable: true),
                    SalonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShowId = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountSeat = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: true),
                    BookingCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestrictions", "Description", "Director", "DurationMinutes", "Genre", "MaximumShows", "OriginalLanguage", "ReleaseYear", "Title" },
                values: new object[] { 1, "15 år", "Oscar Schindler är en tysk affärsman under andra världskrigets slutskede som profiterar nazisternas utnyttjande av fängslande judar. Schindler växer till en hjälte som är beredd att ta stora risker för att hjälpa och skydda de judar han beslutar sig för att rädda.", "Steven Spielberg", 195, "Drama", 10, "Engelska", 1993, "Schindler's List" });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "MaxSeats", "Name" },
                values: new object[,]
                {
                    { 1, 45, "Salong 1" },
                    { 2, 45, "Salong 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email" },
                values: new object[] { 1, "user123@mail.com" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "EndTime", "Language", "MovieId", "Price", "SalonId", "StartTime", "Subtitles" },
                values: new object[] { 1, new DateTime(2023, 4, 20, 19, 15, 0, 0, DateTimeKind.Unspecified), "Eng tal", 1, 90m, 1, new DateTime(2023, 4, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "Sve text" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowId",
                table: "Bookings",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_SalonId",
                table: "Shows",
                column: "SalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
