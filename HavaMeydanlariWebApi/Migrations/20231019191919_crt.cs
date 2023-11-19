using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HavaMeydanlariWebApi.Migrations
{
    public partial class crt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmalars",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaBütcesi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirmaMerkezi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalars", x => x.FirmaId);
                });

            migrationBuilder.CreateTable(
                name: "HavaLimanlars",
                columns: table => new
                {
                    HavaLimaniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yerleskesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YolcuKapasitesi = table.Column<int>(type: "int", nullable: false),
                    PistSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HavaLimanlars", x => x.HavaLimaniId);
                });

            migrationBuilder.CreateTable(
                name: "Ucaklars",
                columns: table => new
                {
                    UcakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakRengi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UcakTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YolcuKapasitesi = table.Column<int>(type: "int", nullable: false),
                    UcakGenislik = table.Column<int>(type: "int", nullable: false),
                    BiletFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucaklars", x => x.UcakId);
                    table.ForeignKey(
                        name: "FK_Ucaklars_Firmalars_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalars",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personellers",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    CalismaTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vardiya = table.Column<bool>(type: "bit", nullable: false),
                    UcakId = table.Column<int>(type: "int", nullable: false),
                    HavaLimaniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personellers", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personellers_HavaLimanlars_HavaLimaniId",
                        column: x => x.HavaLimaniId,
                        principalTable: "HavaLimanlars",
                        principalColumn: "HavaLimaniId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personellers_Ucaklars_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklars",
                        principalColumn: "UcakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personellers_HavaLimaniId",
                table: "Personellers",
                column: "HavaLimaniId");

            migrationBuilder.CreateIndex(
                name: "IX_Personellers_UcakId",
                table: "Personellers",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Ucaklars_FirmaId",
                table: "Ucaklars",
                column: "FirmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personellers");

            migrationBuilder.DropTable(
                name: "HavaLimanlars");

            migrationBuilder.DropTable(
                name: "Ucaklars");

            migrationBuilder.DropTable(
                name: "Firmalars");
        }
    }
}
