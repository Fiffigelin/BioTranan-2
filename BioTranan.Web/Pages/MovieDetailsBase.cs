using BioTranan.Models.Dtos;
using BioTranan.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BioTranan.Web.Pages;

public class MovieDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IShowsService ShowsService { get; set; }
    [Inject]
    public IBookingService BookingService { get; set; }
    public MovieDetailsDto MovieDetails { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MovieDetails = await ShowsService.GetMovieDetails(Id);
    }

    protected async Task AddBooking_Click(CreateBookingDto createBooking)
    {
        createBooking.ShowId = Id;
        try
        {
            await BookingService.CreateBooking(createBooking);
            // NavigationManager.NavigateTo("/");
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
