using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskMediapark.Persistence.Migrations
{
    public partial class AlterHolidayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HolidayType",
                table: "Holidays",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolidayType",
                table: "Holidays");
        }
    }
}
