using Backend.Application.Services.Autenticacao;
using Backend.Domain.Autenticacao.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ServiceInjector
{
    public static IServiceCollection AddServicesInjector(this IServiceCollection services)
    {
        return services.AddScoped<IAutenticacaoService, AutenticacaoService>();
    }
}