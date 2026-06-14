using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShifrPodgotFromProfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShifrPodgot",
                table: "ProfilPodgotovki");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShifrPodgot",
                table: "ProfilPodgotovki",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
