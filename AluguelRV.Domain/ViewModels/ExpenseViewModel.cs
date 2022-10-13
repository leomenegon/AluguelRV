using AluguelRV.Domain.Models;

namespace AluguelRV.Domain.ViewModels;
public record ExpenseViewModel
{
    public int Id { get; set; }
    public int RentId { get; set; }
    public string? Name { get; set; }
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool CustomDivision { get; set; }
}

public record PersonExpenseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ExpenseType Type { get; set; }
    public decimal IndividualAmount { get; set; }
    public decimal Amount { get; set; }
}

public record ExpenseDetailsViewModel
{
    public ExpenseViewModel Expense { get; set; }
    public IEnumerable<PersonViewModel> Persons { get; set; }
}
