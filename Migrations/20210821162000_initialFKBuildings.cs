using Microsoft.EntityFrameworkCore.Migrations;

namespace MicasaProperties.Migrations
{
    public partial class initialFKBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "buildingID",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_buildingID",
                table: "Tenants",
                column: "buildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Buildings_buildingID",
                table: "Tenants",
                column: "buildingID",
                principalTable: "Buildings",
                principalColumn: "buildingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Buildings_buildingID",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_buildingID",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "buildingID",
                table: "Tenants");
        }
    }
}
