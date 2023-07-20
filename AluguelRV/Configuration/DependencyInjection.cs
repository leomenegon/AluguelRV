using AluguelRV.Api.Dapper.Data;
using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.Services;

namespace AluguelRV.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<DataAccess>();

        services.AddScoped<ConfigData>();

        services.AddScoped<UserData>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<PersonData>();
        services.AddScoped<IPersonService, PersonService>();

        services.AddScoped<RentData>();
        services.AddScoped<IRentService, RentService>();

        services.AddScoped<ExpenseData>();
        services.AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}
