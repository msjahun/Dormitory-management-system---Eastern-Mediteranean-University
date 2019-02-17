using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");
        }
    }
}
