namespace AluguelRV.Shared.Dtos;
public class CreatePersonRequest
{
    public string Name { get; set; } = string.Empty;
}

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}