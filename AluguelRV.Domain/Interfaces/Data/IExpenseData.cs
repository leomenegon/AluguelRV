using AluguelRV.Domain.Models;
using AluguelRV.Domain.ViewModels;

namespace AluguelRV.Domain.Interfaces.Data;
public interface IExpenseData
{
    Task<IEnumerable<ExpenseModel>> GetAll();
    Task<ExpenseModel?> GetById(int id);
    Task<IEnumerable<PersonExpenseViewModel>> GetByPerson(int rentId, int personId);
    Task<IEnumerable<ExpenseViewModel>> GetByRent(int rentId);
}