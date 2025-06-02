using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class AddlinikNapravprofill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NapravleniePodgotovkiID",
                table: "ProfilPodgotovki",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPodgotovki_NapravleniePodgotovkiID",
                table: "ProfilPodgotovki",
                column: "NapravleniePodgotovkiID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilPodgotovki_NapravleniePodgotovki_NapravleniePodgotovkiID",
                table: "ProfilPodgotovki",
                column: "NapravleniePodgotovkiID",
                principalTable: "NapravleniePodgotovki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilPodgotovki_NapravleniePodgotovki_NapravleniePodgotovkiID",
                table: "ProfilPodgotovki");

            migrationBuilder.DropIndex(
                name: "IX_ProfilPodgotovki_NapravleniePodgotovkiID",
                table: "ProfilPodgotovki");

            migrationBuilder.DropColumn(
                name: "NapravleniePodgotovkiID",
                table: "ProfilPodgotovki");
        }
    }
}
