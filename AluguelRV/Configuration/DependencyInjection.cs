using AluguelRV.Api.Dapper.Data;
using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Core.Data;
using AluguelRV.Core.Interfaces.Repositories;
using AluguelRV.Core.Services;

namespace AluguelRV.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<DataAccess>();

        services.AddTransient(typeof(IBaseRepository<>), typeof(Repository<>));

        services.AddScoped<ConfigData>();

        services.AddScoped<UserData>();
        services.AddScoped<UserService>();

        services.AddScoped<PersonData>();
        services.AddScoped<PersonService>();

        services.AddScoped<RentData>();
        services.AddScoped<RentService>();

        services.AddScoped<ExpenseData>();
        services.AddScoped<ExpenseService>();

        return services;
    }
}