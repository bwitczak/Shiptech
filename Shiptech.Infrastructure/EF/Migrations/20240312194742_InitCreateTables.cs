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
                name: "ChemicalProcesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ChemicalProcessName = table.Column<string>(type: "varchar", nullable: false)
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
                    ShipId = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "varchar", nullable: false),
                    Block = table.Column<string>(type: "char(3)", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    Lot = table.Column<string>(type: "char(3)", nullable: false),
                    Section = table.Column<string>(type: "char(4)", nullable: false),
                    Stage = table.Column<string>(type: "char(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawings_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Isos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrawingId = table.Column<string>(type: "text", nullable: true),
                    Atest = table.Column<string>(type: "varchar", nullable: false),
                    Class = table.Column<string>(type: "char(6)", nullable: false),
                    DrawingRevision = table.Column<char>(type: "char(1)", nullable: false),
                    KzmDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    KzmNumber = table.Column<string>(type: "char(6)", nullable: false),
                    System = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Isos_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assortments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsoId = table.Column<string>(type: "text", nullable: true),
                    Addition = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyLength = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyQuantity = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyWeight = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    D15I = table.Column<short>(type: "smallint", nullable: false),
                    D15II = table.Column<short>(type: "smallint", nullable: false),
                    D1I = table.Column<short>(type: "smallint", nullable: false),
                    D1II = table.Column<short>(type: "smallint", nullable: false),
                    DrawingLength = table.Column<short>(type: "smallint", nullable: false),
                    Position = table.Column<char>(type: "char(1)", nullable: false),
                    PrefabricationLength = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationQuantity = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationWeight = table.Column<double>(type: "numeric(5,3)", nullable: false),
                    Stage = table.Column<char>(type: "char(1)", nullable: false),
                    TechnologicalAddition = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assortments_Isos_IsoId",
                        column: x => x.IsoId,
                        principalTable: "Isos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_IsoId",
                table: "Assortments",
                column: "IsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_ShipId",
                table: "Drawings",
                column: "ShipId");

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
                name: "ChemicalProcesses");

            migrationBuilder.DropTable(
                name: "Isos");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
