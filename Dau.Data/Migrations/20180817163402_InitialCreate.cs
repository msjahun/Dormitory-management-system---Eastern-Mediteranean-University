using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_information_parameter",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_information_parameter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facility_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    facility_icon_url = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "language_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    language_code = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dormitories_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_type_id = table.Column<int>(nullable: false),
                    room_price_currency = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    room_price_currency_symbol = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    map_latitude = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    map_longitude = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitories_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.dormitories_table_dbo.dormitory_type_dormitory_type_id",
                        column: x => x.dormitory_type_id,
                        principalTable: "dormitory_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_information_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_information_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_information_table_dbo.dormitory_type_dormitory_type_id",
                        column: x => x.dormitory_type_id,
                        principalTable: "dormitory_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "facility_option",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    facility_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility_option", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.facility_option_dbo.facility_table_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facility_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_information_parameter_translation",
                columns: table => new
                {
                    account_info_non_trans_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false),
                    parameter = table.Column<string>(unicode: false, maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_information_parameter_translation", x => new { x.account_info_non_trans_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_dbo.account_information_parameter_translation_dbo.account_information_parameter_account_info_non_trans_id",
                        column: x => x.account_info_non_trans_id,
                        principalTable: "account_information_parameter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.account_information_parameter_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_type_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    dormitory_type_non_trans_id = table.Column<int>(nullable: false),
                    type_name = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_type_translation", x => new { x.language_id, x.dormitory_type_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_type_translation_dbo.dormitory_type_dormitory_type_non_trans_id",
                        column: x => x.dormitory_type_non_trans_id,
                        principalTable: "dormitory_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_type_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "facility_table_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    facility_table_non_trans_id = table.Column<int>(nullable: false),
                    facility_title = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    facility_description = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility_table_translation", x => new { x.language_id, x.facility_table_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.facility_table_translation_dbo.facility_table_facility_table_non_trans_id",
                        column: x => x.facility_table_non_trans_id,
                        principalTable: "facility_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.facility_table_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dormitories_table_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    dormitories_table_non_trans_id = table.Column<int>(nullable: false),
                    dormitory_name = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    dormitory_address = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    gender_allocation = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    rooms_payment_period = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitories_table_translation", x => new { x.language_id, x.dormitories_table_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.dormitories_table_translation_dbo.dormitories_table_dormitories_table_non_trans_id",
                        column: x => x.dormitories_table_non_trans_id,
                        principalTable: "dormitories_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.dormitories_table_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_bank_account_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_id = table.Column<int>(nullable: false),
                    bank_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_bank_account_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_bank_account_table_dbo.dormitories_table_dormitory_id",
                        column: x => x.dormitory_id,
                        principalTable: "dormitories_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_id = table.Column<int>(nullable: false),
                    room_picture_url = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    room_price = table.Column<double>(nullable: false),
                    room_price_installment = table.Column<double>(nullable: false),
                    num_rooms_left = table.Column<int>(nullable: false),
                    room_area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.room_table_dbo.dormitories_table_dormitory_id",
                        column: x => x.dormitory_id,
                        principalTable: "dormitories_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_information_table_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    dormitory_info_non_trans_id = table.Column<int>(nullable: false),
                    information = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_information_table_translation", x => new { x.language_id, x.dormitory_info_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_information_table_translation_dbo.dormitory_information_table_dormitory_info_non_trans_id",
                        column: x => x.dormitory_info_non_trans_id,
                        principalTable: "dormitory_information_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.dormitory_information_table_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "facility_option_translation",
                columns: table => new
                {
                    facility_option_non_trans_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false),
                    facility_option = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    facility_option_description = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility_option_translation", x => new { x.facility_option_non_trans_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_dbo.facility_option_translation_dbo.facility_option_facility_option_non_trans_id",
                        column: x => x.facility_option_non_trans_id,
                        principalTable: "facility_option",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.facility_option_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bank_currency_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_id = table.Column<int>(nullable: false),
                    bank_address = table.Column<string>(nullable: true),
                    bank_registration_no = table.Column<string>(nullable: true),
                    currency_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_currency_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.bank_currency_table_dbo.dormitory_bank_account_table_bank_id",
                        column: x => x.bank_id,
                        principalTable: "dormitory_bank_account_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room_facility",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    facility_id = table.Column<int>(nullable: false),
                    room_id = table.Column<int>(nullable: false),
                    facility_option_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_facility", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.room_facility_dbo.facility_table_facility_id",
                        column: x => x.facility_id,
                        principalTable: "facility_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.room_facility_dbo.room_table_room_id",
                        column: x => x.room_id,
                        principalTable: "room_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room_table_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    room_table_non_trans_id = table.Column<int>(nullable: false),
                    room_type = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    room_title = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_table_translation", x => new { x.language_id, x.room_table_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.room_table_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.room_table_translation_dbo.room_table_room_table_non_trans_id",
                        column: x => x.room_table_non_trans_id,
                        principalTable: "room_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_parameter_values",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    currency_id = table.Column<int>(nullable: false),
                    parameter_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_parameter_values", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.account_parameter_values_dbo.bank_currency_table_currency_id",
                        column: x => x.currency_id,
                        principalTable: "bank_currency_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.account_parameter_values_dbo.account_information_parameter_parameter_id",
                        column: x => x.parameter_id,
                        principalTable: "account_information_parameter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_parameter_values_translation",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false),
                    account_params_values_non_trans_id = table.Column<int>(nullable: false),
                    value = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_parameter_values_translation", x => new { x.language_id, x.account_params_values_non_trans_id });
                    table.ForeignKey(
                        name: "FK_dbo.account_parameter_values_translation_dbo.account_parameter_values_account_params_values_non_trans_id",
                        column: x => x.account_params_values_non_trans_id,
                        principalTable: "account_parameter_values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.account_parameter_values_translation_dbo.language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_info_non_trans_id",
                table: "account_information_parameter_translation",
                column: "account_info_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "account_information_parameter_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_currency_id",
                table: "account_parameter_values",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_parameter_id",
                table: "account_parameter_values",
                column: "parameter_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_params_values_non_trans_id",
                table: "account_parameter_values_translation",
                column: "account_params_values_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "account_parameter_values_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_id",
                table: "bank_currency_table",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_type_id",
                table: "dormitories_table",
                column: "dormitory_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitories_table_non_trans_id",
                table: "dormitories_table_translation",
                column: "dormitories_table_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "dormitories_table_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_id",
                table: "dormitory_bank_account_table",
                column: "dormitory_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_type_id",
                table: "dormitory_information_table",
                column: "dormitory_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_info_non_trans_id",
                table: "dormitory_information_table_translation",
                column: "dormitory_info_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "dormitory_information_table_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_type_non_trans_id",
                table: "dormitory_type_translation",
                column: "dormitory_type_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "dormitory_type_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_facility_id",
                table: "facility_option",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "IX_facility_option_non_trans_id",
                table: "facility_option_translation",
                column: "facility_option_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "facility_option_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_facility_table_non_trans_id",
                table: "facility_table_translation",
                column: "facility_table_non_trans_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "facility_table_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_facility_id",
                table: "room_facility",
                column: "facility_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_id",
                table: "room_facility",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_dormitory_id",
                table: "room_table",
                column: "dormitory_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_id",
                table: "room_table_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_table_non_trans_id",
                table: "room_table_translation",
                column: "room_table_non_trans_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_information_parameter_translation");

            migrationBuilder.DropTable(
                name: "account_parameter_values_translation");

            migrationBuilder.DropTable(
                name: "dormitories_table_translation");

            migrationBuilder.DropTable(
                name: "dormitory_information_table_translation");

            migrationBuilder.DropTable(
                name: "dormitory_type_translation");

            migrationBuilder.DropTable(
                name: "facility_option_translation");

            migrationBuilder.DropTable(
                name: "facility_table_translation");

            migrationBuilder.DropTable(
                name: "room_facility");

            migrationBuilder.DropTable(
                name: "room_table_translation");

            migrationBuilder.DropTable(
                name: "account_parameter_values");

            migrationBuilder.DropTable(
                name: "dormitory_information_table");

            migrationBuilder.DropTable(
                name: "facility_option");

            migrationBuilder.DropTable(
                name: "language_table");

            migrationBuilder.DropTable(
                name: "room_table");

            migrationBuilder.DropTable(
                name: "bank_currency_table");

            migrationBuilder.DropTable(
                name: "account_information_parameter");

            migrationBuilder.DropTable(
                name: "facility_table");

            migrationBuilder.DropTable(
                name: "dormitory_bank_account_table");

            migrationBuilder.DropTable(
                name: "dormitories_table");

            migrationBuilder.DropTable(
                name: "dormitory_type");
        }
    }
}
