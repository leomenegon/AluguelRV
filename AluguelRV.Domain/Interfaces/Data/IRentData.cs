using AluguelRV.Domain.Models;
using AluguelRV.Domain.ViewModels;

namespace AluguelRV.Domain.Interfaces.Data;
public interface IRentData
{
    Task<IEnumerable<RentModel>> GetAll();
    Task<RentRoomViewModel?> GetRoomAmountByPerson(int rentId, int personId);
}