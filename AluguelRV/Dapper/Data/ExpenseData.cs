using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api.Dapper.Data;
public class ExpenseData
{
    private readonly DataAccess _db;

    public ExpenseData(DataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ExpenseViewModel>> GetAll()
    {
        return _db.LoadData<ExpenseViewModel, dynamic>("dbo.spExpense_GetAll", new { });
    }

    public async Task<ExpenseViewModel?> GetById(int id)
    {
        var query = await _db.LoadData<ExpenseViewModel, dynamic>("dbo.spExpense_Get", new { Id = id });

        return query.FirstOrDefault();
    }

    public Task<IEnumerable<PersonExpenseViewModel>> GetByPerson(int rentId, int personId)
    {
        return _db.LoadData<PersonExpenseViewModel, dynamic>("dbo.spExpense_GetByPerson", new { RentId = rentId, PersonId = personId });
    }

    public Task<IEnumerable<ExpenseViewModel>> GetByRent(int rentId)
    {
        return _db.LoadData<ExpenseViewModel, dynamic>("dbo.spExpense_GetByRent", new { RentId = rentId });
    }

    public Task<IEnumerable<PersonViewModel>> GetExpensePersons(int expenseId)
    {
        return _db.LoadData<PersonViewModel, dynamic>("dbo.spExpense_GetPersons", new { ExpenseId = expenseId });
    }

    public async Task<ExpenseDetailsViewModel?> GetDetailsById(int expenseId, int personId)
    {
        var query = await _db.LoadData<ExpenseDetailsViewModel, dynamic>("dbo.spExpense_GetDetails", new { Id = expenseId, PersonId = personId });

        return query.FirstOrDefault();
    }
}