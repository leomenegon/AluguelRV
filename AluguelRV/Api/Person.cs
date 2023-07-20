using AluguelRV.Api.Dapper.Data;
using AluguelRV.Domain;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Shared.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AluguelRV.Api;

public static class Person
{
    public static async Task<IResult> GetAll(IMapper mapper, PersonData personData)
    {
        var response = new ResponseHandler();

        var data = await personData.GetAll();

        if (data.Any())
            response.Value = mapper.Map<IEnumerable<PersonViewModel>>(data);
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }

    public static async Task<IResult> GetById(IMapper mapper, PersonData personData, int id)
    {
        var response = new ResponseHandler();

        var data = await personData.GetById(id);

        if (data != null)
            response.Value = mapper.Map<PersonViewModel>(data);
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }
}