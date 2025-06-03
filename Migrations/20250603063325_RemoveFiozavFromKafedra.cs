using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFiozavFromKafedra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
       name: "Fiozav",
       table: "Kafedra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
      name: "Fiozav",
      table: "Kafedra",
      type: "TEXT",
      nullable: false,
      defaultValue: "");
        }
    }
}
