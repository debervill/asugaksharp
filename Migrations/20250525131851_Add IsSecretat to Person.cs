using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSecretattoPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSecretar",
                table: "Person",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSecretar",
                table: "Person");
        }
    }
}
