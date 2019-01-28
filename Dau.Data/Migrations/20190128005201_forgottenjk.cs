using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class forgottenjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitory_Currency_CurrencyId",
                table: "Dormitory");

            migrationBuilder.DropIndex(
                name: "IX_Dormitory_CurrencyId",
                table: "Dormitory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dormitory_CurrencyId",
                table: "Dormitory",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitory_Currency_CurrencyId",
                table: "Dormitory",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
