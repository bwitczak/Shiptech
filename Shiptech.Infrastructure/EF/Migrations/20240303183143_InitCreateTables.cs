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
                    Orderer = table.Column<string>(type: "text", nullable: false)
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
                    DrawingRevision = table.Column<string>(type: "text", nullable: false),
                    Lot = table.Column<string>(type: "text", nullable: true),
                    Block = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
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
                    IsoRevision = table.Column<string>(type: "text", nullable: false),
                    System = table.Column<string>(type: "text", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: false),
                    Atest = table.Column<int>(type: "integer", nullable: true),
                    KzmNumber = table.Column<string>(type: "text", nullable: true),
                    KzmDate = table.Column<string>(type: "text", nullable: true),
                    DrawingId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isos", x => x.Id);
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
                    Position = table.Column<string>(type: "text", nullable: false),
                    DrawingLength = table.Column<int>(type: "integer", nullable: true),
                    Addition = table.Column<int>(type: "integer", nullable: true),
                    TechnologicalAddition = table.Column<int>(type: "integer", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    D15I = table.Column<int>(type: "integer", nullable: true),
                    D15II = table.Column<int>(type: "integer", nullable: true),
                    D1I = table.Column<int>(type: "integer", nullable: true),
                    D1II = table.Column<int>(type: "integer", nullable: true),
                    PrefabricationQuantity = table.Column<int>(type: "integer", nullable: false),
                    PrefabricationLength = table.Column<int>(type: "integer", nullable: false),
                    PrefabricationWeight = table.Column<double>(type: "double precision", nullable: false),
                    AssemblyQuantity = table.Column<int>(type: "integer", nullable: false),
                    AssemblyLength = table.Column<int>(type: "integer", nullable: false),
                    AssemblyWeight = table.Column<double>(type: "double precision", nullable: false),
                    IsoId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assortments_Isos_IsoId",
                        column: x => x.IsoId,
                        principalTable: "Isos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
