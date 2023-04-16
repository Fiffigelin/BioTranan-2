using BioTranan.Core.ViewModels;
using BioTranan.Core.Services.Contracts;
using Microsoft.AspNetCore.Components;

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