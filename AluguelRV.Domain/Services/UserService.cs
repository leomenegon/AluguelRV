using AluguelRV.Domain.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace AluguelRV.Domain.Services;
public class UserService : IUserService
{

    public UserService()
    {
        
    }

    //public async Task<ResponseHandler> Create(CreateUserRequest createUserRequest)
    //{
    //    var response = new ResponseHandler();

    //    Hash(createUserRequest.Password, out byte[] hash, out byte[] salt);

    //    var userDto = new CreateUserDto
    //    {
    //        Username = createUserRequest.Username,
    //        Password = hash,
    //        Salt = salt,
    //        Name = createUserRequest.Person.Name,
    //        Resident = false,
    //        DefaultRoom = null
    //    };

    //    await _userData.CreateUser(userDto);

    //    return response;
    //}

    public void Hash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();

        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}
