using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    public partial class RemovePolesFromKafedra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoleZapolnenia",
                table: "Kafedra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PoleZapolnenia",
                table: "Kafedra",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}