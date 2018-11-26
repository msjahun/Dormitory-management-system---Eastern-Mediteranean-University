using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class addedOnlineUsersMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserInfo = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastActivity = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastVisitedPage = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineUsers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineUsers");
        }
    }
}
