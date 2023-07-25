using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api.Dapper.Data;
public class PersonData
{
    private readonly DataAccess _db;

    public PersonData(DataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PersonViewModel>> GetAll()
    {
        return _db.LoadData<PersonViewModel, dynamic>("dbo.spPerson_GetAll", new { });
    }

    public async Task<PersonViewModel?> GetById(int id)
    {
        var query = await _db.LoadData<PersonViewModel, dynamic>("dbo.spPerson_Get", new { Id = id });

        return query.FirstOrDefault();
    }
}