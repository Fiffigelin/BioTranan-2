using BioTranan.Core.Services.Contracts;
using BioTranan.Core.ViewModels;
using Microsoft.AspNetCore.Components;

public class ShowsComponent : ComponentBase
{
    [Inject]
    public IShowsService? ShowsService { get; set; }
    public IEnumerable<ShowDetailsDto>? Schemas { get; set; }

    protected override async Task OnInitializedAsync()
    {
    }
}