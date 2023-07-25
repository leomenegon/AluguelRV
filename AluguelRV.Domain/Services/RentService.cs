using AutoMapper;

namespace AluguelRV.Domain.Services;
public class RentService
{
    private readonly IMapper _mapper;
    private ResponseHandler _response;

    public RentService(IMapper mapper)
    {
        _response = new ResponseHandler();
        _mapper=mapper;
    }
}
