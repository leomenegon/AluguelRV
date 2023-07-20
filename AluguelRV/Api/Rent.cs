using AluguelRV.Api.Dapper.Data;
using AluguelRV.Domain;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api;

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

        return Api.Response(response);
    }

    public static async Task<IResult> GetRoomAmountByPerson(RentData rentData, int rentId, int personId)
    {
        var data = await rentData.GetRoomAmountByPerson(rentId, personId);

        return Api.CheckNullAndRespond(data);
    }

    public static async Task<IResult> GetPersonRent(ConfigData configData, RentData rentData, int rentId, int personId)
    {
        var response = new ResponseHandler();

        var data = await rentData.GetPersonRent(personId, rentId);
        var def = await configData.GetByKey("DEF_RENT");

        if (data.Any())
            response.Value = new PersonRentListViewModel
            {
                List = data,
                DefaultRent = !string.IsNullOrWhiteSpace(def) ? int.Parse(def) : 0
            };
        else
            response.SetAsNotFound();

        return Api.Response(response);
    }
}