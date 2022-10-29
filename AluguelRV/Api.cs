namespace AluguelRV.Api;

public static partial class Api
{
    public static WebApplication ConfigureApi(this WebApplication app)
    {
        //User
        app.MapPost("/login", User.Login);
        app.MapPost("/user/register", User.Register);

        //Person
        app.MapGet("/person", Person.GetAll);
        app.MapGet("/person/{id}", Person.GetById);

        //Rent
        app.MapGet("/rent", Rent.GetAll);
        app.MapGet("/rent/room-amount/", Rent.GetRoomAmountByPerson);
        app.MapGet("/rent/individual", Rent.GetPersonRent);

        //Expense
        app.MapGet("/expense", Expense.GetAll);
        app.MapGet("/expense/{id}", Expense.GetById);
        app.MapGet("/expense/{id}/details", Expense.GetDetails);
        app.MapGet("/expense/person", Expense.GetByPerson);
        app.MapGet("/expense/rent", Expense.GetByRent);
        app.MapPost("/expense", Expense.Create);

        return app;
    }
}