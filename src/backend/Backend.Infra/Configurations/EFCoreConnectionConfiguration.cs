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
        var mySqlConnection = configuration.GetConnectionString("MySqlConnection");
        services.AddDbContext<VitrineVeiculoContext>(options =>
        {
            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                x => x.MigrationsAssembly(typeof(VitrineVeiculoContext).Assembly.FullName));
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