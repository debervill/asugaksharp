using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddKomissiyaToGak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PredsedatelId",
                table: "Gak",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SekretarId",
                table: "Gak",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gak_PredsedatelId",
                table: "Gak",
                column: "PredsedatelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gak_SekretarId",
                table: "Gak",
                column: "SekretarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_Person_PredsedatelId",
                table: "Gak",
                column: "PredsedatelId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_Person_SekretarId",
                table: "Gak",
                column: "SekretarId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gak_Person_PredsedatelId",
                table: "Gak");

            migrationBuilder.DropForeignKey(
                name: "FK_Gak_Person_SekretarId",
                table: "Gak");

            migrationBuilder.DropIndex(
                name: "IX_Gak_PredsedatelId",
                table: "Gak");

            migrationBuilder.DropIndex(
                name: "IX_Gak_SekretarId",
                table: "Gak");

            migrationBuilder.DropColumn(
                name: "PredsedatelId",
                table: "Gak");

            migrationBuilder.DropColumn(
                name: "SekretarId",
                table: "Gak");
        }
    }
}
