using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace Shiptech.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssortmentDictionary",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Number = table.Column<string>(type: "varchar", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Distinguishing = table.Column<string>(type: "varchar", nullable: true),
                    Unit = table.Column<string>(type: "varchar(4)", nullable: false),
                    Amount = table.Column<double>(type: "numeric(8,3)", nullable: true),
                    Weight = table.Column<double>(type: "numeric(8,3)", nullable: true),
                    Material = table.Column<string>(type: "varchar", nullable: true),
                    Kind = table.Column<string>(type: "varchar", nullable: true),
                    DN1 = table.Column<string>(type: "varchar", nullable: true),
                    DN2 = table.Column<string>(type: "varchar", nullable: true),
                    Length = table.Column<short>(type: "smallint", nullable: true),
                    RA = table.Column<string>(type: "varchar", nullable: true),
                    NS = table.Column<string>(type: "varchar", nullable: true),
                    Comment = table.Column<string>(type: "varchar", nullable: true),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                        .Annotation("Npgsql:TsVectorConfig", "english")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "Number", "Name" })
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssortmentDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalProcesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    ChemicalProcessCode = table.Column<string>(type: "varchar", nullable: false),
                    ChemicalProcessName = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipowners",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Orderer = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipowners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Code = table.Column<string>(type: "varchar", nullable: false),
                    ShipownerId = table.Column<string>(type: "varchar(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Shipowners_ShipownerId",
                        column: x => x.ShipownerId,
                        principalTable: "Shipowners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Number = table.Column<string>(type: "varchar", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Revision = table.Column<string>(type: "varchar(2)", nullable: false),
                    Lot = table.Column<string>(type: "varchar(3)", nullable: true),
                    Block = table.Column<string>(type: "varchar(3)", nullable: true),
                    Section = table.Column<string[]>(type: "text[]", nullable: true),
                    Stage = table.Column<string>(type: "varchar(3)", nullable: true),
                    ShipId = table.Column<string>(type: "varchar(26)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Author = table.Column<string>(type: "varchar", nullable: false)
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
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Number = table.Column<string>(type: "varchar", nullable: false),
                    Nameplate = table.Column<string>(type: "varchar", nullable: false),
                    Revision = table.Column<string>(type: "varchar(2)", nullable: false),
                    System = table.Column<string>(type: "varchar", nullable: false),
                    Class = table.Column<string>(type: "varchar(6)", nullable: false),
                    Atest = table.Column<string>(type: "varchar", nullable: true),
                    KzmNumber = table.Column<string>(type: "varchar(6)", nullable: true),
                    KzmDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DrawingId = table.Column<string>(type: "varchar(26)", nullable: true),
                    ChemicalProcessId = table.Column<string>(type: "varchar(26)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Author = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Isos_ChemicalProcesses_ChemicalProcessId",
                        column: x => x.ChemicalProcessId,
                        principalTable: "ChemicalProcesses",
                        principalColumn: "Id");
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
                    Id = table.Column<string>(type: "varchar(26)", nullable: false),
                    Position = table.Column<string>(type: "varchar(1)", nullable: false),
                    PrefabricationQuantity = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationLength = table.Column<short>(type: "smallint", nullable: false),
                    PrefabricationWeight = table.Column<double>(type: "numeric(8,3)", nullable: false),
                    AssemblyQuantity = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyLength = table.Column<short>(type: "smallint", nullable: false),
                    AssemblyWeight = table.Column<double>(type: "numeric(8,3)", nullable: false),
                    PG = table.Column<string>(type: "varchar(1)", nullable: false),
                    ValveNumber = table.Column<string>(type: "varchar", nullable: true),
                    CutAngle = table.Column<string>(type: "varchar", nullable: true),
                    Comment = table.Column<string>(type: "varchar", nullable: true),
                    IsoId = table.Column<string>(type: "varchar(26)", nullable: true),
                    AssortmentDictionaryId = table.Column<string>(type: "varchar(26)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Author = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assortments_AssortmentDictionary_AssortmentDictionaryId",
                        column: x => x.AssortmentDictionaryId,
                        principalTable: "AssortmentDictionary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assortments_Isos_IsoId",
                        column: x => x.IsoId,
                        principalTable: "Isos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssortmentDictionary_SearchVector",
                table: "AssortmentDictionary",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_AssortmentDictionaryId",
                table: "Assortments",
                column: "AssortmentDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assortments_IsoId",
                table: "Assortments",
                column: "IsoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalProcesses_ChemicalProcessName",
                table: "ChemicalProcesses",
                column: "ChemicalProcessName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_Number",
                table: "Drawings",
                column: "Number",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipownerId",
                table: "Ships",
                column: "ShipownerId");
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

            migrationBuilder.DropTable(
                name: "Shipowners");
        }
    }
}
