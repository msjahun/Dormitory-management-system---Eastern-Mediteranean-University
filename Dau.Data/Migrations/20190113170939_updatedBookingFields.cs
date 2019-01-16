using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class updatedBookingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateProvince",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentAddress1",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentAddress2",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Booking",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StateProvince",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StudentAddress1",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StudentAddress2",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Booking");
        }
    }
}
