using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet6MvcLogin.Migrations
{
    public partial class gech2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Product",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Product",
                newName: "FullName");
        }
    }
}
