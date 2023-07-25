using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infra.Migrations.VitrineVeiculo
{
    /// <inheritdoc />
    public partial class InitialDatabaseConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IncluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IncluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modelo_marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Imagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModeloId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IncluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veiculo_marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_veiculo_modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "marca",
                columns: new[] { "Id", "AtualizadoEm", "ExcluidoEm", "IncluidoEm", "Nome" },
                values: new object[,]
                {
                    { new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiat" },
                    { new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford" },
                    { new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyundai" },
                    { new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeep" },
                    { new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz" },
                    { new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota" },
                    { new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volkswagen" },
                    { new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda" },
                    { new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renault" },
                    { new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet" },
                    { new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Porsche" },
                    { new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mitsubishi" },
                    { new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW" }
                });

            migrationBuilder.InsertData(
                table: "modelo",
                columns: new[] { "Id", "AtualizadoEm", "ExcluidoEm", "IncluidoEm", "MarcaId", "Nome" },
                values: new object[,]
                {
                    { new Guid("000068df-9c7a-4a27-a73e-550052e772d9"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), "Maverick" },
                    { new Guid("00af065a-3a10-4699-aed3-2ef68dbff35e"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), "EQE Sedan" },
                    { new Guid("0337a152-df48-4ffa-8ab8-2710aaa92ac0"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), "ASX" },
                    { new Guid("1e320469-46a9-4058-864d-5be70456fc89"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"), "HB20" },
                    { new Guid("208d58b1-436d-4974-9906-02df71077266"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), "L200 TRITON" },
                    { new Guid("24437f13-981e-404e-bfe2-437debb441a0"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), "Captur" },
                    { new Guid("2dc0c735-0f5b-4ec7-88d0-6627a6fd50c0"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"), "Hilux" },
                    { new Guid("2e1922be-0164-4e53-b351-1ec65e085808"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), "Compass" },
                    { new Guid("358a6955-4538-4e5f-8833-9140b9f3ae6c"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), "EQA SUV" },
                    { new Guid("39639802-1b43-425e-b355-85e697158fd5"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"), "IX35" },
                    { new Guid("3ac37a1f-1f0a-4ea0-96a0-f965815c16db"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), "320I" },
                    { new Guid("43850087-18f7-40f1-bc19-075770be5b3f"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), "Panamera" },
                    { new Guid("52d73db3-39fa-411c-bbe5-eb596d291c28"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"), "Pulse" },
                    { new Guid("58707ec2-c5cf-4d51-b4fe-ceef82f80d29"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), "F-150" },
                    { new Guid("5c19c198-bca5-4262-9467-0e38ec87386b"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), "FOX" },
                    { new Guid("611d04c6-9051-4f92-9aac-771b4d8433be"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"), "Accord" },
                    { new Guid("68393066-89ec-4912-8610-86de367bfd8d"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"), "City" },
                    { new Guid("6c01fe12-65a4-4bf2-970f-9ffb0180d630"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), "Commander" },
                    { new Guid("706b7d33-bce0-4f11-982c-a8b9bb1caa4a"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), "Logan" },
                    { new Guid("7c8f5fcd-5890-4381-9b3a-984dc43d8085"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"), "Tracker" },
                    { new Guid("8783192b-bf25-48e9-a519-17ec2696ff13"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2672316d-81b5-4037-8ac7-6158a3c17c20"), "Creta" },
                    { new Guid("880ae743-a77a-4151-ae0a-d953ea9bd018"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"), "Corolla" },
                    { new Guid("a6ab7649-5e32-4cf8-a276-70139a56ee3b"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc81c86a-c3da-4cc6-9c18-b8fcb5de8333"), "ECLIPSE CROSS" },
                    { new Guid("a77a6e55-fe39-4268-bbdb-7db19dedd2b1"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), "118I" },
                    { new Guid("a78c44fa-629a-4e85-956d-5307fd8e083e"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), "GOL" },
                    { new Guid("aa69f257-f75d-44a5-aa56-b740a41dddbb"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), "Taycan" },
                    { new Guid("ab994e1f-88ed-484f-9396-04d0fe506442"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f460b87-529c-4dfb-ae42-85f4bb7c442e"), "AMAROK" },
                    { new Guid("ac28f67b-4006-45fa-95be-51babbbeab29"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e1b957a-c9f0-4a04-b4e2-86f6a60733ad"), "Ranger" },
                    { new Guid("aec8dc25-6855-45a5-9547-0940fe7d4243"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"), "Cronos" },
                    { new Guid("bc127e40-1bdb-4410-93bd-6a1b03bfb869"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70321b20-8dff-486d-8dca-7532f0f88c74"), "Civic" },
                    { new Guid("d23db783-70a3-46e1-8a0b-2fb57da38491"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c8853e5-2d7f-4018-9fca-bfe502bf21d7"), "Renegade" },
                    { new Guid("e355f15c-9042-4636-af56-b9794f9f80bf"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dd0b1dc4-d606-41a4-9ce9-eae2f64ae705"), "218I" },
                    { new Guid("e59c1d4a-a95a-4f78-8ea4-0e88410c58b0"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be19eb2d-6a03-4cbe-9b25-b1c479daadf4"), "Cayenne" },
                    { new Guid("e7291dd6-a3fb-4108-bd90-3fc582282f97"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("532f4904-abd4-4416-af86-0b25dac9f8e5"), "Etios" },
                    { new Guid("e99e44ca-ad2d-4705-8c8a-d6258155d58f"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0da71c4b-9deb-4655-ae13-0512c7915a59"), "Argo" },
                    { new Guid("e9a8a9e1-2656-46e3-bfc1-965b2eed553b"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"), "Cruze" },
                    { new Guid("ecaf2310-a3f4-4226-b0a4-e644cd0b9ba5"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d9c9554-a6c4-46fb-965f-25d4a2fdc727"), "EQC" },
                    { new Guid("f647c31e-1ff8-498d-8aa2-cd400fba4624"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b4d07db6-863d-4184-ada9-e106894b69a1"), "Onix" },
                    { new Guid("f670f914-a7a9-4551-93f7-a9b89e9c156c"), null, null, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74fea4b0-7c1f-4493-8aaf-e0bc99ec80e5"), "Duster" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_modelo_MarcaId",
                table: "modelo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_MarcaId",
                table: "veiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ModeloId",
                table: "veiculo",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}
