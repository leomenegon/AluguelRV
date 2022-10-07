using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class RentService : IRentService
{
    private readonly IRentData _rentData;
    private readonly IMapper _mapper;

    public RentService(IRentData rentData, IMapper mapper)
    {
        _rentData=rentData;
        _mapper=mapper;
    }

    public async Task<ResponseHandler> GetAll()
    {
        var response = new ResponseHandler();

        var data = await _rentData.GetAll();

        if (data.Any())
            response.Value = _mapper.Map<IEnumerable<RentViewModel>>(data);
        else
            response.SetAsNotFound();

        return response;
    }

    public async Task<ResponseHandler> GetRoomAmountByPerson(int rentId, int personId)
    {
        var response = new ResponseHandler();

        var data = await _rentData.GetRoomAmountByPerson(rentId, personId);

        if (data != null)
            response.Value = data;
        else
            response.SetAsNotFound();

        return response;
    }
}
