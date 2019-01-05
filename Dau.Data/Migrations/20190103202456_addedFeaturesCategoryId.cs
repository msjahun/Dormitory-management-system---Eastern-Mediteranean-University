using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class addedFeaturesCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeaturesCategory_FeaturesCategoryId",
                table: "Features");

            migrationBuilder.AlterColumn<long>(
                name: "FeaturesCategoryId",
                table: "Features",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeaturesCategory_FeaturesCategoryId",
                table: "Features",
                column: "FeaturesCategoryId",
                principalTable: "FeaturesCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeaturesCategory_FeaturesCategoryId",
                table: "Features");

            migrationBuilder.AlterColumn<long>(
                name: "FeaturesCategoryId",
                table: "Features",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeaturesCategory_FeaturesCategoryId",
                table: "Features",
                column: "FeaturesCategoryId",
                principalTable: "FeaturesCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
