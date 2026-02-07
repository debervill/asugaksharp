using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using asugaksharp.Infrastructure.Persistence;

#nullable disable

namespace asugaksharp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260205133500_AddObshayaStoimostUslugPoDogovoruToOplata")]
    public partial class AddObshayaStoimostUslugPoDogovoruToOplata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ObshayaStoimostUslugPoDogovoru",
                table: "Oplata",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObshayaStoimostUslugPoDogovoru",
                table: "Oplata");
        }
    }
}
