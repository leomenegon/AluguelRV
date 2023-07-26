using AluguelRV.Shared.ViewModels;
using System;

namespace AluguelRV.Shared.Dtos;

public class LoginRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class CreateUserRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public CreatePersonRequest? Person { get; set; }
}

public class CreateUserDto
{
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }
    public string Name { get; set; }
    public bool Resident { get; set; }
    public int? DefaultRoom { get; set; }
}

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int PersonId { get; set; }
    public string Role { get; set; }
}