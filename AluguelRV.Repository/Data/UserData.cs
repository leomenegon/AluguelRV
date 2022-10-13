using AluguelRV.Domain.Dtos;
using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Models;

namespace AluguelRV.Repository.Data;
public class UserData : IUserData
{
    private readonly IDataAccess _db;

    public UserData(IDataAccess db)
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
