using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shiptech.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitCreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "AssortmentDictionary",
                columns: table => new
                {
                    Number = table.Column<string>(type: "varchar", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Distinguishing = table.Column<string>(type: "char(22)", nullable: false),
                    Unit = table.Column<string>(type: "char(4)", nullable: false),
                    Amount = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    Weight = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    Material = table.Column<string>(type: "varchar", nullable: true),
                    Kind = table.Column<string>(type: "varchar", nullable: true),
                    Length = table.Column<short>(type: "smallint", nullable: true),
                    RO = table.Column<string>(type: "varchar", nullable: false),
                    Comment = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssortmentDictionary", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalProcesses",
                columns: table => new
                {
                    ChemicalProcessCode = table.Column<string>(type: "varchar", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ChemicalProcessName = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalProcesses", x => x.ChemicalProcessCode);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Orderer = table.Column<string>(type: "varchar", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Orderer);
                });

            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    Lot = table.Column<string>(type: "char(3)", nullable: true),
                    Block = table.Column<string>(type: "char(3)", nullable: true),
                    Section = table.Column<List<string>>(type: "text[]", nullable: true),
                    Stage = table.Column<string>(type: "char(3)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Author = table.Column<string>(type: "varchar", nullable: false),
                    ShipOrderer = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawings_Ships_ShipOrderer",
                        column: x => x.ShipOrderer,
                        principalTable: "Ships",
                        principalColumn: "Orderer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Isos",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    System = table.Column<string>(type: "varchar", nullable: false),
                    Class = table.Column<string>(type: "char(6)", nullable: false),
                    Atest = table.Column<string>(type: "varchar", nullable: true),
                    KzmNumber = table.Column<string>(type: "char(6)", nullable: true),
                    KzmDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DrawingId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChemicalProcessCode = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isos", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Isos_ChemicalProcesses_ChemicalProcessCode",
                        column: x => x.ChemicalProcessCode,
                        principalTable: "ChemicalProcesses",
                        principalColumn: "ChemicalProcessCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Isos_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assortments",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Position = table.Column<char>(type: "char(1)", nullable: false),
                    DrawingLength = table.Column<short>(type: "smallint", nullable: true),
                    Addition = table.Column<short>(type: "smallint", nullable: true),
                    TechnologicalAddition = table.Column<short>(type: "smallint", nullable: true),
                    Stage = table.Column<string>(type: "char(1)", nullable: true),
                    Comment = table.Column<string>(type: "varchar", nullable: true),
                    D15I = table.Column<short>(type: "smallint", nullable: true),
                    D15II = table.Column<short>(type: "smallint", nullable: true),
                    D1I = table.Column<short>(type: "smallint", nullable: true),
                    D1II = table.Column<short>(type: "smallint", nullable: true),
                    PrefabricationQuantity = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationLength = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationWeight = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    AssemblyQuantity = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyLength = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyWeight = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    IsoName = table.Column<string>(type: "varchar", nullable: false),
                    AssortmentDictionaryNumber = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Assortments_AssortmentDictionary_AssortmentDictionaryNumber",
                        column: x => x.AssortmentDictionaryNumber,
                        principalTable: "AssortmentDictionary",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assortments_Isos_IsoName",
                        column: x => x.IsoName,
                        principalTable: "Isos",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_AssortmentDictionaryNumber",
                table: "Assortments",
                column: "AssortmentDictionaryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_IsoName",
                table: "Assortments",
                column: "IsoName");

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_ShipOrderer",
                table: "Drawings",
                column: "ShipOrderer");

            migrationBuilder.CreateIndex(
                name: "IX_Isos_ChemicalProcessCode",
                table: "Isos",
                column: "ChemicalProcessCode");

            migrationBuilder.CreateIndex(
                name: "IX_Isos_DrawingId",
                table: "Isos",
                column: "DrawingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assortments");

            migrationBuilder.DropTable(
                name: "AssortmentDictionary");

            migrationBuilder.DropTable(
                name: "Isos");

            migrationBuilder.DropTable(
                name: "ChemicalProcesses");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
