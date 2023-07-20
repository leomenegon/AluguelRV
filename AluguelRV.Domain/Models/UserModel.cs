namespace AluguelRV.Domain.Models;
public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }
    public int PersonId { get; set; }
    public bool Deleted { get; set; }
}
