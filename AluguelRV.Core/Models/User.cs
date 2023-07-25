namespace AluguelRV.Core.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }
    public int PersonId { get; set; }
    public bool Deleted { get; set; }
    public virtual Person Person { get; set; } = null!;
}