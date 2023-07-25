using AluguelRV.Core.Data.DbAccess;
using AluguelRV.Core.Interfaces.Repositories;
using AluguelRV.Core.Models;
using AluguelRV.Shared.Dtos;
using Mapster;

namespace AluguelRV.Core.Services;
public class ExpenseService
{
    private readonly IBaseRepository<Expense> _repository;
    private ResponseHandler _response;
    private readonly AluguelContext _context;

    public ExpenseService(IBaseRepository<Expense> repository, AluguelContext context)
    {
        _repository=repository;
        _response = new ResponseHandler();
        _context=context;
    }

    public async Task<ResponseHandler> Create(CreateExpenseRequest request)
    {
        var expense = request.Adapt<Expense>();

        await _context.Expenses.AddAsync(expense);

        //await _context.SaveChangesAsync();

        if (request.PersonAmount != null && request.PersonAmount.Any())
        {
            var expensePerson = request.PersonAmount.Select(p => new ExpensePerson
            {
                Expense = expense,
                PersonId = p.PersonId,
                CustomAmount =  expense.CustomDivision && (p.CustomAmount ?? 0) > 0 ? p.CustomAmount : null
            }).ToList();

            expense.General = false;

            await _context.ExpensePeople.AddRangeAsync(expensePerson);
        }
        else
        {
            expense.CustomDivision = false;
            expense.General = true;
        }

        await _context.SaveChangesAsync();

        _response.SetAsCreated(expense, $"api/expense/{expense.Id}");

        return _response;
    }
}