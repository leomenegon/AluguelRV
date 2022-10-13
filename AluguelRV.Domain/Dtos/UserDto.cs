namespace AluguelRV.Domain.Dtos;
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public CreatePersonRequest Person { get; set; }
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
