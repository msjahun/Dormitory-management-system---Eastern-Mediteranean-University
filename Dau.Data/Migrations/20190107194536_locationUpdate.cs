using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class locationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Locations",
                newName: "DurationText");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Locations",
                newName: "DistanceText");

            migrationBuilder.AddColumn<int>(
                name: "DistanceValue",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationValue",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceValue",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DurationValue",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "DurationText",
                table: "Locations",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "DistanceText",
                table: "Locations",
                newName: "Distance");
        }
    }
}
