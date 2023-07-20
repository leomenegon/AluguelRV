using AluguelRV.Domain.Interfaces.Services;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class PersonService : IPersonService
{
    private readonly IMapper _mapper;

    public PersonService(IMapper mapper)
    {
        _mapper=mapper;
    }
}