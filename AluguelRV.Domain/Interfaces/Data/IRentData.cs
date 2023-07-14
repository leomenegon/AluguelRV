using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Domain.Interfaces.Data;
public interface IRentData
{
    Task<IEnumerable<RentModel>> GetAll();
    Task<IEnumerable<PersonRentViewModel>> GetPersonRent(int personId, int rentId);
    Task<RentRoomViewModel?> GetRoomAmountByPerson(int rentId, int personId);
}