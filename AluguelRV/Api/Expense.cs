using AluguelRV.Api.Dapper.Data;
using AluguelRV.Domain;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Api;

public static class Expense
{
    public static async Task<IResult> GetAll(ExpenseData expenseData)
    {
        var data = await expenseData.GetAll();

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetById(ExpenseData expenseData, int id)
    {
        var data = await expenseData.GetById(id);

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetByPerson(ExpenseData expenseData, int rentId, int personId)
    {
        var data = await expenseData.GetByPerson(rentId, personId);

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetByRent(ExpenseData expenseData, int rentId)
    {
        var data = await expenseData.GetByRent(rentId);

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetDetails(IMapper mapper, ExpenseData expenseData, int id)
    {
        var response = new ResponseHandler();

        var expense = await expenseData.GetDetailsById(id, 1);

        if (expense == null)
        {
            response.SetAsNotFound();

            return Api.Response(response);
        }

        var persons = await expenseData.GetExpensePersons(id);

        response.Value = new ExpenseDetailsResponseViewModel
        {
            Expense = expense,
            Persons = mapper.Map<IEnumerable<PersonViewModel>>(persons)
        };

        return Api.Response(response);
    }

    //public static async Task<IResult> Create(CreateExpenseRequest request)
    //{

    //}
}
