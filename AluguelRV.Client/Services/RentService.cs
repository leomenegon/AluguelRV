using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AluguelRV.Client.Services;

public class RentService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigation;

    public RentService(HttpClient http, NavigationManager navigation)
    {
        _http=http;
        _navigation=navigation;
    }

    public RentViewModel? Rent { get; set; }

    public async Task GetRents()
    {
        var result = await _http.GetFromJsonAsync<RentListViewModel>($"rent");

        if (result != null)
            Rent = result.List?.FirstOrDefault();
    }
}
