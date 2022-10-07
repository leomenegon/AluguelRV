namespace AluguelRV.Domain.Interfaces.Services;

public interface IRentService
{
    Task<ResponseHandler> GetAll();
    Task<ResponseHandler> GetRoomAmountByPerson(int rentId, int personId);
}