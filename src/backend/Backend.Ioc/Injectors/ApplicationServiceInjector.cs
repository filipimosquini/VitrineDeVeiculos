using Backend.Application.ApplicationServices.Autenticacao;
using Backend.Application.ApplicationServices.Usuarios;
using Backend.Domain.Autenticacao.ApplicationServices;
using Backend.Domain.Usuarios.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ApplicationServiceInjector
{
    public static IServiceCollection AddApplicationServicesInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IUsuarioApplicationService, UsuarioApplicationService>()
            .AddScoped<IAutenticacaoApplicationService, AutenticacaoApplicationService>();
    }
}