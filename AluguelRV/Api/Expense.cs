using AluguelRV.Api.Dapper.Data;
using AluguelRV.Shared.ViewModels;
using AluguelRV.Domain;
using AutoMapper;

namespace AluguelRV.Api;

public static class Expense
{
    public static async Task<IResult> GetAll(IMapper mapper, ExpenseData expenseData)
    {
        var response = new ResponseHandler();

        var data = await expenseData.GetAll();

        if (data.Any())
            response.Value = mapper.Map<IEnumerable<ExpenseViewModel>>(data);
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }

    public static async Task<IResult> GetById(IMapper mapper, ExpenseData expenseData, int id)
    {
        var response = new ResponseHandler();

        var data = await expenseData.GetById(id);

        if (data != null)
            response.Value = mapper.Map<ExpenseViewModel>(data);
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }

    public static async Task<IResult> GetByPerson(IMapper mapper, ExpenseData expenseData, int rentId, int personId)
    {
        var response = new ResponseHandler();

        var data = await expenseData.GetByPerson(rentId, personId);

        if (data != null)
            response.Value = data;
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }

    public static async Task<IResult> GetByRent(IMapper mapper, ExpenseData expenseData, int rentId)
    {
        var response = new ResponseHandler();

        var data = await expenseData.GetByRent(rentId);

        if (data.Any())
            response.Value = mapper.Map<IEnumerable<ExpenseViewModel>>(data);
        else
            response.SetAsNotFound();

        return Api.Response(response);
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

        var persons = await expenseData.GetPersons(id);

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
