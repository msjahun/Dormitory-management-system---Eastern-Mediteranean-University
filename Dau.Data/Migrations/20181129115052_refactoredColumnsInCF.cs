using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class refactoredColumnsInCF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowBilling = table.Column<bool>(nullable: false),
                    AllowBooking = table.Column<bool>(nullable: false),
                    TwoLetterIsoCode = table.Column<string>(nullable: true),
                    ThreeLetterIsoCode = table.Column<string>(nullable: true),
                    NumericIsoCode = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    DisplayLocale = table.Column<int>(nullable: false),
                    CustomFormatting = table.Column<string>(nullable: true),
                    RoundingType = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedTokens = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SendImmediately = table.Column<bool>(nullable: false),
                    AttachedStaticFile = table.Column<bool>(nullable: false),
                    StaticFileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    SearchEngineFriendlyPageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryNonTransId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTranslation_Country_CountryNonTransId",
                        column: x => x.CountryNonTransId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateAndProvince",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateAndProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateAndProvince_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyNonTransId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Currency_CurrencyNonTransId",
                        column: x => x.CurrencyNonTransId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageTemplateTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageTemplateNonTransId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    BCC = table.Column<string>(nullable: true),
                    EmailAccount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplateTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageTemplateTranslation_MessageTemplate_MessageTemplateNonTransId",
                        column: x => x.MessageTemplateNonTransId,
                        principalTable: "MessageTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryBlock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SeoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DormitoryBlock_Seo_SeoId",
                        column: x => x.SeoId,
                        principalTable: "Seo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    PasswordProtected = table.Column<bool>(nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn1 = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn2 = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn3 = table.Column<bool>(nullable: false),
                    IncludeInSitemap = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    AccesibleWhenSiteIsClosed = table.Column<bool>(nullable: false),
                    SeoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Seo_SeoId",
                        column: x => x.SeoId,
                        principalTable: "Seo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryBlockTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryBlockNonTransId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBlockTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DormitoryBlockTranslation_DormitoryBlock_DormitoryBlockNonTransId",
                        column: x => x.DormitoryBlockNonTransId,
                        principalTable: "DormitoryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryBlockTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TopicNonTransId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicTranslation_Topic_TopicNonTransId",
                        column: x => x.TopicNonTransId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslation_CountryNonTransId",
                table: "CountryTranslation",
                column: "CountryNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslation_LanguageId",
                table: "CountryTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_CurrencyNonTransId",
                table: "CurrencyTranslation",
                column: "CurrencyNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_LanguageId",
                table: "CurrencyTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlock_SeoId",
                table: "DormitoryBlock",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlockTranslation_DormitoryBlockNonTransId",
                table: "DormitoryBlockTranslation",
                column: "DormitoryBlockNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlockTranslation_LanguageId",
                table: "DormitoryBlockTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTemplateTranslation_LanguageId",
                table: "MessageTemplateTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTemplateTranslation_MessageTemplateNonTransId",
                table: "MessageTemplateTranslation",
                column: "MessageTemplateNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_StateAndProvince_CountryId",
                table: "StateAndProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SeoId",
                table: "Topic",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicTranslation_LanguageId",
                table: "TopicTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicTranslation_TopicNonTransId",
                table: "TopicTranslation",
                column: "TopicNonTransId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTranslation");

            migrationBuilder.DropTable(
                name: "CurrencyTranslation");

            migrationBuilder.DropTable(
                name: "DormitoryBlockTranslation");

            migrationBuilder.DropTable(
                name: "MessageTemplateTranslation");

            migrationBuilder.DropTable(
                name: "StateAndProvince");

            migrationBuilder.DropTable(
                name: "TopicTranslation");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DormitoryBlock");

            migrationBuilder.DropTable(
                name: "MessageTemplate");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Seo");
        }
    }
}
