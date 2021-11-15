using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskMediapark.Persistence.Migrations
{
    public partial class AlterHolidaysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Holidays");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Holidays");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
