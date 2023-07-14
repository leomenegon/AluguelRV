using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;

namespace AluguelRV.Domain.Mapper;
public class PersonProfile : Profile
{
	public PersonProfile()
	{
		CreateMap<PersonModel, PersonViewModel>();
	}
}
