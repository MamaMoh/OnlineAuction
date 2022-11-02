using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet6MvcLogin.Migrations
{
    public partial class gech3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimention",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "productDimention",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productDimention",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Dimention",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
