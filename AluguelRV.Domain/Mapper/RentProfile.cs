using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Mapper;
public class RentProfile : Profile
{
	public RentProfile()
	{
		CreateMap<RentModel, RentViewModel>();
	}
}
