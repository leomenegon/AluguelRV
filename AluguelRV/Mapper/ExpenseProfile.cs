using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Api.Mapper;
public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<Domain.Models.Expense, ExpenseViewModel>();
    }
}
