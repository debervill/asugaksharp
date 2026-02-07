using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddPassportIssuedByToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassportIssuedBy",
                table: "Person",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportIssuedBy",
                table: "Person");
        }
    }
}
