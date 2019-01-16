using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDormitory_UsersDormitory_DormitoryUserId_DormitoryId1",
                table: "UsersDormitory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDormitory",
                table: "UsersDormitory");

            migrationBuilder.DropIndex(
                name: "IX_UsersDormitory_DormitoryUserId_DormitoryId1",
                table: "UsersDormitory");

            migrationBuilder.AddColumn<long>(
                name: "DormitoryId2",
                table: "UsersDormitory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDormitory",
                table: "UsersDormitory",
                columns: new[] { "Id", "UserId", "DormitoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDormitory_UserId",
                table: "UsersDormitory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDormitory_DormitoryId1_DormitoryUserId_DormitoryId2",
                table: "UsersDormitory",
                columns: new[] { "DormitoryId1", "DormitoryUserId", "DormitoryId2" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDormitory_UsersDormitory_DormitoryId1_DormitoryUserId_DormitoryId2",
                table: "UsersDormitory",
                columns: new[] { "DormitoryId1", "DormitoryUserId", "DormitoryId2" },
                principalTable: "UsersDormitory",
                principalColumns: new[] { "Id", "UserId", "DormitoryId" },
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDormitory_UsersDormitory_DormitoryId1_DormitoryUserId_DormitoryId2",
                table: "UsersDormitory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDormitory",
                table: "UsersDormitory");

            migrationBuilder.DropIndex(
                name: "IX_UsersDormitory_UserId",
                table: "UsersDormitory");

            migrationBuilder.DropIndex(
                name: "IX_UsersDormitory_DormitoryId1_DormitoryUserId_DormitoryId2",
                table: "UsersDormitory");

            migrationBuilder.DropColumn(
                name: "DormitoryId2",
                table: "UsersDormitory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDormitory",
                table: "UsersDormitory",
                columns: new[] { "UserId", "DormitoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDormitory_DormitoryUserId_DormitoryId1",
                table: "UsersDormitory",
                columns: new[] { "DormitoryUserId", "DormitoryId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDormitory_UsersDormitory_DormitoryUserId_DormitoryId1",
                table: "UsersDormitory",
                columns: new[] { "DormitoryUserId", "DormitoryId1" },
                principalTable: "UsersDormitory",
                principalColumns: new[] { "UserId", "DormitoryId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
