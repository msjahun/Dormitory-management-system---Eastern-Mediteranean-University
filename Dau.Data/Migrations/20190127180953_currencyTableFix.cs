using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class currencyTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyTranslation");

            migrationBuilder.DropColumn(
                name: "CustomFormatting",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "DisplayLocale",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "RoundingType",
                table: "Currency");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Currency",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Currency");

            migrationBuilder.AddColumn<string>(
                name: "CustomFormatting",
                table: "Currency",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayLocale",
                table: "Currency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundingType",
                table: "Currency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CurrencyTranslation",
                columns: table => new
                {
                    CurrencyNonTransId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<long>(nullable: false),
                    CurrencyNonTransId1 = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTranslation", x => new { x.CurrencyNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Currency_CurrencyNonTransId1",
                        column: x => x.CurrencyNonTransId1,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_CurrencyNonTransId1",
                table: "CurrencyTranslation",
                column: "CurrencyNonTransId1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_LanguageId",
                table: "CurrencyTranslation",
                column: "LanguageId");
        }
    }
}
