using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kafedras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafedras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NapravleniaPodgotovki",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nazvanie = table.Column<string>(type: "TEXT", nullable: false),
                    ShifrNapr = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NapravleniaPodgotovki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodZasedanias",
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
                    table.PrimaryKey("PK_PeriodZasedanias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodZasedanias_Kafedras_KafedraId",
                        column: x => x.KafedraId,
                        principalTable: "Kafedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
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
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Kafedras_KafedraID",
                        column: x => x.KafedraID,
                        principalTable: "Kafedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilPodgotovkis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShifrPodgot = table.Column<string>(type: "TEXT", nullable: false),
                    NapravleniePodgotovkiID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProfilPodgotovkiId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilPodgotovkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilPodgotovkis_NapravleniaPodgotovki_NapravleniePodgotovkiID",
                        column: x => x.NapravleniePodgotovkiID,
                        principalTable: "NapravleniaPodgotovki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilPodgotovkis_ProfilPodgotovkis_ProfilPodgotovkiId",
                        column: x => x.ProfilPodgotovkiId,
                        principalTable: "ProfilPodgotovkis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gaks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomerPrikaza = table.Column<string>(type: "TEXT", nullable: false),
                    KolvoBudget = table.Column<int>(type: "INTEGER", nullable: false),
                    KolvoPlatka = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodZasedaniaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KafedraID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gaks_Kafedras_KafedraID",
                        column: x => x.KafedraID,
                        principalTable: "Kafedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gaks_PeriodZasedanias_PeriodZasedaniaId",
                        column: x => x.PeriodZasedaniaId,
                        principalTable: "PeriodZasedanias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diplomniks",
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
                    table.PrimaryKey("PK_Diplomniks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diplomniks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
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
                        name: "FK_Docs_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oplatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Stavka = table.Column<float>(type: "REAL", nullable: false),
                    Ndfl = table.Column<float>(type: "REAL", nullable: false),
                    Enp = table.Column<float>(type: "REAL", nullable: false),
                    MoneySource = table.Column<int>(type: "INTEGER", nullable: false),
                    DogovorNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oplatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oplatas_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
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
                        name: "FK_GakPerson_Gaks_GaksId",
                        column: x => x.GaksId,
                        principalTable: "Gaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GakPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zasedanies",
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
                    table.PrimaryKey("PK_Zasedanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zasedanies_Gaks_GakID",
                        column: x => x.GakID,
                        principalTable: "Gaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonZasedanie",
                columns: table => new
                {
                    PersonsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZasedaniesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonZasedanie", x => new { x.PersonsId, x.ZasedaniesId });
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonZasedanie_Zasedanies_ZasedaniesId",
                        column: x => x.ZasedaniesId,
                        principalTable: "Zasedanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomniks_PersonId",
                table: "Diplomniks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_PersonId",
                table: "Docs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GakPerson_PersonsId",
                table: "GakPerson",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gaks_KafedraID",
                table: "Gaks",
                column: "KafedraID");

            migrationBuilder.CreateIndex(
                name: "IX_Gaks_PeriodZasedaniaId",
                table: "Gaks",
                column: "PeriodZasedaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oplatas_PersonId",
                table: "Oplatas",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodZasedanias_KafedraId",
                table: "PeriodZasedanias",
                column: "KafedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_KafedraID",
                table: "Persons",
                column: "KafedraID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonZasedanie_ZasedaniesId",
                table: "PersonZasedanie",
                column: "ZasedaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPodgotovkis_NapravleniePodgotovkiID",
                table: "ProfilPodgotovkis",
                column: "NapravleniePodgotovkiID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPodgotovkis_ProfilPodgotovkiId",
                table: "ProfilPodgotovkis",
                column: "ProfilPodgotovkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Zasedanies_GakID",
                table: "Zasedanies",
                column: "GakID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diplomniks");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "GakPerson");

            migrationBuilder.DropTable(
                name: "Oplatas");

            migrationBuilder.DropTable(
                name: "PersonZasedanie");

            migrationBuilder.DropTable(
                name: "ProfilPodgotovkis");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Zasedanies");

            migrationBuilder.DropTable(
                name: "NapravleniaPodgotovki");

            migrationBuilder.DropTable(
                name: "Gaks");

            migrationBuilder.DropTable(
                name: "PeriodZasedanias");

            migrationBuilder.DropTable(
                name: "Kafedras");
        }
    }
}
