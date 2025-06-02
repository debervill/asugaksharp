using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class Addtwopole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProfilPodgotovki",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nazvanie",
                table: "NapravleniePodgotovki",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShifrNapr",
                table: "NapravleniePodgotovki",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProfilPodgotovki");

            migrationBuilder.DropColumn(
                name: "Nazvanie",
                table: "NapravleniePodgotovki");

            migrationBuilder.DropColumn(
                name: "ShifrNapr",
                table: "NapravleniePodgotovki");
        }
    }
}
