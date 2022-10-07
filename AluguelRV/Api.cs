using AluguelRV.Domain;

namespace AluguelRV.Api;

public static class Api
{
    public static WebApplication ConfigureApi(this WebApplication app)
    {
        //Person
        app.MapGet("/person", PersonApi.GetAll);
        app.MapGet("/person/{id}", PersonApi.GetById);

        //Rent
        app.MapGet("/rent", RentApi.GetAll);
        app.MapGet("/rent/{rentId}/room-amount/{personId}", RentApi.GetRoomAmountByPerson);

        return app;
    }

    public static IResult Response(ResponseHandler response) => response.GetStatus() switch
    {
        ResponseStatus.Ok => Results.Ok(response),
        ResponseStatus.Created => Results.Created(response.Message, response.Value),
        ResponseStatus.BadRequest => Results.BadRequest(response),
        ResponseStatus.Unauthorized => Results.Unauthorized(),
        ResponseStatus.NotFound => Results.NotFound(response),
        ResponseStatus.InternalError => Results.Problem(),
        _ => Results.NoContent()
    };
}