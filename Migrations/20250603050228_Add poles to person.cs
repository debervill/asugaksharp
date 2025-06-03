using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class Addpolestoperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KafedraID",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Person_KafedraID",
                table: "Person",
                column: "KafedraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person",
                column: "KafedraID",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_KafedraID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "KafedraID",
                table: "Person");
        }
    }
}
