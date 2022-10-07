using AluguelRV.Domain.Models;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.ViewModels;

namespace AluguelRV.Repository.Data;
public class RentData : IRentData
{
    private readonly IDataAccess _db;

    public RentData(IDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<RentModel>> GetAll()
    {
        return _db.LoadData<RentModel, dynamic>("dbo.spRent_GetAll", new { });
    }

    public async Task<RentRoomViewModel?> GetRoomAmountByPerson(int rentId, int personId)
    {
        var query = await _db.LoadData<RentRoomViewModel, dynamic>(
            "dbo.spRent_GetRoomAmountByPerson",
            new { RentId = rentId, PersonId = personId });

        return query.FirstOrDefault();
    }
}

