using Microsoft.AspNetCore.Components;

namespace BioTranan.Client.Pages;
public class ReceiptBase : ComponentBase
{
    [Parameter]
    public string Id { get; set; }

    public string Code { get; set; }

    protected override Task OnInitializedAsync()
    {
        Code = Id;
        return Task.CompletedTask;
    }
}