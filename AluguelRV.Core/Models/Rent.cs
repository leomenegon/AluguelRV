namespace AluguelRV.Core.Models;
public class Rent
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
    public bool Closed { get; set; }
    public bool Deleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? Timestamp { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}