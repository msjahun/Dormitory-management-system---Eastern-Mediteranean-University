using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class backgroundImagesSliderImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowInExploreEMU",
                table: "CatalogImages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeSliderImage",
                table: "CatalogImages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowInExploreEMU",
                table: "CatalogImages");

            migrationBuilder.DropColumn(
                name: "IsHomeSliderImage",
                table: "CatalogImages");
        }
    }
}
