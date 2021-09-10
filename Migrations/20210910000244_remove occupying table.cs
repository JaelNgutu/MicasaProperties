using Microsoft.EntityFrameworkCore.Migrations;

namespace MicasaProperties.Migrations
{
    public partial class removeoccupyingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupying",
                table: "Tenants");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Occupying",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
