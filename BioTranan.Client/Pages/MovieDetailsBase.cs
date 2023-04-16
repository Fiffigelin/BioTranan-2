using BioTranan.Client.Services.Contracts;
using BioTranan.Core.Dto;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.ViewModels;
using Microsoft.AspNetCore.Components;
#nullable disable

namespace BioTranan.Client.Pages;

public class MovieDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IShowsService ShowsService { get; set; }
    [Inject]
    public IBookingService BookingService { get; set; }
    public IBookingRepository BookingRepository { get; set; }
    public MovieDetailsDto MovieDetails { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MovieDetails = await ShowsService.GetMovieDetails(Id);
    }

    protected async Task AddBooking_Click(CreateBookingDto createBooking)
    {
        try
        {
            await BookingService.CreateBooking(createBooking);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
