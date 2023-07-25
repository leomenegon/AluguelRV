namespace AluguelRV.Core.Models;
public class ExpensePerson
{
    public int ExpenseId { get; set; }
    public int PersonId { get; set; }
    public decimal? CustomAmount { get; set; }
    public virtual Expense Expense { get; set; } = null!;
    public virtual Person Person { get; set; } = null!;
}