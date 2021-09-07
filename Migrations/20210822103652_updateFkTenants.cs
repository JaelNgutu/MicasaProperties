using Microsoft.EntityFrameworkCore.Migrations;

namespace MicasaProperties.Migrations
{
    public partial class updateFkTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Buildings_buildingID",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "buildingID",
                table: "Tenants",
                newName: "BuildingID");

            migrationBuilder.RenameColumn(
                name: "tenantID",
                table: "Tenants",
                newName: "TenantID");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_buildingID",
                table: "Tenants",
                newName: "IX_Tenants_BuildingID");

            migrationBuilder.RenameColumn(
                name: "unitsAvailable",
                table: "Buildings",
                newName: "UnitsAvailable");

            migrationBuilder.RenameColumn(
                name: "costPerUnit",
                table: "Buildings",
                newName: "CostPerUnit");

            migrationBuilder.RenameColumn(
                name: "buildingName",
                table: "Buildings",
                newName: "BuildingName");

            migrationBuilder.RenameColumn(
                name: "buildingID",
                table: "Buildings",
                newName: "BuildingID");

            migrationBuilder.AddColumn<int>(
                name: "BuldingID",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Buildings_BuildingID",
                table: "Tenants",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Buildings_BuildingID",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "BuldingID",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                table: "Tenants",
                newName: "buildingID");

            migrationBuilder.RenameColumn(
                name: "TenantID",
                table: "Tenants",
                newName: "tenantID");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_BuildingID",
                table: "Tenants",
                newName: "IX_Tenants_buildingID");

            migrationBuilder.RenameColumn(
                name: "UnitsAvailable",
                table: "Buildings",
                newName: "unitsAvailable");

            migrationBuilder.RenameColumn(
                name: "CostPerUnit",
                table: "Buildings",
                newName: "costPerUnit");

            migrationBuilder.RenameColumn(
                name: "BuildingName",
                table: "Buildings",
                newName: "buildingName");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                table: "Buildings",
                newName: "buildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Buildings_buildingID",
                table: "Tenants",
                column: "buildingID",
                principalTable: "Buildings",
                principalColumn: "buildingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
