using AluguelRV.Domain.Interfaces.Repositories;
using AluguelRV.Domain.Models;
using AluguelRV.Shared.Dtos;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class ExpenseService
{
    private readonly IBaseRepository<Expense> _repository;
    private readonly IMapper _mapper;
    private ResponseHandler _response;

    public ExpenseService(IMapper mapper, IBaseRepository<Expense> repository)
    {
        _mapper=mapper;
        _repository=repository;
        _response = new ResponseHandler();
    }

    public async Task<ResponseHandler> Create(CreateExpenseRequest request)
    {
        throw new NotImplementedException();
    }
}