using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class ChangePersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "IsPredsed",
                table: "Person",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsZavKaf",
                table: "Person",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPredsed",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsZavKaf",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
