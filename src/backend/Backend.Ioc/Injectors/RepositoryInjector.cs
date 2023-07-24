using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class RepositoryInjector
{
    public static IServiceCollection AddRepositoriesInjector(this IServiceCollection services)
    {
        return services;
    }
}