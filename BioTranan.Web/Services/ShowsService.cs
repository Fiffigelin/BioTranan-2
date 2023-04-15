using BioTranan.Models.Dtos;
using BioTranan.Web.Services.Contracts;

namespace BioTranan.Web.Services;

public class ShowsService : IShowsService
{
    private readonly HttpClient _client;

    public ShowsService(HttpClient client)
    {
        _client = client;
    }

    public async Task<MovieDetailsDto> GetMovieDetails(int id)
    {
        var response = await this._client.GetAsync($"api/MovieDetails/{id}");
        return await response.Content.ReadFromJsonAsync<MovieDetailsDto>();
    }

    public async Task<IEnumerable<ShowDetailsDto>> GetSchemas()
    {
        return await this._client.GetFromJsonAsync<IEnumerable<ShowDetailsDto>>("api/MovieDetails");
    }
}