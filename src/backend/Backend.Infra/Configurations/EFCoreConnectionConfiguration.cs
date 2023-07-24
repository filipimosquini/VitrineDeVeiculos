using Backend.Infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.Configurations;

public static class EFCoreConnectionConfiguration
{
    public static IServiceCollection AddDbContextInjector(this IServiceCollection services,
        IConfiguration configuration)
    {
        var sqlConnection = configuration.GetConnectionString("SqlConnection");
        services.AddDbContext<VitrineVeiculoContext>(options =>
        {
            options.UseSqlServer(sqlConnection);
        });

        return services;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<VitrineVeiculoContext>();

        if (context.MigrateDatabase()) return builder;

        context.Database.Migrate();

        return builder;
    }
}