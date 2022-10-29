namespace AluguelRV.Domain.ViewModels;
public record RentViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
    public bool Closed { get; set; }
}

public record RentListViewModel
{
    public IEnumerable<RentViewModel>? List { get; set; }
    public int DefaultRent { get; set; }
}

public record PersonRentListViewModel
{
    public IEnumerable<PersonRentViewModel>? List { get; set; }
    public int DefaultRent { get; set; }
}

public record RentRoomViewModel
{
    public int RoomId { get; set; }
    public string? Name { get; set; }
    public decimal RoomAmount { get; set; }
}

public record PersonRentViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
    public bool Closed { get; set; }
    public decimal IndividualRent { get; set; }
}