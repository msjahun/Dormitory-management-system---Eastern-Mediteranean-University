using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class messageTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageTemplateId",
                table: "MessageTemplateTranslation",
                newName: "MessageTemplateNonTransId");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "MessageTemplateTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "MessageTemplateTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BCC",
                table: "MessageTemplateTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageTemplateNonTransId",
                table: "MessageTemplateTranslation",
                newName: "MessageTemplateId");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "MessageTemplateTranslation",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "MessageTemplateTranslation",
                unicode: false,
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BCC",
                table: "MessageTemplateTranslation",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
