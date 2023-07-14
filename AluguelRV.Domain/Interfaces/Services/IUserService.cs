using AluguelRV.Shared.Dtos;

namespace AluguelRV.Domain.Interfaces.Services;
public interface IUserService
{
    Task<ResponseHandler> Create(CreateUserRequest createUserRequest);
    void Hash(string password, out byte[] hash, out byte[] salt);
    Task<bool> ValidateCredentials(LoginRequestDto userDto);
}