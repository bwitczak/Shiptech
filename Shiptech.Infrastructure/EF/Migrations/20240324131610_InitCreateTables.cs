using System;
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
            migrationBuilder.CreateTable(
                name: "AssortmentDictionary",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Distinguishing = table.Column<string>(type: "char(6)", nullable: false),
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
                    table.PrimaryKey("PK_AssortmentDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalProcesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ChemicalProcessName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Orderer = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    Lot = table.Column<string>(type: "char(3)", nullable: true),
                    Block = table.Column<string>(type: "char(3)", nullable: true),
                    Section = table.Column<string>(type: "char(4)", nullable: true),
                    Stage = table.Column<string>(type: "char(3)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Author = table.Column<string>(type: "varchar", nullable: false),
                    ShipId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawings_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Isos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    System = table.Column<string>(type: "varchar", nullable: false),
                    Class = table.Column<string>(type: "char(6)", nullable: false),
                    Atest = table.Column<string>(type: "varchar", nullable: true),
                    KzmNumber = table.Column<string>(type: "char(6)", nullable: true),
                    KzmDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DrawingId = table.Column<string>(type: "text", nullable: false),
                    ChemicalProcessId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Isos_ChemicalProcesses_ChemicalProcessId",
                        column: x => x.ChemicalProcessId,
                        principalTable: "ChemicalProcesses",
                        principalColumn: "Id",
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
                    Id = table.Column<string>(type: "text", nullable: false),
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
                    IsoId = table.Column<string>(type: "text", nullable: false),
                    AssortmentDictionaryId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assortments_AssortmentDictionary_AssortmentDictionaryId",
                        column: x => x.AssortmentDictionaryId,
                        principalTable: "AssortmentDictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assortments_Isos_IsoId",
                        column: x => x.IsoId,
                        principalTable: "Isos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_AssortmentDictionaryId",
                table: "Assortments",
                column: "AssortmentDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_IsoId",
                table: "Assortments",
                column: "IsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_ShipId",
                table: "Drawings",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Isos_ChemicalProcessId",
                table: "Isos",
                column: "ChemicalProcessId");

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
