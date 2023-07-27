using Backend.Application.Services.Autenticacao;
using Backend.Application.Services.Geral;
using Backend.Domain.Autenticacao.Services;
using Backend.Domain.Geral;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ServiceInjector
{
    public static IServiceCollection AddServicesInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IAutenticacaoService, AutenticacaoService>()
            .AddScoped<IUploadArquivoService, UploadArquivoService>();
    }
}