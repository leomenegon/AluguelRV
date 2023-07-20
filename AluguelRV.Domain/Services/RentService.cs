using AluguelRV.Domain.Interfaces.Services;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class RentService : IRentService
{
    private readonly IMapper _mapper;
    private ResponseHandler _response;

    public RentService(IMapper mapper)
    {
        _response = new ResponseHandler();
        _mapper=mapper;
    }
}
