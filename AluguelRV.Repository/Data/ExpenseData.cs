using AluguelRV.Domain.Models;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces;
using AluguelRV.Shared.ViewModels;
using AluguelRV.Domain.Dtos;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;

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

    public Task<IEnumerable<PersonViewModel>> GetPersons(int expenseId)
    {
        return _db.LoadData<PersonViewModel, dynamic>("dbo.spExpense_GetPersons", new { ExpenseId = expenseId });
    }

    public Task Create(CreateExpenseRequest dto)
    {
        if (dto.PersonAmount == null)
            dto.PersonAmount = new List<ExpensePersonRequest>();

        var parameters = new
        {
            RentId = dto.RentId,
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description,
            Amount = dto.Amount,
            CustomDivision = dto.CustomDivision,
            PersonAmount = dto.PersonAmount.ToDataTable().AsTableValuedParameter("dbo.PersonAmountType")
        };

        return _db.ExecuteCommand("dbo.spExpense_Insert", parameters);
    }

    public async Task<ExpenseDetailsViewModel?> GetDetailsById(int expenseId, int personId)
    {
        var query = await _db.LoadData<ExpenseDetailsViewModel, dynamic>("dbo.spExpense_GetDetails", new { Id = expenseId, PersonId = personId });

        return query.FirstOrDefault();
    }
}
