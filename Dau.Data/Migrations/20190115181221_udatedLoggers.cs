using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class udatedLoggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityCategory",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "ActivityLogTypeId",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "ActivityLog");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityPerformed",
                table: "ActivityLog",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "ActivityLogType",
                table: "ActivityLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ActivityLog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventLogger",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    EventParameters = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogger", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_AspNetUsers_UserId",
                table: "ActivityLog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_AspNetUsers_UserId",
                table: "ActivityLog");

            migrationBuilder.DropTable(
                name: "EventLogger");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "ActivityLogType",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActivityLog");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityPerformed",
                table: "ActivityLog",
                unicode: false,
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityCategory",
                table: "ActivityLog",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActivityLogTypeId",
                table: "ActivityLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "ActivityLog",
                unicode: false,
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
