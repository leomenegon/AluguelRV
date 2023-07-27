using AluguelRV.Shared.Enums;

namespace AluguelRV.Core.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }
    public int PersonId { get; set; }
    public RoleType Role { get; set; }
    public bool Deleted { get; set; }
    public virtual Person Person { get; set; } = null!;
    public virtual ICollection<Expense> Expenses { get; set; } = null!;

    // Pagamentos que este user cadastrou (não necessáriamente ele que pagou)
    public virtual ICollection<RentPayment> CreatedRentPayments { get; set; } = new List<RentPayment>();
}