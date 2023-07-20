namespace AluguelRV.Api;

public static partial class Api
{
    public static WebApplication ConfigureApi(this WebApplication app)
    {
        //User
        app.MapPost("api/login", User.Login);
        //app.MapPost("api/user/register", User.Register);

        //Person
        app.MapGet("api/person", Person.GetAll);
        app.MapGet("api/person/{id}", Person.GetById);

        //Rent
        app.MapGet("api/rent", Rent.GetAll);
        app.MapGet("api/rent/room-amount/", Rent.GetRoomAmountByPerson);
        app.MapGet("api/rent/individual", Rent.GetPersonRent);

        //Expense
        app.MapGet("api/expense", Expense.GetAll);
        app.MapGet("api/expense/{id}", Expense.GetById);
        app.MapGet("api/expense/{id}/details", Expense.GetDetails);
        app.MapGet("api/expense/person", Expense.GetByPerson);
        app.MapGet("api/expense/rent", Expense.GetByRent);
        //app.MapPost("api/expense", Expense.Create);

        return app;
    }
}