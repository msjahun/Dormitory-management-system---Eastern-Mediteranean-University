using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class AddedNewTAblesAndConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryBlockTranslation_language_table_LanguageId",
                table: "DormitoryBlockTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                table: "MessageTemplateTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTemplateTranslation_MessageTemplate_MessageTemplateNonTransId",
                table: "MessageTemplateTranslation");

            migrationBuilder.RenameColumn(
                name: "MessageTemplateNonTransId",
                table: "MessageTemplateTranslation",
                newName: "MessageTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageTemplateTranslation_MessageTemplateNonTransId",
                table: "MessageTemplateTranslation",
                newName: "IX_MessageTemplateTranslation_MessageTemplateId");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "DormitoryBlockTranslation",
                newName: "language_id");

            migrationBuilder.RenameIndex(
                name: "IX_DormitoryBlockTranslation_LanguageId",
                table: "DormitoryBlockTranslation",
                newName: "IX_DormitoryBlockTranslation_language_id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TopicTranslation",
                unicode: false,
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "TopicTranslation",
                unicode: false,
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemName",
                table: "Topic",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topic",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StateAndProvince",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "StateAndProvince",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchEngineFriendlyPageName",
                table: "Seo",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "Seo",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaKeywords",
                table: "Seo",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Seo",
                unicode: false,
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "StaticFileUrl",
                table: "MessageTemplate",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MessageTemplate",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AllowedTokens",
                table: "MessageTemplate",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DormitoryBlockTranslation",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DormitoryBlockTranslation",
                unicode: false,
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "DormitoryBlock",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DormitoryBlock",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DormitoryBlock",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CurrencyTranslation",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomFormatting",
                table: "Currency",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Currency",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CountryTranslation",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TwoLetterIsoCode",
                table: "Country",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThreeLetterIsoCode",
                table: "Country",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ActivityLogTypeId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ActivityPerformed = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ActivityCategory = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Address2 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    StateProvinceId = table.Column<int>(nullable: false),
                    ZipPostalCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    FriendlyURLName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    LoadOnlyWithOrders = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Company = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Country = table.Column<int>(nullable: false),
                    StateProvince = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Address2 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ZipPostalCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    AdminComment = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    AffiliateURL = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Message = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiClient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ClientId = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ClientSecret = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    RedirectUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    AccessTokenLifeTime = table.Column<int>(nullable: false),
                    RefreshTokenLifeTime = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APISettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnableAPI = table.Column<bool>(nullable: false),
                    AllowRequestsFromSwagger = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APISettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedTokens = table.Column<string>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Subject = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    PlannedDateOfSending = table.Column<DateTime>(nullable: false),
                    LimitedToCustomerRole = table.Column<int>(nullable: false),
                    EmailAccount = table.Column<int>(nullable: false),
                    SendTestEmailTo = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CancelReservationRequest",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BookingNumber = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ReturnRequestStatus = table.Column<int>(nullable: false),
                    ReasonForCancellation = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    RequestedAction = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    CustomerComment = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    StaffNotes = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancellationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelReservationRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CouponCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DiscountType = table.Column<int>(nullable: false),
                    UsePercentage = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    Discount_RequiresCouponCode = table.Column<bool>(nullable: false),
                    RequiresCouponCode = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CumulativeWithOtherDiscounts = table.Column<bool>(nullable: false),
                    DiscountLimitation = table.Column<int>(nullable: false),
                    DiscountRequirementType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    EmailDisplayName = table.Column<string>(unicode: false, maxLength: 246, nullable: true),
                    Host = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    SSL = table.Column<bool>(nullable: false),
                    UseDefaultCredentials = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageQueue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromAddress = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ToAddress = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    LoadNotSentEmailsOnly = table.Column<bool>(nullable: false),
                    MaximumSentAttempts = table.Column<int>(nullable: false),
                    MessagePriority = table.Column<int>(nullable: false),
                    FromName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ToName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ReplyTo = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    ReplyToName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    CC = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    BCC = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Subject = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendImmediately = table.Column<bool>(nullable: false),
                    SendAttempts = table.Column<int>(nullable: false),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAccount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageQueue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CustomerRoles = table.Column<int>(nullable: false),
                    SubscribedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SystemKeyword = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    ShowOnHomePage = table.Column<bool>(nullable: false),
                    AllowGuestsToVote = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PushNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedTokens = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Subject = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    PlannedDateOfSending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LimitedToCustomerRole = table.Column<int>(nullable: false),
                    NotificationAccount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(nullable: false),
                    DormitoryId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ReviewText = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ReplyText = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Picture = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SystemKeyword = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    ShowOnHomePage = table.Column<bool>(nullable: false),
                    AllowGuestsToVote = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingStatus = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    BillingEmail = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    BillingFirstName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    BillingLastName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    BillingCountry = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    BookingNotes = table.Column<int>(nullable: false),
                    BookingNumber = table.Column<int>(nullable: false),
                    DormitoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CustomerIpAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BookingOrderSubtotal = table.Column<double>(nullable: false),
                    BookingFee = table.Column<double>(nullable: false),
                    BookingTotal = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAddressId = table.Column<int>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsAffiliateBooking = table.Column<bool>(nullable: false),
                    AffiliateId = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountUsage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Used = table.Column<bool>(nullable: false),
                    BookingNumber = table.Column<string>(nullable: true),
                    BookingTotal = table.Column<double>(nullable: false),
                    DiscountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountUsage_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    NumberOfVotes = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    PollId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollAnswers_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionsAndAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NumberOfParticipants = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionsAndAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionsAndAnswers_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowToCustomer = table.Column<bool>(nullable: false),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotes_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountUsage_DiscountId",
                table: "DiscountUsage",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_ReservationId",
                table: "OrderNotes",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswers_PollId",
                table: "PollAnswers",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BillingAddressId",
                table: "Reservation",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAndAnswers_SurveyId",
                table: "SurveyQuestionsAndAnswers",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryBlockTranslation_language_table_language_id",
                table: "DormitoryBlockTranslation",
                column: "language_id",
                principalTable: "language_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                table: "MessageTemplateTranslation",
                column: "LanguageId",
                principalTable: "language_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.MessageTemplateTranslation_dbo.MessageTemplate_MessageTemplateId",
                table: "MessageTemplateTranslation",
                column: "MessageTemplateId",
                principalTable: "MessageTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DormitoryBlockTranslation_language_table_language_id",
                table: "DormitoryBlockTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                table: "MessageTemplateTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.MessageTemplateTranslation_dbo.MessageTemplate_MessageTemplateId",
                table: "MessageTemplateTranslation");

            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Affiliate");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "ApiClient");

            migrationBuilder.DropTable(
                name: "APISettings");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "CancelReservationRequest");

            migrationBuilder.DropTable(
                name: "DiscountUsage");

            migrationBuilder.DropTable(
                name: "EmailAccount");

            migrationBuilder.DropTable(
                name: "MessageQueue");

            migrationBuilder.DropTable(
                name: "NewsletterSubscribers");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrderNotes");

            migrationBuilder.DropTable(
                name: "PollAnswers");

            migrationBuilder.DropTable(
                name: "PushNotification");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "RoomReservation");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsAndAnswers");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.RenameColumn(
                name: "MessageTemplateId",
                table: "MessageTemplateTranslation",
                newName: "MessageTemplateNonTransId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageTemplateTranslation_MessageTemplateId",
                table: "MessageTemplateTranslation",
                newName: "IX_MessageTemplateTranslation_MessageTemplateNonTransId");

            migrationBuilder.RenameColumn(
                name: "language_id",
                table: "DormitoryBlockTranslation",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_DormitoryBlockTranslation_language_id",
                table: "DormitoryBlockTranslation",
                newName: "IX_DormitoryBlockTranslation_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TopicTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "TopicTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemName",
                table: "Topic",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topic",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StateAndProvince",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "StateAndProvince",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchEngineFriendlyPageName",
                table: "Seo",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "Seo",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaKeywords",
                table: "Seo",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Seo",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 2000,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "StaticFileUrl",
                table: "MessageTemplate",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MessageTemplate",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AllowedTokens",
                table: "MessageTemplate",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DormitoryBlockTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DormitoryBlockTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "DormitoryBlock",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DormitoryBlock",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DormitoryBlock",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CurrencyTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomFormatting",
                table: "Currency",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Currency",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CountryTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TwoLetterIsoCode",
                table: "Country",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThreeLetterIsoCode",
                table: "Country",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DormitoryBlockTranslation_language_table_LanguageId",
                table: "DormitoryBlockTranslation",
                column: "LanguageId",
                principalTable: "language_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                table: "MessageTemplateTranslation",
                column: "LanguageId",
                principalTable: "language_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTemplateTranslation_MessageTemplate_MessageTemplateNonTransId",
                table: "MessageTemplateTranslation",
                column: "MessageTemplateNonTransId",
                principalTable: "MessageTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
