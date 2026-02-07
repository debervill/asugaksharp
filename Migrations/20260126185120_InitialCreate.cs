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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafedra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NapravleniePodgotovki",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nazvanie = table.Column<string>(type: "TEXT", nullable: false),
                    ShifrNapr = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NapravleniePodgotovki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Normativ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RolVGek = table.Column<string>(type: "TEXT", nullable: false),
                    StavkaZaStudenta = table.Column<float>(type: "REAL", nullable: false),
                    NormaVremeni = table.Column<float>(type: "REAL", nullable: false),
                    Osnovanie = table.Column<string>(type: "TEXT", nullable: false),
                    Kod = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normativ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodZasedania",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateStart = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateEnd = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Primechanie = table.Column<string>(type: "TEXT", nullable: false),
                    KafedraId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodZasedania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodZasedania_Kafedra_KafedraId",
                        column: x => x.KafedraId,
                        principalTable: "Kafedra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Stepen = table.Column<string>(type: "TEXT", nullable: false),
                    Zvanie = table.Column<string>(type: "TEXT", nullable: false),
                    Dolgnost = table.Column<string>(type: "TEXT", nullable: false),
                    IsPredsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsZavKaf = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSecretar = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRecenzent = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVneshniy = table.Column<bool>(type: "INTEGER", nullable: false),
                    KafedraID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Kafedra_KafedraID",
                        column: x => x.KafedraID,
                        principalTable: "Kafedra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilPodgotovki",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShifrPodgot = table.Column<string>(type: "TEXT", nullable: false),
                    NapravleniePodgotovkiID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilPodgotovki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilPodgotovki_NapravleniePodgotovki_NapravleniePodgotovkiID",
                        column: x => x.NapravleniePodgotovkiID,
                        principalTable: "NapravleniePodgotovki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomerPrikaza = table.Column<string>(type: "TEXT", nullable: false),
                    Osnovanie = table.Column<string>(type: "TEXT", nullable: false),
                    DataPrikaza = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KolvoBudget = table.Column<int>(type: "INTEGER", nullable: false),
                    KolvoPlatka = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodZasedaniaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KafedraID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsUploaded = table.Column<bool>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "GakPerson",
                columns: table => new
                {
                    GaksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GakPerson", x => new { x.GaksId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_GakPerson_Gak_GaksId",
                        column: x => x.GaksId,
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NapravleniePodgotovki = table.Column<string>(type: "TEXT", nullable: false),
                    Kvalificacia = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    GakID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "Diplomnik",
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
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZasedanieId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Diplomnik_Zasedanie_ZasedanieId",
                        column: x => x.ZasedanieId,
                        principalTable: "Zasedanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oplata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZasedanieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RolVGek = table.Column<string>(type: "TEXT", nullable: false),
                    KolvoStudentov = table.Column<int>(type: "INTEGER", nullable: false),
                    StavkaZaStudenta = table.Column<float>(type: "REAL", nullable: false),
                    SummaBezNalogov = table.Column<float>(type: "REAL", nullable: false),
                    NdflProc = table.Column<float>(type: "REAL", nullable: false),
                    NdflSumma = table.Column<float>(type: "REAL", nullable: false),
                    EnpProc = table.Column<float>(type: "REAL", nullable: false),
                    EnpSumma = table.Column<float>(type: "REAL", nullable: false),
                    SummaKVyplate = table.Column<float>(type: "REAL", nullable: false),
                    SummaSNalogami = table.Column<float>(type: "REAL", nullable: false),
                    DogovorNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    MoneySource = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRascheta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDogovorGenerated = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Oplata_Zasedanie_ZasedanieId",
                        column: x => x.ZasedanieId,
                        principalTable: "Zasedanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonZasedanie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZasedanieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RolVGek = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonZasedanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Zasedanie_ZasedanieId",
                        column: x => x.ZasedanieId,
                        principalTable: "Zasedanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_PersonId",
                table: "Diplomnik",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomnik_ZasedanieId",
                table: "Diplomnik",
                column: "ZasedanieId");

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
                name: "IX_Oplata_ZasedanieId",
                table: "Oplata",
                column: "ZasedanieId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodZasedania_KafedraId",
                table: "PeriodZasedania",
                column: "KafedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_KafedraID",
                table: "Person",
                column: "KafedraID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonZasedanie_PersonId",
                table: "PersonZasedanie",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonZasedanie_ZasedanieId",
                table: "PersonZasedanie",
                column: "ZasedanieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPodgotovki_NapravleniePodgotovkiID",
                table: "ProfilPodgotovki",
                column: "NapravleniePodgotovkiID");

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
                name: "Normativ");

            migrationBuilder.DropTable(
                name: "Oplata");

            migrationBuilder.DropTable(
                name: "PersonZasedanie");

            migrationBuilder.DropTable(
                name: "ProfilPodgotovki");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Zasedanie");

            migrationBuilder.DropTable(
                name: "NapravleniePodgotovki");

            migrationBuilder.DropTable(
                name: "Gak");

            migrationBuilder.DropTable(
                name: "PeriodZasedania");

            migrationBuilder.DropTable(
                name: "Kafedra");
        }
    }
}
