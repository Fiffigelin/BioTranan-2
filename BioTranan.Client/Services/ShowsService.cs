using BioTranan.Client.Services.Contracts;
using BioTranan.Core.ViewModels;
#nullable disable

namespace BioTranan.Client.Services;

public class ShowsService : IShowsService
{
    private readonly HttpClient _client;

    public ShowsService(HttpClient client)
    {
        _client = client;
    }

    public async Task<MovieDetailsDto> GetMovieDetails(int id)
    {
        var response = await this._client.GetAsync($"api/Schemas/{id}");
        return await response.Content.ReadFromJsonAsync<MovieDetailsDto>();
    }

    public async Task<IEnumerable<ShowDetailsDto>> GetSchemas()
    {
        return await this._client.GetFromJsonAsync<IEnumerable<ShowDetailsDto>>("api/Schemas");
    }
}