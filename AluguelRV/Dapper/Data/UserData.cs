using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Shared.Dtos;

namespace AluguelRV.Api.Dapper.Data;
public class UserData
{
    private readonly DataAccess _db;

    public UserData(DataAccess db)
    {
        _db = db;
    }

    public Task<Core.Models.User?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Core.Models.User?> GetByUsername(string username)
    {
        var query = await _db.LoadData<Core.Models.User, dynamic>("dbo.spUser_GetByUsername", new { Username = username });

        return query.FirstOrDefault();
    }

    public async Task CreateUser(CreateUserDto user)
    {
        await _db.ExecuteCommand<dynamic>("spUser_Insert", user);
    }
}
