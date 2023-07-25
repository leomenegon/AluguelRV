namespace AluguelRV.Core.Models;
public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Percentage { get; set; }
    public bool Archived { get; set; }
    public bool Deleted { get; set; }
    public DateTime? Timestamp { get; set; }
}