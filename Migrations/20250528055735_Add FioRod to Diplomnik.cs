using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddFioRodtoDiplomnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Diplomnik",
                newName: "FioRodit");

            migrationBuilder.AddColumn<string>(
                name: "FioImen",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FioImen",
                table: "Diplomnik");

            migrationBuilder.RenameColumn(
                name: "FioRodit",
                table: "Diplomnik",
                newName: "Name");
        }
    }
}
