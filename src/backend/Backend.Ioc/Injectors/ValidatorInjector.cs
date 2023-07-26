using Backend.Application.Validators.Autenticacao;
using Backend.Application.Validators.Usuarios;
using Backend.Application.Validators.Veiculos;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ValidatorInjector
{
    public static IServiceCollection AddRequestValidatorsInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<AdicionarUsuarioRequestValidator, AdicionarUsuarioRequestValidator>()
            .AddScoped<LoginRequestValidator, LoginRequestValidator>()
            .AddScoped<AdicionarVeiculoRequestValidator, AdicionarVeiculoRequestValidator>()
            .AddScoped<EditarVeiculoRequestValidator, EditarVeiculoRequestValidator>();
    }

    public static IServiceCollection AddModelValidatorsInjector(this IServiceCollection services)
    {
        return services;
    }
}