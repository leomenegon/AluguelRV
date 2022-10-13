using AluguelRV.Domain.Dtos;

namespace AluguelRV.Domain.Interfaces.Services;

public interface IExpenseService
{
    Task<ResponseHandler> Create(CreateExpenseRequest request);
    Task<ResponseHandler> GetAll();
    Task<ResponseHandler> GetById(int id);
    Task<ResponseHandler> GetByPerson(int rentId, int personId);
    Task<ResponseHandler> GetByRent(int rentId);
    Task<ResponseHandler> GetDetails(int expenseId);
}