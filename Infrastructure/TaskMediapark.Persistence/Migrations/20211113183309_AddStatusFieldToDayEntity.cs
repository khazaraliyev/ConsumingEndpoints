using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskMediapark.Persistence.Migrations
{
    public partial class AddStatusFieldToDayEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Days");
        }
    }
}
