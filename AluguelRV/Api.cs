using AluguelRV.Domain;

namespace AluguelRV.Api;

public static class Api
{
    public static WebApplication ConfigureApi(this WebApplication app)
    {
        //Person
        app.MapGet("/person", Person.GetAll);
        app.MapGet("/person/{id}", Person.GetById);

        //Rent
        app.MapGet("/rent", Rent.GetAll);
        app.MapGet("/rent/room-amount/", Rent.GetRoomAmountByPerson);

        //Expense
        app.MapGet("/expense", Expense.GetAll);
        app.MapGet("/expense/{id}", Expense.GetById);
        app.MapGet("/expense/person", Expense.GetByPerson);
        app.MapGet("/expense/rent", Expense.GetByRent);

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