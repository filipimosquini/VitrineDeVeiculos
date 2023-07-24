using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ApplicationServiceInjector
{
    public static IServiceCollection AddApplicationServicesInjector(this IServiceCollection services)
    {
        return services;
    }
}