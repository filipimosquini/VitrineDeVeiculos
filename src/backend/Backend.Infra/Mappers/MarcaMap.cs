using Backend.Domain.Veiculos.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Mappers;

public class MarcaMap : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("marca");
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Modelos)
            .WithOne(x => x.Marca)
            .HasForeignKey(x => x.MarcaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(Seed());
    }

    private static ICollection<Marca> Seed()
    {
        return new[]
        {
            new Marca { Id = Guid.Parse("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), Nome = "BMW", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), Nome = "Ford", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("70321b20-8dff-486d-8dca-7532f0f88c74"), Nome = "Honda", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("2672316d-81b5-4037-8ac7-6158a3c17c20"), Nome = "Hyundai", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), Nome = "Mercedes-Benz", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), Nome = "Mitsubishi", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), Nome = "Porsche", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("b4d07db6-863d-4184-ada9-e106894b69a1"), Nome = "Chevrolet", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("0da71c4b-9deb-4655-ae13-0512c7915a59"), Nome = "Fiat", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), Nome = "Volkswagen", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), Nome = "Renault", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), Nome = "Jeep", IncluidoEm = new DateTime(2023, 7, 25)},
            new Marca { Id = Guid.Parse("532f4904-abd4-4416-af86-0b25dac9f8e5"), Nome = "Toyota", IncluidoEm = new DateTime(2023, 7, 25)},
        };
    }
}