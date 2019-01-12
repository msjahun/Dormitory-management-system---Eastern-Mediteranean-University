using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class updatemessageQueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoadNotSentEmailsOnly",
                table: "MessageQueue",
                newName: "IsSent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSent",
                table: "MessageQueue",
                newName: "LoadNotSentEmailsOnly");
        }
    }
}
