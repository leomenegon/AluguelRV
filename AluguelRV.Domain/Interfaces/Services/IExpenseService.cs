namespace AluguelRV.Domain.Interfaces.Services;

public interface IExpenseService
{
    Task<ResponseHandler> GetAll();
    Task<ResponseHandler> GetById(int id);
    Task<ResponseHandler> GetByPerson(int rentId, int personId);
    Task<ResponseHandler> GetByRent(int rentId);
}