using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOplataStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oplata_Zasedanie_ZasedanieId",
                table: "Oplata");

            migrationBuilder.RenameColumn(
                name: "StavkaZaStudenta",
                table: "Oplata",
                newName: "StoimostChasa");

            migrationBuilder.RenameColumn(
                name: "KolvoStudentov",
                table: "Oplata",
                newName: "KolvoPlatka");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZasedanieId",
                table: "Oplata",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<float>(
                name: "AkademChasov",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AstronomChasov",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "GakId",
                table: "Oplata",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "Koefficient",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "KolvoBudget",
                table: "Oplata",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Oplata_GakId",
                table: "Oplata",
                column: "GakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oplata_Gak_GakId",
                table: "Oplata",
                column: "GakId",
                principalTable: "Gak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oplata_Zasedanie_ZasedanieId",
                table: "Oplata",
                column: "ZasedanieId",
                principalTable: "Zasedanie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oplata_Gak_GakId",
                table: "Oplata");

            migrationBuilder.DropForeignKey(
                name: "FK_Oplata_Zasedanie_ZasedanieId",
                table: "Oplata");

            migrationBuilder.DropIndex(
                name: "IX_Oplata_GakId",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "AkademChasov",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "AstronomChasov",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "GakId",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "Koefficient",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "KolvoBudget",
                table: "Oplata");

            migrationBuilder.RenameColumn(
                name: "StoimostChasa",
                table: "Oplata",
                newName: "StavkaZaStudenta");

            migrationBuilder.RenameColumn(
                name: "KolvoPlatka",
                table: "Oplata",
                newName: "KolvoStudentov");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZasedanieId",
                table: "Oplata",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Oplata_Zasedanie_ZasedanieId",
                table: "Oplata",
                column: "ZasedanieId",
                principalTable: "Zasedanie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
