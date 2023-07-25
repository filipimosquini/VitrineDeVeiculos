﻿// <auto-generated />
using System;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Infra.Migrations.VitrineVeiculo
{
    [DbContext(typeof(VitrineVeiculoContext))]
    partial class VitrineVeiculoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Marca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IncluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("marca", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "BMW"
                        },
                        new
                        {
                            Id = new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Ford"
                        },
                        new
                        {
                            Id = new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Honda"
                        },
                        new
                        {
                            Id = new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Hyundai"
                        },
                        new
                        {
                            Id = new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Mitsubishi"
                        },
                        new
                        {
                            Id = new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Porsche"
                        },
                        new
                        {
                            Id = new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Chevrolet"
                        },
                        new
                        {
                            Id = new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Fiat"
                        },
                        new
                        {
                            Id = new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Volkswagen"
                        },
                        new
                        {
                            Id = new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Renault"
                        },
                        new
                        {
                            Id = new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Jeep"
                        },
                        new
                        {
                            Id = new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Toyota"
                        });
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Modelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IncluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("MarcaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("modelo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a77a6e55-fe39-4268-bbdb-7db19dedd2b1"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"),
                            Nome = "118I"
                        },
                        new
                        {
                            Id = new Guid("e355f15c-9042-4636-af56-b9794f9f80bf"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"),
                            Nome = "218I"
                        },
                        new
                        {
                            Id = new Guid("3ac37a1f-1f0a-4ea0-96a0-f965815c16db"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"),
                            Nome = "320I"
                        },
                        new
                        {
                            Id = new Guid("ac28f67b-4006-45fa-95be-51babbbeab29"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"),
                            Nome = "Ranger"
                        },
                        new
                        {
                            Id = new Guid("000068df-9c7a-4a27-a73e-550052e772d9"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"),
                            Nome = "Maverick"
                        },
                        new
                        {
                            Id = new Guid("58707ec2-c5cf-4d51-b4fe-ceef82f80d29"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"),
                            Nome = "F-150"
                        },
                        new
                        {
                            Id = new Guid("611d04c6-9051-4f92-9aac-771b4d8433be"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"),
                            Nome = "Accord"
                        },
                        new
                        {
                            Id = new Guid("68393066-89ec-4912-8610-86de367bfd8d"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"),
                            Nome = "City"
                        },
                        new
                        {
                            Id = new Guid("bc127e40-1bdb-4410-93bd-6a1b03bfb869"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"),
                            Nome = "Civic"
                        },
                        new
                        {
                            Id = new Guid("1e320469-46a9-4058-864d-5be70456fc89"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"),
                            Nome = "HB20"
                        },
                        new
                        {
                            Id = new Guid("8783192b-bf25-48e9-a519-17ec2696ff13"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"),
                            Nome = "Creta"
                        },
                        new
                        {
                            Id = new Guid("39639802-1b43-425e-b355-85e697158fd5"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"),
                            Nome = "IX35"
                        },
                        new
                        {
                            Id = new Guid("00af065a-3a10-4699-aed3-2ef68dbff35e"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"),
                            Nome = "EQE Sedan"
                        },
                        new
                        {
                            Id = new Guid("358a6955-4538-4e5f-8833-9140b9f3ae6c"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"),
                            Nome = "EQA SUV"
                        },
                        new
                        {
                            Id = new Guid("ecaf2310-a3f4-4226-b0a4-e644cd0b9ba5"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"),
                            Nome = "EQC"
                        },
                        new
                        {
                            Id = new Guid("0337a152-df48-4ffa-8ab8-2710aaa92ac0"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"),
                            Nome = "ASX"
                        },
                        new
                        {
                            Id = new Guid("a6ab7649-5e32-4cf8-a276-70139a56ee3b"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"),
                            Nome = "ECLIPSE CROSS"
                        },
                        new
                        {
                            Id = new Guid("208d58b1-436d-4974-9906-02df71077266"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"),
                            Nome = "L200 TRITON"
                        },
                        new
                        {
                            Id = new Guid("aa69f257-f75d-44a5-aa56-b740a41dddbb"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"),
                            Nome = "Taycan"
                        },
                        new
                        {
                            Id = new Guid("43850087-18f7-40f1-bc19-075770be5b3f"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"),
                            Nome = "Panamera"
                        },
                        new
                        {
                            Id = new Guid("e59c1d4a-a95a-4f78-8ea4-0e88410c58b0"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"),
                            Nome = "Cayenne"
                        },
                        new
                        {
                            Id = new Guid("f647c31e-1ff8-498d-8aa2-cd400fba4624"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"),
                            Nome = "Onix"
                        },
                        new
                        {
                            Id = new Guid("7c8f5fcd-5890-4381-9b3a-984dc43d8085"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"),
                            Nome = "Tracker"
                        },
                        new
                        {
                            Id = new Guid("e9a8a9e1-2656-46e3-bfc1-965b2eed553b"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"),
                            Nome = "Cruze"
                        },
                        new
                        {
                            Id = new Guid("e99e44ca-ad2d-4705-8c8a-d6258155d58f"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"),
                            Nome = "Argo"
                        },
                        new
                        {
                            Id = new Guid("aec8dc25-6855-45a5-9547-0940fe7d4243"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"),
                            Nome = "Cronos"
                        },
                        new
                        {
                            Id = new Guid("52d73db3-39fa-411c-bbe5-eb596d291c28"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"),
                            Nome = "Pulse"
                        },
                        new
                        {
                            Id = new Guid("ab994e1f-88ed-484f-9396-04d0fe506442"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"),
                            Nome = "AMAROK"
                        },
                        new
                        {
                            Id = new Guid("5c19c198-bca5-4262-9467-0e38ec87386b"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"),
                            Nome = "FOX"
                        },
                        new
                        {
                            Id = new Guid("a78c44fa-629a-4e85-956d-5307fd8e083e"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"),
                            Nome = "GOL"
                        },
                        new
                        {
                            Id = new Guid("24437f13-981e-404e-bfe2-437debb441a0"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"),
                            Nome = "Captur"
                        },
                        new
                        {
                            Id = new Guid("f670f914-a7a9-4551-93f7-a9b89e9c156c"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"),
                            Nome = "Duster"
                        },
                        new
                        {
                            Id = new Guid("706b7d33-bce0-4f11-982c-a8b9bb1caa4a"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"),
                            Nome = "Logan"
                        },
                        new
                        {
                            Id = new Guid("d23db783-70a3-46e1-8a0b-2fb57da38491"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"),
                            Nome = "Renegade"
                        },
                        new
                        {
                            Id = new Guid("2e1922be-0164-4e53-b351-1ec65e085808"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"),
                            Nome = "Compass"
                        },
                        new
                        {
                            Id = new Guid("6c01fe12-65a4-4bf2-970f-9ffb0180d630"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"),
                            Nome = "Commander"
                        },
                        new
                        {
                            Id = new Guid("880ae743-a77a-4151-ae0a-d953ea9bd018"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"),
                            Nome = "Corolla"
                        },
                        new
                        {
                            Id = new Guid("e7291dd6-a3fb-4108-bd90-3fc582282f97"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"),
                            Nome = "Etios"
                        },
                        new
                        {
                            Id = new Guid("2dc0c735-0f5b-4ec7-88d0-6627a6fd50c0"),
                            IncluidoEm = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MarcaId = new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"),
                            Nome = "Hilux"
                        });
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ExcluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IncluidoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("MarcaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ModeloId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("veiculo", (string)null);
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Modelo", b =>
                {
                    b.HasOne("Backend.Domain.Veiculos.Entities.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Veiculo", b =>
                {
                    b.HasOne("Backend.Domain.Veiculos.Entities.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Backend.Domain.Veiculos.Entities.Modelo", "Modelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Marca");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Marca", b =>
                {
                    b.Navigation("Modelos");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("Backend.Domain.Veiculos.Entities.Modelo", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
