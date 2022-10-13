using AluguelRV.Domain.Interfaces.Services;

namespace AluguelRV.Api;

public static class Rent
{
    public static async Task<IResult> GetAll(IRentService rentService)
        => Api.Response(await rentService.GetAll());
    public static async Task<IResult> GetRoomAmountByPerson(int rentId, int personId, IRentService rentService)
        => Api.Response(await rentService.GetRoomAmountByPerson(rentId, personId));
}
