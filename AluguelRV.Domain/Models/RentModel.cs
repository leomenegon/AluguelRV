namespace AluguelRV.Domain.Models;
public class RentModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
    public bool Closed { get; set; }
    public bool Deleted { get; set; }
}
