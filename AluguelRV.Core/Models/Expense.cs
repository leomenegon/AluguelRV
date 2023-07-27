using AluguelRV.Shared.Enums;

namespace AluguelRV.Core.Models;
public class Expense
{
    public int Id { get; set; }
    public int RentId { get; set; }
    public string? Name { get; set; }
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool General { get; set; }
    public bool CustomDivision { get; set; }
    public int UserId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool Deleted { get; set; }
    public DateTime? Timestamp { get; set; }
    public virtual Rent Rent { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}