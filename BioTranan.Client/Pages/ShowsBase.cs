using BioTranan.Core.Services.Contracts;
using BioTranan.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BioTranan.Client.Pages;

public class ShowsBase : ComponentBase
{
    [Inject]
    public IShowsService ShowsService { get; set; }
    public IEnumerable<ShowDetailsDto> Schemas { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Schemas = await ShowsService.GetSchemas();
    }
}