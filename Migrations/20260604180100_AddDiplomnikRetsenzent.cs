using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddDiplomnikRetsenzent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Otsenka",
                table: "Diplomnik",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VidVkr",
                table: "Diplomnik",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiplomnikRetsenzent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DiplomnikId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomnikRetsenzent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomnikRetsenzent_Diplomnik_DiplomnikId",
                        column: x => x.DiplomnikId,
                        principalTable: "Diplomnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomnikRetsenzent_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiplomnikRetsenzent_DiplomnikId",
                table: "DiplomnikRetsenzent",
                column: "DiplomnikId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomnikRetsenzent_PersonId",
                table: "DiplomnikRetsenzent",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiplomnikRetsenzent");

            migrationBuilder.DropColumn(
                name: "Otsenka",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "VidVkr",
                table: "Diplomnik");
        }
    }
}
