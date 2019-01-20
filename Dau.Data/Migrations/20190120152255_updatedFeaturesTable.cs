using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class updatedFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowFiltering",
                table: "FeaturesCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FeaturesCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "FeaturesCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "FeaturesCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "AllowFiltering",
                table: "Features",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Features",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowFiltering",
                table: "FeaturesCategory");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FeaturesCategory");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "FeaturesCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "FeaturesCategory");

            migrationBuilder.DropColumn(
                name: "AllowFiltering",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Features");
        }
    }
}
