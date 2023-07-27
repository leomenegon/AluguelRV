using AluguelRV.Api.Dapper.Data;
using AluguelRV.Core.Services;
using AluguelRV.Core;
using AluguelRV.Shared.Dtos;
using AluguelRV.Shared.ViewModels;
using Azure;

namespace AluguelRV.Api.Api;

public static class Expense
{
    public static async Task<IResult> GetAll(ExpenseData expenseData)
    {
        var data = await expenseData.GetAll();

        return WebApi.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetById(ExpenseData expenseData, int id)
    {
        var data = await expenseData.GetById(id);

        return WebApi.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetByPerson(IHttpContextAccessor accessor, ExpenseData expenseData, ConfigData configData, int rentId = 0, int personId = 0)
    {
        if (rentId < 1)
            rentId = await WebApi.getDefaultRentOrThrow(configData);

        var user = WebApi.GetUserFromContextOrThrow(accessor);
        if (user.Role != "manager")
            personId = user.PersonId;

        var data = await expenseData.GetByPerson(rentId, personId);

        return WebApi.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetByRent(ExpenseData expenseData, int rentId)
    {
        var data = await expenseData.GetByRent(rentId);

        return WebApi.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetDetails(ExpenseData expenseData, int id)
    {
        var response = new ResponseHandler();

        var expense = await expenseData.GetDetailsById(id, 1);

        if (expense == null)
        {
            response.SetAsNotFound();

            return WebApi.Response(response);
        }

        var persons = await expenseData.GetExpensePersons(id);

        response.Value = new ExpenseDetailsResponseViewModel
        {
            Expense = expense,
            Persons = persons
        };

        return WebApi.Response(response);
    }

    public static async Task<IResult> Create(ExpenseService service, CreateExpenseRequest request)
    {
        var response = await service.Create(request);

        return WebApi.Response(response);
    }
}
