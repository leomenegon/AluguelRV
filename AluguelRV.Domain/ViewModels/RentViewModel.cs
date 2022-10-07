namespace AluguelRV.Domain.ViewModels;
public record RentViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
    public bool Closed { get; set; }
}

public record RentRoomViewModel
{
    public int RoomId { get; set; }
    public string Name { get; set; }
    public decimal RoomAmount { get; set; }
}
