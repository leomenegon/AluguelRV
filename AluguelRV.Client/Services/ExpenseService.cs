using AluguelRV.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AluguelRV.Client.Services;

public class ExpenseService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigation;

    public ExpenseService(HttpClient http, NavigationManager navigation)
    {
        _http=http;
        _navigation=navigation;
    }

    public IEnumerable<ExpenseViewModel>? Expenses { get; set; }
    public IEnumerable<PersonExpenseViewModel>? PersonExpenses { get; set; }

    public async Task GetExpenses()
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<ExpenseViewModel>>("api/expense");

        if (result != null)
            Expenses = result;
    }

    public async Task GetIndividualExpenses()
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<PersonExpenseViewModel>?>("api/expense/person");

        if (result != null && result.Any())
            PersonExpenses = result;
    }

    public async Task CreateExpense(CreateExpenseRequest model)
    {
        var request = await _http.PostAsJsonAsync("api/expense", model);

        Console.WriteLine(request.ToString());
    }
}
