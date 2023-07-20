using AluguelRV.Domain.Interfaces.Services;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class ExpenseService : IExpenseService
{
    private readonly IMapper _mapper;
    private ResponseHandler _response;

    public ExpenseService(IMapper mapper)
    {
        _mapper=mapper;
        _response = new ResponseHandler();
    }
}