using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class DormitoryCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "Dormitory",
                nullable: true,
                defaultValue: 0);

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitory_Currency_CurrencyId",
                table: "Dormitory");

            migrationBuilder.DropIndex(
                name: "IX_Dormitory_CurrencyId",
                table: "Dormitory");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Dormitory");
        }
    }
}
