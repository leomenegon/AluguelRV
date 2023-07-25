using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Api.Mapper;
public class RentProfile : Profile
{
    public RentProfile()
    {
        CreateMap<Domain.Models.Rent, RentViewModel>();
    }
}
