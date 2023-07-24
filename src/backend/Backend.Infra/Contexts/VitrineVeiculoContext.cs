using Backend.Domain.Bases.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Infra.Contexts;

public class VitrineVeiculoContext : DbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration;

    public VitrineVeiculoContext(DbContextOptions<VitrineVeiculoContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VitrineVeiculoContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        if (await base.SaveChangesAsync() <= 0)
            return false;

        return true;
    }

    public bool DatabaseExists()
    {
        try
        {
            return Database.GetService<IRelationalDatabaseCreator>().Exists();
        }
        catch (DbException)
        {
            return false;
        }
    }

    public bool MigrateDatabase()
    {
        var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
            .GetAppliedMigrations()
            .Select(m => m.MigrationId);

        var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
            .Migrations
            .Select(m => m.Key);

        return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
    }
}