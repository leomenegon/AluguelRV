using AluguelRV.Domain.Dtos;
using AluguelRV.Domain.Interfaces.Services;

namespace AluguelRV.Api;

public static class Expense
{
    public static async Task<IResult> GetAll(IExpenseService expenseService)
        => Api.Response(await expenseService.GetAll());
    public static async Task<IResult> GetById(int id, IExpenseService expenseService)
        => Api.Response(await expenseService.GetById(id));
    public static async Task<IResult> GetByPerson(int rentId, int personId, IExpenseService expenseService)
        => Api.Response(await expenseService.GetByPerson(rentId, personId));
    public static async Task<IResult> GetByRent(int rentId, IExpenseService expenseService)
        => Api.Response(await expenseService.GetByRent(rentId));
    public static async Task<IResult> GetDetails(int expenseId, IExpenseService expenseService)
        => Api.Response(await expenseService.GetDetails(expenseId));
    public static async Task<IResult> Create(CreateExpenseRequest request, IExpenseService expenseService)
        => Api.Response(await expenseService.Create(request));
}
