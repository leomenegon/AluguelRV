namespace AluguelRV.Core.Models;
public class RentRoomPerson
{
    public int RentId { get; set; }
    public int RoomId { get; set; }
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = null!;
    public virtual Rent Rent { get; set; } = null!;
    public virtual Room Room { get; set; } = null!;
}