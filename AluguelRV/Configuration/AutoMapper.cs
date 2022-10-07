using AluguelRV.Domain.Mapper;

namespace AluguelRV.Api.Configuration;

public static class AutoMapper
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(PersonProfile),
            typeof(RentProfile));

        return services;
    }
}
