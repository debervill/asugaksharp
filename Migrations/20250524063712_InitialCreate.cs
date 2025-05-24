using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kafedra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Fiozav = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafedra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodZasedania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Primechanie = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodZasedania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Stepen = table.Column<string>(type: "TEXT", nullable: false),
                    Zvanie = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomerPrikaza = table.Column<string>(type: "TEXT", nullable: false),
                    KolvoBudget = table.Column<int>(type: "INTEGER", nullable: false),
                    KolvoPlatka = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodZasedaniaId = table.Column<int>(type: "INTEGER", nullable: false),
                    KafedraID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gak_Kafedra_KafedraID",
                        column: x => x.KafedraID,
                        principalTable: "Kafedra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gak_PeriodZasedania_PeriodZasedaniaId",
                        column: x => x.PeriodZasedaniaId,
                        principalTable: "PeriodZasedania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diplomnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    Tema = table.Column<string>(type: "TEXT", nullable: false),
                    OrigVkr = table.Column<float>(type: "REAL", nullable: false),
                    Srball = table.Column<float>(type: "REAL", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diplomnik_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsUploaded = table.Column<bool>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oplata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stavka = table.Column<float>(type: "REAL", nullable: false),
                    Ndfl = table.Column<float>(type: "REAL", nullable: false),
                    Enp = table.Column<float>(type: "REAL", nullable: false),
                    MoneySource = table.Column<int>(type: "INTEGER", nullable: false),
                    DogovorNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oplata_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GakPerson",
                columns: table => new
                {
                    GakId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GakPerson", x => new { x.GakId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_GakPerson_Gak_GakId",
                        column: x => x.GakId,
                        principalTable: "Gak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GakPerson_Person_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zasedanie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NapravleniePodgotovki = table.Column<string>(type: "TEXT", nullable: false),
                    Kvalificacia = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    GakID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zasedanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zasedanie_Gak_GakID",
                        column: x => x.GakID,
                        principalTable: "Gak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonZasedanie",
                columns: table => new
                {
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZasedaniesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonZasedanie", x => new { x.PersonsId, x.ZasedaniesId });
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Person_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Zasedanie_ZasedaniesId",
                        column: x => x.ZasedaniesId,
                        principalTable: "Zasedanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_PersonId",
                table: "Diplomnik",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_PersonId",
                table: "Docs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Gak_KafedraID",
                table: "Gak",
                column: "KafedraID");

            migrationBuilder.CreateIndex(
                name: "IX_Gak_PeriodZasedaniaId",
                table: "Gak",
                column: "PeriodZasedaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_GakPerson_PersonsId",
                table: "GakPerson",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Oplata_PersonId",
                table: "Oplata",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonZasedanie_ZasedaniesId",
                table: "PersonZasedanie",
                column: "ZasedaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Zasedanie_GakID",
                table: "Zasedanie",
                column: "GakID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diplomnik");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "GakPerson");

            migrationBuilder.DropTable(
                name: "Oplata");

            migrationBuilder.DropTable(
                name: "PersonZasedanie");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Zasedanie");

            migrationBuilder.DropTable(
                name: "Gak");

            migrationBuilder.DropTable(
                name: "Kafedra");

            migrationBuilder.DropTable(
                name: "PeriodZasedania");
        }
    }
}
