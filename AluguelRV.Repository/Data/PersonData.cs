using AluguelRV.Domain.Models;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces;

namespace AluguelRV.Repository.Data;
public class PersonData : IPersonData
{
    private readonly IDataAccess _db;

    public PersonData(IDataAccess db)
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
