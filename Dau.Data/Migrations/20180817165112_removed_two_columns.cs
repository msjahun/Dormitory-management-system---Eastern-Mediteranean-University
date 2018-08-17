using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class removed_two_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bank_address",
                table: "bank_currency_table");

            migrationBuilder.DropColumn(
                name: "bank_registration_no",
                table: "bank_currency_table");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bank_address",
                table: "bank_currency_table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bank_registration_no",
                table: "bank_currency_table",
                nullable: true);
        }
    }
}
