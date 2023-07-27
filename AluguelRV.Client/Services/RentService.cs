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

    public PersonRentViewModel? Rent { get; set; }
    public IEnumerable<RentViewModel>? Rents { get; set; }

    public async Task GetRents()
    {
        var result = await _http.GetFromJsonAsync<RentListViewModel>($"api/rent");

        if (result != null)
            Rents = result.List;
    }

    public async Task GetIndividualRent()
    {
        var result = await _http.GetFromJsonAsync<PersonRentListViewModel>($"api/rent/individual");

        if (result != null && result.List != null && result.List.Any())
            Rent = result.List?.FirstOrDefault(r => r.Id == result.DefaultRent);
    }
}