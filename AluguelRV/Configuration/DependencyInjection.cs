using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.Services;
using AluguelRV.Repository.Data;
using AluguelRV.Repository.DbAccess;

namespace AluguelRV.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IDataAccess, DataAccess>();

        services.AddScoped<IPersonData, PersonData>();
        services.AddScoped<IPersonService, PersonService>();


        services.AddScoped<IRentData, RentData>();
        services.AddScoped<IRentService, RentService>();

        return services;
    }
}
