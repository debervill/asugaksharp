using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using asugaksharp.Infrastructure.Persistence;

#nullable disable

namespace asugaksharp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260205141000_AddOplataTotalsToOplata")]
    public partial class AddOplataTotalsToOplata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalNachisleno",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalNdfl",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalEnp",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalKVyplate",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalEnp",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "TotalKVyplate",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "TotalNachisleno",
                table: "Oplata");

            migrationBuilder.DropColumn(
                name: "TotalNdfl",
                table: "Oplata");
        }
    }
}
