using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class ExpenseService : IExpenseService
{
    private readonly IExpenseData _expenseData;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseData expenseData, IMapper mapper)
    {
        _expenseData=expenseData;
        _mapper=mapper;
    }

    public async Task<ResponseHandler> GetAll()
    {
        var response = new ResponseHandler();

        var data = await _expenseData.GetAll();

        if (data.Any())
            response.Value = _mapper.Map<IEnumerable<ExpenseViewModel>>(data);
        else
            response.SetAsNotFound();

        return response;
    }

    public async Task<ResponseHandler> GetById(int id)
    {
        var response = new ResponseHandler();

        var data = await _expenseData.GetById(id);

        if (data != null)
            response.Value = _mapper.Map<ExpenseViewModel>(data);
        else
            response.SetAsNotFound();

        return response;
    }

    public async Task<ResponseHandler> GetByPerson(int rentId, int personId)
    {
        var response = new ResponseHandler();

        var data = await _expenseData.GetByPerson(rentId, personId);

        if (data != null)
            response.Value = data;
        else
            response.SetAsNotFound();

        return response;
    }
    public async Task<ResponseHandler> GetByRent(int rentId)
    {
        var response = new ResponseHandler();

        var data = await _expenseData.GetByRent(rentId);

        if (data.Any())
            response.Value = _mapper.Map<IEnumerable<ExpenseViewModel>>(data);
        else
            response.SetAsNotFound();

        return response;
    }
}
