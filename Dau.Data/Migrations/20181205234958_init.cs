using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dau.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Localization");

            migrationBuilder.CreateTable(
                name: "account_information_parameter",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_information_parameter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ActivityLogTypeId = table.Column<long>(nullable: false),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Address2 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    StateProvinceId = table.Column<long>(nullable: false),
                    ZipPostalCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnableAPI = table.Column<bool>(nullable: false),
                    AllowRequestsFromSwagger = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APISettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Access = table.Column<string>(nullable: true),
                    IsSystemRole = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AffiliateId = table.Column<long>(nullable: false),
                    DormitoryId = table.Column<long>(nullable: false),
                    AdminComment = table.Column<string>(nullable: true),
                    NewsletterSubscription = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    LastIpAddress = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LastLoginDateUtc = table.Column<DateTime>(nullable: true),
                    LastActivityDateUtc = table.Column<DateTime>(nullable: false),
                    RegisteredInStoreId = table.Column<int>(nullable: false),
                    BillingAddressId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingNumber = table.Column<long>(nullable: false),
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
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowBilling = table.Column<bool>(nullable: false),
                    AllowBooking = table.Column<bool>(nullable: false),
                    TwoLetterIsoCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ThreeLetterIsoCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    DisplayLocale = table.Column<int>(nullable: false),
                    CustomFormatting = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    RoundingType = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                name: "dormitory_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                name: "EventLog",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<long>(nullable: false),
                    LogLevel = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Message = table.Column<string>(unicode: false, maxLength: 4000, nullable: false),
                    Ipaddress = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "facility_table",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    language_code = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MessageQueue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                name: "MessageTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedTokens = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SendImmediately = table.Column<bool>(nullable: false),
                    AttachedStaticFile = table.Column<bool>(nullable: false),
                    StaticFileUrl = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterSubscribers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineUsers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserInfo = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastActivity = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastVisitedPage = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    LastActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                name: "Seo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaKeywords = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    MetaTitle = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    SearchEngineFriendlyPageName = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                name: "Language",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CultureName = table.Column<string>(maxLength: 255, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 255, nullable: false),
                    Country = table.Column<string>(maxLength: 255, nullable: false),
                    Region = table.Column<string>(maxLength: 255, nullable: false),
                    IsDefaultLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    BillingAddressId = table.Column<long>(nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateAndProvince",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Abbreviation = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CountryId = table.Column<long>(nullable: true)
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
                name: "DiscountUsage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Used = table.Column<bool>(nullable: false),
                    BookingNumber = table.Column<string>(nullable: true),
                    BookingTotal = table.Column<double>(nullable: false),
                    DiscountId = table.Column<long>(nullable: true)
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
                name: "dormitories_table",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_type_id = table.Column<long>(nullable: false),
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_type_id = table.Column<long>(nullable: false)
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    facility_id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false),
                    account_info_non_trans_id = table.Column<long>(nullable: false),
                    language_id = table.Column<long>(nullable: false),
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
                name: "CountryTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    CountryNonTransId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CountryNonTransId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslation", x => new { x.CountryNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CountryTranslation_Country_CountryNonTransId1",
                        column: x => x.CountryNonTransId1,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountryTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    CurrencyNonTransId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CurrencyNonTransId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTranslation", x => new { x.CurrencyNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Currency_CurrencyNonTransId1",
                        column: x => x.CurrencyNonTransId1,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dormitory_type_translation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    dormitory_type_non_trans_id = table.Column<long>(nullable: false),
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
                    language_id = table.Column<long>(nullable: false),
                    facility_table_non_trans_id = table.Column<long>(nullable: false),
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
                name: "MessageTemplateTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    MessageTemplateId = table.Column<long>(nullable: false),
                    Subject = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 1024, nullable: true),
                    BCC = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    EmailAccount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplateTranslation", x => new { x.MessageTemplateId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MessageTemplateTranslation_language_table_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.MessageTemplateTranslation_dbo.MessageTemplate_MessageTemplateId",
                        column: x => x.MessageTemplateId,
                        principalTable: "MessageTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    NumberOfVotes = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    PollId = table.Column<long>(nullable: true)
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
                name: "DormitoryBlock",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SeoId = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    SystemName = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    PasswordProtected = table.Column<bool>(nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn1 = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn2 = table.Column<bool>(nullable: false),
                    IncludeInFooterColumn3 = table.Column<bool>(nullable: false),
                    IncludeInSitemap = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    AccesibleWhenSiteIsClosed = table.Column<bool>(nullable: false),
                    SeoId = table.Column<long>(nullable: false)
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
                name: "SurveyQuestionsAndAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NumberOfParticipants = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SurveyId = table.Column<long>(nullable: true)
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
                name: "Resource",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(maxLength: 255, nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowToCustomer = table.Column<bool>(nullable: false),
                    ReservationId = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "dormitories_table_translation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    dormitories_table_non_trans_id = table.Column<long>(nullable: false),
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_id = table.Column<long>(nullable: false),
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dormitory_id = table.Column<long>(nullable: false),
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
                    language_id = table.Column<long>(nullable: false),
                    dormitory_info_non_trans_id = table.Column<long>(nullable: false),
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
                    language_id = table.Column<long>(nullable: false),
                    facility_option_non_trans_id = table.Column<long>(nullable: false),
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
                name: "DormitoryBlockTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    DormitoryBlockNonTransId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBlockTranslation", x => new { x.DormitoryBlockNonTransId, x.language_id });
                    table.ForeignKey(
                        name: "FK_DormitoryBlockTranslation_DormitoryBlock_DormitoryBlockNonTransId",
                        column: x => x.DormitoryBlockNonTransId,
                        principalTable: "DormitoryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryBlockTranslation_language_table_language_id",
                        column: x => x.language_id,
                        principalTable: "language_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    TopicNonTransId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTranslation", x => new { x.TopicNonTransId, x.LanguageId });
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

            migrationBuilder.CreateTable(
                name: "bank_currency_table",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_id = table.Column<long>(nullable: false),
                    ExchangeRage = table.Column<long>(nullable: false),
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    facility_id = table.Column<long>(nullable: false),
                    room_id = table.Column<long>(nullable: false),
                    facility_option_id = table.Column<long>(nullable: true)
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
                    language_id = table.Column<long>(nullable: false),
                    room_table_non_trans_id = table.Column<long>(nullable: false),
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
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    currency_id = table.Column<long>(nullable: false),
                    parameter_id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false),
                    language_id = table.Column<long>(nullable: false),
                    account_params_values_non_trans_id = table.Column<long>(nullable: false),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_bank_id",
                table: "bank_currency_table",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslation_CountryNonTransId1",
                table: "CountryTranslation",
                column: "CountryNonTransId1");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslation_LanguageId",
                table: "CountryTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_CurrencyNonTransId1",
                table: "CurrencyTranslation",
                column: "CurrencyNonTransId1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTranslation_LanguageId",
                table: "CurrencyTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountUsage_DiscountId",
                table: "DiscountUsage",
                column: "DiscountId");

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
                name: "IX_DormitoryBlock_SeoId",
                table: "DormitoryBlock",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlockTranslation_language_id",
                table: "DormitoryBlockTranslation",
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
                name: "IX_MessageTemplateTranslation_LanguageId",
                table: "MessageTemplateTranslation",
                column: "LanguageId");

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

            migrationBuilder.CreateIndex(
                name: "IX_StateAndProvince_CountryId",
                table: "StateAndProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAndAnswers_SurveyId",
                table: "SurveyQuestionsAndAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SeoId",
                table: "Topic",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicTranslation_LanguageId",
                table: "TopicTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_LanguageId",
                schema: "Localization",
                table: "Resource",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_information_parameter_translation");

            migrationBuilder.DropTable(
                name: "account_parameter_values_translation");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "CancelReservationRequest");

            migrationBuilder.DropTable(
                name: "CountryTranslation");

            migrationBuilder.DropTable(
                name: "CurrencyTranslation");

            migrationBuilder.DropTable(
                name: "DiscountUsage");

            migrationBuilder.DropTable(
                name: "dormitories_table_translation");

            migrationBuilder.DropTable(
                name: "dormitory_information_table_translation");

            migrationBuilder.DropTable(
                name: "dormitory_type_translation");

            migrationBuilder.DropTable(
                name: "DormitoryBlockTranslation");

            migrationBuilder.DropTable(
                name: "EmailAccount");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "facility_option_translation");

            migrationBuilder.DropTable(
                name: "facility_table_translation");

            migrationBuilder.DropTable(
                name: "MessageQueue");

            migrationBuilder.DropTable(
                name: "MessageTemplateTranslation");

            migrationBuilder.DropTable(
                name: "NewsletterSubscribers");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OnlineUsers");

            migrationBuilder.DropTable(
                name: "OrderNotes");

            migrationBuilder.DropTable(
                name: "PollAnswers");

            migrationBuilder.DropTable(
                name: "PushNotification");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "room_facility");

            migrationBuilder.DropTable(
                name: "room_table_translation");

            migrationBuilder.DropTable(
                name: "RoomReservation");

            migrationBuilder.DropTable(
                name: "StateAndProvince");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsAndAnswers");

            migrationBuilder.DropTable(
                name: "TopicTranslation");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "account_parameter_values");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "dormitory_information_table");

            migrationBuilder.DropTable(
                name: "DormitoryBlock");

            migrationBuilder.DropTable(
                name: "facility_option");

            migrationBuilder.DropTable(
                name: "MessageTemplate");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "room_table");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "language_table");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "bank_currency_table");

            migrationBuilder.DropTable(
                name: "account_information_parameter");

            migrationBuilder.DropTable(
                name: "facility_table");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Seo");

            migrationBuilder.DropTable(
                name: "dormitory_bank_account_table");

            migrationBuilder.DropTable(
                name: "dormitories_table");

            migrationBuilder.DropTable(
                name: "dormitory_type");
        }
    }
}
