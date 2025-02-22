﻿using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api.Dapper.Data;
public class RentData
{
    private readonly DataAccess _db;

    public RentData(DataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<RentViewModel>> GetAll()
    {
        return _db.LoadData<RentViewModel, dynamic>("dbo.spRent_GetAll", new { });
    }

    public async Task<RentRoomViewModel?> GetRoomAmountByPerson(int rentId, int personId)
    {
        var query = await _db.LoadData<RentRoomViewModel, dynamic>(
            "dbo.spRent_GetRoomAmountByPerson",
            new { RentId = rentId, PersonId = personId });

        return query.FirstOrDefault();
    }

    public async Task<IEnumerable<PersonRentViewModel>> GetPersonRent(int personId, int rentId)
    {
        return await _db.LoadData<PersonRentViewModel, dynamic>(
            "dbo.spRent_GetPersonRent",
            new { RentId = rentId, PersonId = personId });
    }
}