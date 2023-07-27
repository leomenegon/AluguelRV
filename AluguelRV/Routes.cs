namespace AluguelRV.Api;

public static partial class WebApi
{
    public static WebApplication ConfigureApi(this WebApplication app)
    {
        //User
        app.MapPost("api/login", Api.User.Login);
        app.MapPost("api/user/register", Api.User.Register);
        app.MapPost("api/user/change-password", Api.User.ChangePassword);

        //Person
        app.MapGet("api/person", Api.Person.GetAll);
        app.MapGet("api/person/{id}", Api.Person.GetById);

        //Rent
        app.MapGet("api/rent", Api.Rent.GetAll);
        app.MapGet("api/rent/room-amount", Api.Rent.GetRoomAmountByPerson);
        app.MapGet("api/rent/individual", Api.Rent.GetPersonRent);

        //Expense
        app.MapGet("api/expense", Api.Expense.GetAll);
        app.MapGet("api/expense/{id}", Api.Expense.GetById);
        app.MapGet("api/expense/{id}/details", Api.Expense.GetDetails);
        app.MapGet("api/expense/person", Api.Expense.GetByPerson);
        app.MapGet("api/expense/rent", Api.Expense.GetByRent);
        app.MapPost("api/expense", Api.Expense.Create);

        return app;
    }
}