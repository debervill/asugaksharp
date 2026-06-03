using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddDiplomnikProfilAndKonsultant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilPodgotovkiId",
                table: "Diplomnik",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiplomnikKonsultant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DiplomnikId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomnikKonsultant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomnikKonsultant_Diplomnik_DiplomnikId",
                        column: x => x.DiplomnikId,
                        principalTable: "Diplomnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomnikKonsultant_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_ProfilPodgotovkiId",
                table: "Diplomnik",
                column: "ProfilPodgotovkiId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomnikKonsultant_DiplomnikId",
                table: "DiplomnikKonsultant",
                column: "DiplomnikId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomnikKonsultant_PersonId",
                table: "DiplomnikKonsultant",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomnik_ProfilPodgotovki_ProfilPodgotovkiId",
                table: "Diplomnik",
                column: "ProfilPodgotovkiId",
                principalTable: "ProfilPodgotovki",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomnik_ProfilPodgotovki_ProfilPodgotovkiId",
                table: "Diplomnik");

            migrationBuilder.DropTable(
                name: "DiplomnikKonsultant");

            migrationBuilder.DropIndex(
                name: "IX_Diplomnik_ProfilPodgotovkiId",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "ProfilPodgotovkiId",
                table: "Diplomnik");
        }
    }
}
