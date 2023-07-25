using Backend.Application.Validators.Autenticacao;
using Backend.Application.Validators.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ValidatorInjector
{
    public static IServiceCollection AddRequestValidatorsInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<AdicionarUsuarioRequestValidator, AdicionarUsuarioRequestValidator>()
            .AddScoped<LoginRequestValidator, LoginRequestValidator>();
    }

    public static IServiceCollection AddModelValidatorsInjector(this IServiceCollection services)
    {
        return services;
    }
}