using Backend.Domain.Veiculos.Repositories;
using Backend.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class RepositoryInjector
{
    public static IServiceCollection AddRepositoriesInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IMarcaRepository, MarcaRepository>()
            .AddScoped<IModeloRepository, ModeloRepository>()
            .AddScoped<IVeiculoRepository, VeiculoRepository>();
    }
}