using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class addlinkkafperiodZased : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KafedraId",
                table: "PeriodZasedania",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PeriodZasedania_KafedraId",
                table: "PeriodZasedania",
                column: "KafedraId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodZasedania_Kafedra_KafedraId",
                table: "PeriodZasedania",
                column: "KafedraId",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodZasedania_Kafedra_KafedraId",
                table: "PeriodZasedania");

            migrationBuilder.DropIndex(
                name: "IX_PeriodZasedania_KafedraId",
                table: "PeriodZasedania");

            migrationBuilder.DropColumn(
                name: "KafedraId",
                table: "PeriodZasedania");
        }
    }
}
