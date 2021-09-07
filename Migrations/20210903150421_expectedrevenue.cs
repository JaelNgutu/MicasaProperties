using Microsoft.EntityFrameworkCore.Migrations;

namespace MicasaProperties.Migrations
{
    public partial class expectedrevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedRevenue",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedRevenue",
                table: "Buildings");
        }
    }
}
