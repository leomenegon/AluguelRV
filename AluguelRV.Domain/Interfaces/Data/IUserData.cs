using AluguelRV.Shared.Dtos;
using AluguelRV.Domain.Models;

namespace AluguelRV.Domain.Interfaces.Data;
public interface IUserData
{
    Task CreateUser(CreateUserDto user);
    Task<UserModel?> GetById(int id);
    Task<UserModel?> GetByUsername(string username);
}