namespace AluguelRV.Domain.Interfaces.Services;
public interface IPersonService
{
    Task<ResponseHandler> GetAll();
    Task<ResponseHandler> GetById(int id);
}