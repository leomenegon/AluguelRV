using AluguelRV.Api.Mapper;

namespace AluguelRV.Api.Configuration;

public static class AutoMapper
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(PersonProfile),
            typeof(ExpenseProfile),
            typeof(RentProfile));

        return services;
    }
}