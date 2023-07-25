using Backend.Domain.Veiculos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Mappers;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("veiculo");
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Marca)
            .WithMany(x => x.Veiculos)
            .HasForeignKey(x => x.MarcaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Modelo)
            .WithMany(x => x.Veiculos)
            .HasForeignKey(x => x.ModeloId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}