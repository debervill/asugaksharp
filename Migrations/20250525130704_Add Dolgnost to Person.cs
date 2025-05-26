using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddDolgnosttoPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dolgnost",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dolgnost",
                table: "Person");
        }
    }
}
