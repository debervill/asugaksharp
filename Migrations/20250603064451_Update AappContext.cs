using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAappContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gak_Kafedra_KafedraID",
                table: "Gak");

            migrationBuilder.DropForeignKey(
                name: "FK_Gak_PeriodZasedania_PeriodZasedaniaId",
                table: "Gak");

            migrationBuilder.DropForeignKey(
                name: "FK_GakPerson_Gak_GakId",
                table: "GakPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "GakId",
                table: "GakPerson",
                newName: "GaksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_Kafedra_KafedraID",
                table: "Gak",
                column: "KafedraID",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_PeriodZasedania_PeriodZasedaniaId",
                table: "Gak",
                column: "PeriodZasedaniaId",
                principalTable: "PeriodZasedania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GakPerson_Gak_GaksId",
                table: "GakPerson",
                column: "GaksId",
                principalTable: "Gak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person",
                column: "KafedraID",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gak_Kafedra_KafedraID",
                table: "Gak");

            migrationBuilder.DropForeignKey(
                name: "FK_Gak_PeriodZasedania_PeriodZasedaniaId",
                table: "Gak");

            migrationBuilder.DropForeignKey(
                name: "FK_GakPerson_Gak_GaksId",
                table: "GakPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "GaksId",
                table: "GakPerson",
                newName: "GakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_Kafedra_KafedraID",
                table: "Gak",
                column: "KafedraID",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gak_PeriodZasedania_PeriodZasedaniaId",
                table: "Gak",
                column: "PeriodZasedaniaId",
                principalTable: "PeriodZasedania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GakPerson_Gak_GakId",
                table: "GakPerson",
                column: "GakId",
                principalTable: "Gak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Kafedra_KafedraID",
                table: "Person",
                column: "KafedraID",
                principalTable: "Kafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
