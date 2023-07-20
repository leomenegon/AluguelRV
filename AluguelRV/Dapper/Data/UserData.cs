using AluguelRV.Shared.Dtos;
using AluguelRV.Domain.Models;
using AluguelRV.Api.Dapper.DbAccess;

namespace AluguelRV.Api.Dapper.Data;
public class UserData
{
    private readonly DataAccess _db;

    public UserData(DataAccess db)
    {
        _db = db;
    }

    public Task<UserModel?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetByUsername(string username)
    {
        var query = await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetByUsername", new { Username = username });

        return query.FirstOrDefault();
    }

    public async Task CreateUser(CreateUserDto user)
    {
        await _db.ExecuteCommand<dynamic>("spUser_Insert", user);
    }
}
