using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class lsdkn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locationinformation");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Dormitory");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryId = table.Column<long>(nullable: false),
                    Distance = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    MapSectionId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_MapSection_MapSectionId",
                        column: x => x.MapSectionId,
                        principalTable: "MapSection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DormitoryId",
                table: "Locations",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapSectionId",
                table: "Locations",
                column: "MapSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Dormitory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locationinformation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<string>(nullable: true),
                    DormitoryId = table.Column<long>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    MapSection = table.Column<string>(nullable: true),
                    NameOfLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locationinformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locationinformation_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locationinformation_DormitoryId",
                table: "Locationinformation",
                column: "DormitoryId");
        }
    }
}
