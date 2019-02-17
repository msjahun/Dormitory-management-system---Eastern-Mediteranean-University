using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class addedUserIdToOnlineUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OnlineUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OnlineUsers");
        }
    }
}
