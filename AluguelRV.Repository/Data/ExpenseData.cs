using AluguelRV.Domain.Models;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.ViewModels;

namespace AluguelRV.Repository.Data;
public class ExpenseData : IExpenseData
{
    private readonly IDataAccess _db;

    public ExpenseData(IDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ExpenseModel>> GetAll()
    {
        return _db.LoadData<ExpenseModel, dynamic>("dbo.spExpense_GetAll", new { });
    }

    public async Task<ExpenseModel?> GetById(int id)
    {
        var query = await _db.LoadData<ExpenseModel, dynamic>("dbo.spExpense_Get", new { Id = id });

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
}
