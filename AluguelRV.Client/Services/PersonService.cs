using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AluguelRV.Client.Services;

public class PersonService
{
    private readonly HttpClient _http;

    public PersonService(HttpClient http)
    {
        _http=http;
    }

    public async Task<IEnumerable<PersonViewModel>> GetPersons()
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<PersonViewModel>>("api/person");

        return result!;
    }
}