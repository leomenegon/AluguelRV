using AluguelRV.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AluguelRV.Client.Services;

public class UserService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigation;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;

    public UserService(HttpClient http, NavigationManager navigation, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
    {
        _http=http;
        _navigation=navigation;
        _localStorage=localStorage;
        _authStateProvider=authStateProvider;
    }

    public UserViewModel? User { get; set; }

    public async Task<UserViewModel?> GetUser()
    {
        var token = await _localStorage.GetItemAsync<string>("token");

        if (!string.IsNullOrWhiteSpace(token))
        {
            if (User != null)
                return User;

            User = new UserViewModel //TODO: decode token
            {
                Name = "teste",
                Resident = true,
                Room = "asia",
                Username = "username"
            };

            return User;
        }

        return null;
    }

    public async Task HandleLogin(LoginRequestDto loginRequest)
    {
        var result = await _http.PostAsJsonAsync("api/login", loginRequest);

        if (!result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<ResponseViewModel>();

            Console.WriteLine(response?.Message ?? "Erro interno");
        }
        else
        {
            var token = await result.Content.ReadAsStringAsync();

            await _localStorage.SetItemAsync("token", token.Replace("\"", ""));

            Console.WriteLine(token);

            await _authStateProvider.GetAuthenticationStateAsync();

            _navigation.NavigateTo("/");
        }
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
        _http.DefaultRequestHeaders.Authorization = null;

        _navigation.NavigateTo("/login");
    }
}