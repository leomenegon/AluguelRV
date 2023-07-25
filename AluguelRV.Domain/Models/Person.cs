namespace AluguelRV.Domain.Models;
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DefaultRoom { get; set; }
    public bool Resident { get; set; }
    public bool Deleted { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}