using AluguelRV.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace AluguelRV.Api;

public static class PersonApi
{
    public static async Task<IResult> GetAll(IPersonService personService)
        => Api.Response(await personService.GetAll());

    public static async Task<IResult> GetById(int id, IPersonService personService)
        => Api.Response(await personService.GetById(id));
}
