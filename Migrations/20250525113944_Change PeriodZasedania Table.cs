using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asugaksharp.Migrations
{
    /// <inheritdoc />
    public partial class ChangePeriodZasedaniaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PeriodZasedania",
                newName: "DateStart");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateEnd",
                table: "PeriodZasedania",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "PeriodZasedania");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "PeriodZasedania",
                newName: "Date");
        }
    }
}
