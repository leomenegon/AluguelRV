using AluguelRV.Shared.Enums;
using System.Text.Json.Serialization;

namespace AluguelRV.Shared.Dtos;
public class CreateExpenseRequest
{
    public int RentId { get; set; }
    public string? Name { get; set; }
    public ExpenseType? Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool? CustomDivision { get; set; }
    public IEnumerable<ExpensePersonRequest>? PersonAmount { get; set; }
}

public class ExpensePersonRequest
{
    public int PersonId { get; set; }

    [JsonIgnore]
    public string? Name { get; set; }
    public decimal? CustomAmount { get; set; }
}

public class UpdateExpenseRequest
{
    public int ExpenseId { get; set; }
    public int RentId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool? CustomDivision { get; set; }
    public IEnumerable<ExpensePersonRequest>? PersonAmount { get; set; }
}