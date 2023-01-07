using AluguelRV.Domain.Dtos;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Services;
public class ExpenseService : IExpenseService
{
    private readonly IExpenseData _expenseData;
    private readonly IMapper _mapper;
    private ResponseHandler _response;

    public ExpenseService(IExpenseData expenseData, IMapper mapper)
    {
        _expenseData=expenseData;
        _mapper=mapper;
        _response = new ResponseHandler();
    }

    public async Task<ResponseHandler> GetAll()
    {
        var data = await _expenseData.GetAll();

        if (data.Any())
            _response.Value = _mapper.Map<IEnumerable<ExpenseViewModel>>(data);
        else
            _response.SetAsNotFound();

        return _response;
    }

    public async Task<ResponseHandler> GetById(int id)
    {
        var data = await _expenseData.GetById(id);

        if (data != null)
            _response.Value = _mapper.Map<ExpenseViewModel>(data);
        else
            _response.SetAsNotFound();

        return _response;
    }

    public async Task<ResponseHandler> GetByPerson(int rentId, int personId)
    {
        var data = await _expenseData.GetByPerson(rentId, personId);

        if (data != null)
            _response.Value = data;
        else
            _response.SetAsNotFound();

        return _response;
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

    public async Task<ResponseHandler> GetDetails(int expenseId)
    {
        var expense = await _expenseData.GetDetailsById(expenseId, 1);

        if(expense == null)
        {
            _response.SetAsNotFound();
            return _response;
        }

        var persons = await _expenseData.GetPersons(expenseId);

        _response.Value = new ExpenseDetailsResponseViewModel
        {
            Expense = expense,
            Persons = _mapper.Map<IEnumerable<PersonViewModel>>(persons)
        };

        return _response;
    }

    public async Task<ResponseHandler> Create(CreateExpenseRequest request)
    {
        await _expenseData.Create(request);

        return _response;
    }
}
