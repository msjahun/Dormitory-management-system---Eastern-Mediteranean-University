using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class addedApiLogT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestSentDateTime",
                table: "ApiDebugLog",
                newName: "CreateDateTime");

            migrationBuilder.RenameColumn(
                name: "JsonInput",
                table: "ApiDebugLog",
                newName: "Reponse");

            migrationBuilder.AddColumn<string>(
                name: "ParameterRecieved",
                table: "ApiDebugLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParameterRecieved",
                table: "ApiDebugLog");

            migrationBuilder.RenameColumn(
                name: "Reponse",
                table: "ApiDebugLog",
                newName: "JsonInput");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "ApiDebugLog",
                newName: "RequestSentDateTime");
        }
    }
}
