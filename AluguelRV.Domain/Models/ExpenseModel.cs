using AluguelRV.Shared.Enums;

namespace AluguelRV.Domain.Models;
public class ExpenseModel
{
    public int Id { get; set; }
    public int RentId { get; set; }
    public string? Name { get; set; }
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool CustomDivision { get; set; }
    public bool Deleted { get; set; }
}