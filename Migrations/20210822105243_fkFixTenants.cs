using Microsoft.EntityFrameworkCore.Migrations;

namespace MicasaProperties.Migrations
{
    public partial class fkFixTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Buildings_BuildingID",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "BuldingID",
                table: "Tenants");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Buildings_BuildingID",
                table: "Tenants",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Buildings_BuildingID",
                table: "Tenants");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
