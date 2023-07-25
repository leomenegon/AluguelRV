using AutoMapper;

namespace AluguelRV.Domain.Services;
public class PersonService
{
    private readonly IMapper _mapper;

    public PersonService(IMapper mapper)
    {
        _mapper=mapper;
    }
}