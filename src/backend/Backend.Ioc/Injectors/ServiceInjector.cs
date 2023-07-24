using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ServiceInjector
{
    public static IServiceCollection AddServicesInjector(this IServiceCollection services)
    {
        return services;
    }
}