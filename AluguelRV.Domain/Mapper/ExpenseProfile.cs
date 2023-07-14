using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Mapper;
public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<ExpenseModel, ExpenseViewModel>();
    }
}
