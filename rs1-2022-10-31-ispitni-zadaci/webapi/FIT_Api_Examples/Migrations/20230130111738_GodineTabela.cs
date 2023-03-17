using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class GodineTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpisaneGodine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    godina = table.Column<int>(type: "int", nullable: false),
                    datum_upisa_zimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datum_ovjere_zimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cijena_skolarine = table.Column<float>(type: "real", nullable: false),
                    obnova = table.Column<bool>(type: "bit", nullable: false),
                    napomena_za_ovjeru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akademska_godina_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    evidentirao_korisnik_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisaneGodine", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisaneGodine_AkademskaGodina_akademska_godina_id",
                        column: x => x.akademska_godina_id,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisaneGodine_KorisnickiNalog_evidentirao_korisnik_id",
                        column: x => x.evidentirao_korisnik_id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisaneGodine_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpisaneGodine_akademska_godina_id",
                table: "UpisaneGodine",
                column: "akademska_godina_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisaneGodine_evidentirao_korisnik_id",
                table: "UpisaneGodine",
                column: "evidentirao_korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisaneGodine_student_id",
                table: "UpisaneGodine",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpisaneGodine");
        }
    }
}
