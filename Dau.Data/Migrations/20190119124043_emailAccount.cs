using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class emailAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "EmailAccount",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "EmailAccount");
        }
    }
}
