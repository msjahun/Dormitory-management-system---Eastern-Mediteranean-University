using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class disownedUserDormitoryFromRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Id",
                table: "UsersDormitory");

            migrationBuilder.DropColumn(
                name: "DormitoryId2",
                table: "UsersDormitory");

            migrationBuilder.AlterColumn<string>(
                name: "DormitoryUserId",
                table: "UsersDormitory",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "DormitoryId1",
                table: "UsersDormitory",
                nullable: true,
                oldClrType: typeof(long));

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "DormitoryUserId",
                table: "UsersDormitory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DormitoryId1",
                table: "UsersDormitory",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UsersDormitory",
                nullable: false,
                defaultValue: 0L);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
