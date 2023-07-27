namespace AluguelRV.Core.Models;
public class RentPayment
{
    public int Id { get; set; }
    public int RentId { get; set; }
    public int PersonId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string? ReceiptPath { get; set; } = null!;
    public bool Deleted { get; set; } =false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public virtual Rent Rent { get; set; } = null!;
    public virtual Person Person { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
