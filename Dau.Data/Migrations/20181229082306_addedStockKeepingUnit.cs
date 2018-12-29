using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class addedStockKeepingUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Dormitory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Dormitory");
        }
    }
}
