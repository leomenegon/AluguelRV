namespace AluguelRV.Shared.Dtos;
public class CreatePersonRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Resident { get; set; } = false;
}

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}