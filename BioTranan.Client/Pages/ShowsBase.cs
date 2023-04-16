using BioTranan.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using BioTranan.Client.Services.Contracts;
#nullable disable

namespace BioTranan.Client.Pages;

public class ShowsBase : ComponentBase
{
    [Inject]
    public IShowsService ShowsService { get; set; }
    public IEnumerable<ShowDetailsDto> ShowsSchemas { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShowsSchemas = await ShowsService.GetSchemas();
    }
}