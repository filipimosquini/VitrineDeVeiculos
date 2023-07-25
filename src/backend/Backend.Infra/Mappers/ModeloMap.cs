using Backend.Domain.Veiculos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Mappers;

public class ModeloMap : IEntityTypeConfiguration<Modelo>
{
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
        builder.ToTable("modelo");
        builder.HasKey(x => x.Id);

        builder.HasData(Seed());
    }

    private static ICollection<Modelo> Seed()
    {
        return new[]
        {   
            /* BMW */
            new Modelo {Id = Guid.Parse("a77a6e55-fe39-4268-bbdb-7db19dedd2b1"), Nome = "118I", MarcaId = Guid.Parse("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("e355f15c-9042-4636-af56-b9794f9f80bf"), Nome = "218I", MarcaId = Guid.Parse("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("3ac37a1f-1f0a-4ea0-96a0-f965815c16db"), Nome = "320I", MarcaId = Guid.Parse("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), IncluidoEm = new DateTime(2023, 7, 25) },

            /* Ford */
            new Modelo {Id = Guid.Parse("ac28f67b-4006-45fa-95be-51babbbeab29"), Nome = "Ranger", MarcaId = Guid.Parse("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("000068df-9c7a-4a27-a73e-550052e772d9"), Nome = "Maverick", MarcaId = Guid.Parse("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("58707ec2-c5cf-4d51-b4fe-ceef82f80d29"), Nome = "F-150", MarcaId = Guid.Parse("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), IncluidoEm = new DateTime(2023, 7, 25) },

            /* Honda */
            new Modelo {Id = Guid.Parse("611d04c6-9051-4f92-9aac-771b4d8433be"), Nome = "Accord", MarcaId = Guid.Parse("70321b20-8dff-486d-8dca-7532f0f88c74"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("68393066-89ec-4912-8610-86de367bfd8d"), Nome = "City", MarcaId = Guid.Parse("70321b20-8dff-486d-8dca-7532f0f88c74"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("bc127e40-1bdb-4410-93bd-6a1b03bfb869"), Nome = "Civic", MarcaId = Guid.Parse("70321b20-8dff-486d-8dca-7532f0f88c74"), IncluidoEm = new DateTime(2023, 7, 25) },

            /* Hyundai */
            new Modelo {Id = Guid.Parse("1e320469-46a9-4058-864d-5be70456fc89"), Nome = "HB20", MarcaId = Guid.Parse("2672316d-81b5-4037-8ac7-6158a3c17c20"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("8783192b-bf25-48e9-a519-17ec2696ff13"), Nome = "Creta", MarcaId = Guid.Parse("2672316d-81b5-4037-8ac7-6158a3c17c20"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("39639802-1b43-425e-b355-85e697158fd5"), Nome = "IX35", MarcaId = Guid.Parse("2672316d-81b5-4037-8ac7-6158a3c17c20"), IncluidoEm = new DateTime(2023, 7, 25) },

            /* Mercedes-Benz */
            new Modelo {Id = Guid.Parse("00af065a-3a10-4699-aed3-2ef68dbff35e"), Nome = "EQE Sedan", MarcaId = Guid.Parse("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("358a6955-4538-4e5f-8833-9140b9f3ae6c"), Nome = "EQA SUV", MarcaId = Guid.Parse("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("ecaf2310-a3f4-4226-b0a4-e644cd0b9ba5"), Nome = "EQC", MarcaId = Guid.Parse("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), IncluidoEm = new DateTime(2023, 7, 25) },

            /* Mitsubishi */
            new Modelo {Id = Guid.Parse("0337a152-df48-4ffa-8ab8-2710aaa92ac0"), Nome = "ASX", MarcaId = Guid.Parse("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("a6ab7649-5e32-4cf8-a276-70139a56ee3b"), Nome = "ECLIPSE CROSS", MarcaId = Guid.Parse("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("208d58b1-436d-4974-9906-02df71077266"), Nome = "L200 TRITON", MarcaId = Guid.Parse("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Porsche */
            new Modelo {Id = Guid.Parse("aa69f257-f75d-44a5-aa56-b740a41dddbb"), Nome = "Taycan", MarcaId = Guid.Parse("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("43850087-18f7-40f1-bc19-075770be5b3f"), Nome = "Panamera", MarcaId = Guid.Parse("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("e59c1d4a-a95a-4f78-8ea4-0e88410c58b0"), Nome = "Cayenne", MarcaId = Guid.Parse("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Chevrolet */
            new Modelo {Id = Guid.Parse("f647c31e-1ff8-498d-8aa2-cd400fba4624"), Nome = "Onix", MarcaId = Guid.Parse("b4d07db6-863d-4184-ada9-e106894b69a1"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("7c8f5fcd-5890-4381-9b3a-984dc43d8085"), Nome = "Tracker", MarcaId = Guid.Parse("b4d07db6-863d-4184-ada9-e106894b69a1"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("e9a8a9e1-2656-46e3-bfc1-965b2eed553b"), Nome = "Cruze", MarcaId = Guid.Parse("b4d07db6-863d-4184-ada9-e106894b69a1"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Fiat */
            new Modelo {Id = Guid.Parse("e99e44ca-ad2d-4705-8c8a-d6258155d58f"), Nome = "Argo", MarcaId = Guid.Parse("0da71c4b-9deb-4655-ae13-0512c7915a59"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("aec8dc25-6855-45a5-9547-0940fe7d4243"), Nome = "Cronos", MarcaId = Guid.Parse("0da71c4b-9deb-4655-ae13-0512c7915a59"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("52d73db3-39fa-411c-bbe5-eb596d291c28"), Nome = "Pulse", MarcaId = Guid.Parse("0da71c4b-9deb-4655-ae13-0512c7915a59"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Volkswagen */
            new Modelo {Id = Guid.Parse("ab994e1f-88ed-484f-9396-04d0fe506442"), Nome = "AMAROK", MarcaId = Guid.Parse("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("5c19c198-bca5-4262-9467-0e38ec87386b"), Nome = "FOX", MarcaId = Guid.Parse("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("a78c44fa-629a-4e85-956d-5307fd8e083e"), Nome = "GOL", MarcaId = Guid.Parse("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Renault */
            new Modelo {Id = Guid.Parse("24437f13-981e-404e-bfe2-437debb441a0"), Nome = "Captur", MarcaId = Guid.Parse("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("f670f914-a7a9-4551-93f7-a9b89e9c156c"), Nome = "Duster", MarcaId = Guid.Parse("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("706b7d33-bce0-4f11-982c-a8b9bb1caa4a"), Nome = "Logan", MarcaId = Guid.Parse("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Jeep */
            new Modelo {Id = Guid.Parse("d23db783-70a3-46e1-8a0b-2fb57da38491"), Nome = "Renegade", MarcaId = Guid.Parse("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("2e1922be-0164-4e53-b351-1ec65e085808"), Nome = "Compass", MarcaId = Guid.Parse("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("6c01fe12-65a4-4bf2-970f-9ffb0180d630"), Nome = "Commander", MarcaId = Guid.Parse("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), IncluidoEm = new DateTime(2023, 7, 25) },
            
            /* Toyota */
            new Modelo {Id = Guid.Parse("880ae743-a77a-4151-ae0a-d953ea9bd018"), Nome = "Corolla", MarcaId = Guid.Parse("532f4904-abd4-4416-af86-0b25dac9f8e5"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("e7291dd6-a3fb-4108-bd90-3fc582282f97"), Nome = "Etios", MarcaId = Guid.Parse("532f4904-abd4-4416-af86-0b25dac9f8e5"), IncluidoEm = new DateTime(2023, 7, 25) },
            new Modelo {Id = Guid.Parse("2dc0c735-0f5b-4ec7-88d0-6627a6fd50c0"), Nome = "Hilux", MarcaId = Guid.Parse("532f4904-abd4-4416-af86-0b25dac9f8e5"), IncluidoEm = new DateTime(2023, 7, 25) },
        };
    }
}