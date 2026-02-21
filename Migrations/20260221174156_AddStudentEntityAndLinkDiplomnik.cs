using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentEntityAndLinkDiplomnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomnik_Person_PersonId",
                table: "Diplomnik");

            migrationBuilder.DropIndex(
                name: "IX_Diplomnik_PersonId",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "FioImen",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "FioRodit",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "OrigVkr",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "Srball",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Diplomnik");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FioImen = table.Column<string>(type: "TEXT", nullable: false),
                    FioRodit = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    Tema = table.Column<string>(type: "TEXT", nullable: false),
                    OrigVkr = table.Column<float>(type: "REAL", nullable: false),
                    Srball = table.Column<float>(type: "REAL", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_StudentId",
                table: "Diplomnik",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonId",
                table: "Student",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomnik_Student_StudentId",
                table: "Diplomnik",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomnik_Student_StudentId",
                table: "Diplomnik");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Diplomnik_StudentId",
                table: "Diplomnik");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Diplomnik");

            migrationBuilder.AddColumn<string>(
                name: "FioImen",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FioRodit",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "OrigVkr",
                table: "Diplomnik",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Diplomnik",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Diplomnik",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Srball",
                table: "Diplomnik",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_PersonId",
                table: "Diplomnik",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomnik_Person_PersonId",
                table: "Diplomnik",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
