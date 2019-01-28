using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class temperedwithprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "Room",
                newName: "PriceOldInstallment");

            migrationBuilder.RenameColumn(
                name: "RoomCost",
                table: "Room",
                newName: "PriceOldCash");

            migrationBuilder.RenameColumn(
                name: "PriceOld",
                table: "Room",
                newName: "PriceInstallment");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Room",
                newName: "PriceCash");

            migrationBuilder.RenameColumn(
                name: "BookingFee",
                table: "Room",
                newName: "MinBookingFee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceOldInstallment",
                table: "Room",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "PriceOldCash",
                table: "Room",
                newName: "RoomCost");

            migrationBuilder.RenameColumn(
                name: "PriceInstallment",
                table: "Room",
                newName: "PriceOld");

            migrationBuilder.RenameColumn(
                name: "PriceCash",
                table: "Room",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "MinBookingFee",
                table: "Room",
                newName: "BookingFee");
        }
    }
}
