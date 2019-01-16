using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class ud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersDormitory",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    DormitoryId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    DormitoryUserId = table.Column<string>(nullable: false),
                    DormitoryId1 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDormitory", x => new { x.UserId, x.DormitoryId });
                    table.ForeignKey(
                        name: "FK_UsersDormitory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersDormitory_UsersDormitory_DormitoryUserId_DormitoryId1",
                        columns: x => new { x.DormitoryUserId, x.DormitoryId1 },
                        principalTable: "UsersDormitory",
                        principalColumns: new[] { "UserId", "DormitoryId" },
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDormitory_DormitoryUserId_DormitoryId1",
                table: "UsersDormitory",
                columns: new[] { "DormitoryUserId", "DormitoryId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDormitory");
        }
    }
}
