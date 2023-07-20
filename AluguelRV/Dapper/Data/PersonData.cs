using AluguelRV.Domain.Models;
using AluguelRV.Api.Dapper.DbAccess;

namespace AluguelRV.Api.Dapper.Data;
public class PersonData
{
    private readonly DataAccess _db;

    public PersonData(DataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PersonModel>> GetAll()
    {
        return _db.LoadData<PersonModel, dynamic>("dbo.spPerson_GetAll", new { });
    }

    public async Task<PersonModel?> GetById(int id)
    {
        var query = await _db.LoadData<PersonModel, dynamic>("dbo.spPerson_Get", new { Id = id });

        return query.FirstOrDefault();
    }   
}