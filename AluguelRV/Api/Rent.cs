using AluguelRV.Api.Dapper.Data;
using AluguelRV.Core;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api.Api;

public static class Rent
{
    public static async Task<IResult> GetAll(ConfigData configData, RentData rentData)
    {
        var response = new ResponseHandler();

        var data = await rentData.GetAll();
        var def = await configData.GetByKey("DEF_RENT");

        if (data.Any())
            response.Value = new RentListViewModel
            {
                List = data,
                DefaultRent = !string.IsNullOrWhiteSpace(def) ? int.Parse(def) : 0
            };
        else
            response.SetAsNotFound();

        return WebApi.Response(response);
    }

    public static async Task<IResult> GetRoomAmountByPerson(IHttpContextAccessor accessor, RentData rentData, int rentId, int personId = 0)
    {
        var user = WebApi.GetUserFromContextOrThrow(accessor);
        if(user.Role != "manager")
            personId = user.PersonId;

        var data = await rentData.GetRoomAmountByPerson(rentId, personId);

        return WebApi.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetPersonRent(IHttpContextAccessor accessor, ConfigData configData, RentData rentData, int rentId = 0, int personId = 0)
    {
        var user = WebApi.GetUserFromContextOrThrow(accessor);
        if (user.Role != "manager")
            personId = user.PersonId;

        var response = new ResponseHandler();

        var defRent = await configData.GetByKey("DEF_RENT");
        var intDefRent = !string.IsNullOrWhiteSpace(defRent) ? int.Parse(defRent) : 0;

        if(rentId < 1 && intDefRent < 1)
        {
            response.SetBadRequest("Informe um aluguel válido!");
            return WebApi.Response(response);
        }
        
        rentId = rentId == 0 ? intDefRent : rentId;

        var data = await rentData.GetPersonRent(personId, rentId);

        if (data.Any())
            response.Value = new PersonRentListViewModel
            {
                List = data,
                DefaultRent = intDefRent
            };
        else
            response.SetAsNotFound();

        return WebApi.Response(response);
    }
}