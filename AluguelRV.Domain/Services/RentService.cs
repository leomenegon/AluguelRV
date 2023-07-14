using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class RentService : IRentService
{
    private readonly IRentData _rentData;
    private readonly IMapper _mapper;
    private readonly IConfigData _configData;
    private ResponseHandler _response;

    public RentService(IRentData rentData, IMapper mapper, IConfigData configData)
    {
        _response = new ResponseHandler();

        _rentData=rentData;
        _mapper=mapper;
        _configData=configData;
    }

    public async Task<ResponseHandler> GetAll()
    {
        var data = await _rentData.GetAll();
        var def = await _configData.GetByKey("DEF_RENT");

        if (data.Any())
            _response.Value = new RentListViewModel
            {
                List = _mapper.Map<IEnumerable<RentViewModel>>(data),
                DefaultRent = !string.IsNullOrWhiteSpace(def) ? int.Parse(def) : 0
            };
        else
            _response.SetAsNotFound();

        return _response;
    }

    public async Task<ResponseHandler> GetRoomAmountByPerson(int rentId, int personId)
    {
        var data = await _rentData.GetRoomAmountByPerson(rentId, personId);

        if (data != null)
            _response.Value = data;
        else
            _response.SetAsNotFound();

        return _response;
    }

    public async Task<ResponseHandler> GetPersonRent(int rentId, int personId)
    {
        var data = await _rentData.GetPersonRent(personId, rentId);
        var def = await _configData.GetByKey("DEF_RENT");

        if (data.Any())
            _response.Value = new PersonRentListViewModel
            {
                List = data,
                DefaultRent = !string.IsNullOrWhiteSpace(def) ? int.Parse(def) : 0
            };
        else
            _response.SetAsNotFound();

        return _response;
    }
}
