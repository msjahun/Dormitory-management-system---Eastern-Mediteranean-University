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
                    UserImageUrl = table.Column<string>(nullable: true),
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
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
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
                name: "CancelBookingRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<long>(nullable: false),
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
                    table.PrimaryKey("PK_CancelBookingRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogImages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogImages", x => x.Id);
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
                name: "FeaturesCategory",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesCategory", x => x.id);
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
                name: "OpeningClosingTime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpeningTime = table.Column<int>(nullable: false),
                    ClosingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningClosingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
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
                name: "Features",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPublished = table.Column<bool>(nullable: false),
                    IconUrl = table.Column<string>(nullable: true),
                    FeaturesCategoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.id);
                    table.ForeignKey(
                        name: "FK_Features_FeaturesCategory_FeaturesCategoryId",
                        column: x => x.FeaturesCategoryId,
                        principalTable: "FeaturesCategory",
                        principalColumn: "id",
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
                name: "Dormitory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoOfStudents = table.Column<int>(nullable: false),
                    RatingNo = table.Column<double>(nullable: false),
                    ReviewNo = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    NoOfNewFacilities = table.Column<int>(nullable: false),
                    NoOfStaff = table.Column<int>(nullable: false),
                    NoOfAwards = table.Column<int>(nullable: false),
                    MapSection = table.Column<string>(nullable: true),
                    DormitoryStreetAddress = table.Column<string>(nullable: true),
                    DormitoryLogoUrl = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SeoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dormitory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dormitory_Seo_SeoId",
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
                name: "BookingStatusTranslations",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    BookingStatusNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    BookingStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatusTranslations", x => new { x.language_id, x.BookingStatusNonTransId });
                    table.ForeignKey(
                        name: "FK_BookingStatusTranslations_BookingStatus_BookingStatusNonTransId",
                        column: x => x.BookingStatusNonTransId,
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingStatusTranslations_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    CountryNonTransId = table.Column<int>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CountryNonTransId1 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslation", x => new { x.CountryNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CountryTranslation_Country_CountryNonTransId1",
                        column: x => x.CountryNonTransId1,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    CurrencyNonTransId = table.Column<int>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CurrencyNonTransId1 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTranslation", x => new { x.CurrencyNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Currency_CurrencyNonTransId1",
                        column: x => x.CurrencyNonTransId1,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesCategoryTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    FeaturesCategoryNonTransId = table.Column<long>(name: "FeaturesCategoryNonTransId ", nullable: false),
                    Id = table.Column<long>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesCategoryTranslation", x => new { x.language_id, x.FeaturesCategoryNonTransId });
                    table.ForeignKey(
                        name: "FK_FeaturesCategoryTranslation_FeaturesCategory_FeaturesCategoryNonTransId ",
                        column: x => x.FeaturesCategoryNonTransId,
                        principalTable: "FeaturesCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturesCategoryTranslation_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageTemplateTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    MessageTemplateId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Subject = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 1024, nullable: true),
                    BCC = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    EmailAccount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplateTranslation", x => new { x.MessageTemplateId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MessageTemplateTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.MessageTemplateTranslation_dbo.MessageTemplate_MessageTemplateId",
                        column: x => x.MessageTemplateId,
                        principalTable: "MessageTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatusTranslations",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    PaymentStatusNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatusTranslations", x => new { x.language_id, x.PaymentStatusNonTransId });
                    table.ForeignKey(
                        name: "FK_PaymentStatusTranslations_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentStatusTranslations_PaymentStatus_PaymentStatusNonTransId",
                        column: x => x.PaymentStatusNonTransId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "FeaturesTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    FeaturesNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    FeatureName = table.Column<string>(nullable: true),
                    FeatureDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesTranslation", x => new { x.language_id, x.FeaturesNonTransId });
                    table.ForeignKey(
                        name: "FK_FeaturesTranslation_Features_FeaturesNonTransId",
                        column: x => x.FeaturesNonTransId,
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturesTranslation_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryBlock",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PictureUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    DormitoryId = table.Column<long>(nullable: true),
                    SeoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DormitoryBlock_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DormitoryBlock_Seo_SeoId",
                        column: x => x.SeoId,
                        principalTable: "Seo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryCatalogImage",
                columns: table => new
                {
                    DormitoryId = table.Column<long>(nullable: false),
                    CatalogImageId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryCatalogImage", x => new { x.DormitoryId, x.CatalogImageId });
                    table.ForeignKey(
                        name: "FK_DormitoryCatalogImage_CatalogImages_CatalogImageId",
                        column: x => x.CatalogImageId,
                        principalTable: "CatalogImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryCatalogImage_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryFeatures",
                columns: table => new
                {
                    DormitoryId = table.Column<long>(nullable: false),
                    FeaturesId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryFeatures", x => new { x.DormitoryId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_DormitoryFeatures_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryFeatures_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    DormitoryNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    DormitoryName = table.Column<string>(nullable: true),
                    DormitoryDescription = table.Column<string>(nullable: true),
                    RatingText = table.Column<string>(nullable: true),
                    Option = table.Column<string>(nullable: true),
                    OptionValue = table.Column<string>(nullable: true),
                    StandAloneOption = table.Column<string>(nullable: true),
                    LocationRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryTranslation", x => new { x.DormitoryNonTransId, x.language_id });
                    table.ForeignKey(
                        name: "FK_DormitoryTranslation_Dormitory_DormitoryNonTransId",
                        column: x => x.DormitoryNonTransId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DormitoryTranslation_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodToKnow",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryId = table.Column<long>(nullable: false),
                    WeekdaysOpeningTimeId = table.Column<long>(nullable: true),
                    WeekendsOpeningTimeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodToKnow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodToKnow_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodToKnow_OpeningClosingTime_WeekdaysOpeningTimeId",
                        column: x => x.WeekdaysOpeningTimeId,
                        principalTable: "OpeningClosingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodToKnow_OpeningClosingTime_WeekendsOpeningTimeId",
                        column: x => x.WeekendsOpeningTimeId,
                        principalTable: "OpeningClosingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locationinformation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryId = table.Column<long>(nullable: false),
                    NameOfLocation = table.Column<string>(nullable: true),
                    Distance = table.Column<string>(nullable: true),
                    MapSection = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DormitoryId = table.Column<long>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicTranslation",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false),
                    TopicNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    Body = table.Column<string>(unicode: false, maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTranslation", x => new { x.TopicNonTransId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_TopicTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicTranslation_Topic_TopicNonTransId",
                        column: x => x.TopicNonTransId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryBlockTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    DormitoryBlockNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
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
                        name: "FK_DormitoryBlockTranslation_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoOfStudents = table.Column<int>(nullable: false),
                    RoomsQuota = table.Column<int>(nullable: false),
                    HasDeposit = table.Column<bool>(nullable: false),
                    ShowPrice = table.Column<bool>(nullable: false),
                    DormitoryBlockId = table.Column<long>(nullable: true),
                    DormitoryId = table.Column<long>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PriceOld = table.Column<double>(nullable: false),
                    NoRoomQuota = table.Column<int>(nullable: false),
                    SeoId = table.Column<long>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_DormitoryBlock_DormitoryBlockId",
                        column: x => x.DormitoryBlockId,
                        principalTable: "DormitoryBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Dormitory_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Seo_SeoId",
                        column: x => x.SeoId,
                        principalTable: "Seo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodToKnowTitleValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(nullable: true),
                    GoodToKnowId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodToKnowTitleValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodToKnowTitleValue_GoodToKnow_GoodToKnowId",
                        column: x => x.GoodToKnowId,
                        principalTable: "GoodToKnow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingStatusId = table.Column<long>(nullable: false),
                    PaymentStatusId = table.Column<long>(nullable: false),
                    BookingNotes = table.Column<int>(nullable: false),
                    DormitoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: false),
                    CustomerIpAddress = table.Column<string>(nullable: true),
                    BookingOrderSubtotal = table.Column<double>(nullable: false),
                    BookingFee = table.Column<double>(nullable: false),
                    BookingTotal = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    BillingAddressId = table.Column<long>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AffiliateId = table.Column<bool>(nullable: false),
                    RoomId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_BookingStatus_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomCatalogImage",
                columns: table => new
                {
                    RoomId = table.Column<long>(nullable: false),
                    CatalogImageId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCatalogImage", x => new { x.RoomId, x.CatalogImageId });
                    table.ForeignKey(
                        name: "FK_RoomCatalogImage_CatalogImages_CatalogImageId",
                        column: x => x.CatalogImageId,
                        principalTable: "CatalogImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCatalogImage_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatures",
                columns: table => new
                {
                    RoomId = table.Column<long>(nullable: false),
                    FeaturesId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatures", x => new { x.RoomId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_RoomFeatures_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTranslationTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    RoomNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    GenderAllocation = table.Column<string>(nullable: true),
                    BedType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTranslationTranslation", x => new { x.RoomNonTransId, x.language_id });
                    table.ForeignKey(
                        name: "FK_RoomTranslationTranslation_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTranslationTranslation_Room_RoomNonTransId",
                        column: x => x.RoomNonTransId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodToKnowTitleValueTranslation",
                columns: table => new
                {
                    language_id = table.Column<long>(nullable: false),
                    GoodToKnowTitleValueNonTransId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodToKnowTitleValueTranslation", x => new { x.GoodToKnowTitleValueNonTransId, x.language_id });
                    table.ForeignKey(
                        name: "FK_GoodToKnowTitleValueTranslation_GoodToKnowTitleValue_GoodToKnowTitleValueNonTransId",
                        column: x => x.GoodToKnowTitleValueNonTransId,
                        principalTable: "GoodToKnowTitleValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodToKnowTitleValueTranslation_Language_language_id",
                        column: x => x.language_id,
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
                    BookingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotes_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Booking_BillingAddressId",
                table: "Booking",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingStatusId",
                table: "Booking",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PaymentStatusId",
                table: "Booking",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId1",
                table: "Booking",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStatusTranslations_BookingStatusNonTransId",
                table: "BookingStatusTranslations",
                column: "BookingStatusNonTransId");

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
                name: "IX_Dormitory_SeoId",
                table: "Dormitory",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlock_DormitoryId",
                table: "DormitoryBlock",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlock_SeoId",
                table: "DormitoryBlock",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryBlockTranslation_language_id",
                table: "DormitoryBlockTranslation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryCatalogImage_CatalogImageId",
                table: "DormitoryCatalogImage",
                column: "CatalogImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryFeatures_FeaturesId",
                table: "DormitoryFeatures",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_DormitoryTranslation_language_id",
                table: "DormitoryTranslation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeaturesCategoryId",
                table: "Features",
                column: "FeaturesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesCategoryTranslation_FeaturesCategoryNonTransId ",
                table: "FeaturesCategoryTranslation",
                column: "FeaturesCategoryNonTransId ");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesTranslation_FeaturesNonTransId",
                table: "FeaturesTranslation",
                column: "FeaturesNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodToKnow_DormitoryId",
                table: "GoodToKnow",
                column: "DormitoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodToKnow_WeekdaysOpeningTimeId",
                table: "GoodToKnow",
                column: "WeekdaysOpeningTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodToKnow_WeekendsOpeningTimeId",
                table: "GoodToKnow",
                column: "WeekendsOpeningTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodToKnowTitleValue_GoodToKnowId",
                table: "GoodToKnowTitleValue",
                column: "GoodToKnowId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodToKnowTitleValueTranslation_language_id",
                table: "GoodToKnowTitleValueTranslation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_Locationinformation_DormitoryId",
                table: "Locationinformation",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTemplateTranslation_LanguageId",
                table: "MessageTemplateTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_BookingId",
                table: "OrderNotes",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatusTranslations_PaymentStatusNonTransId",
                table: "PaymentStatusTranslations",
                column: "PaymentStatusNonTransId");

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswers_PollId",
                table: "PollAnswers",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_DormitoryId",
                table: "Review",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DormitoryBlockId",
                table: "Room",
                column: "DormitoryBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DormitoryId",
                table: "Room",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_SeoId",
                table: "Room",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCatalogImage_CatalogImageId",
                table: "RoomCatalogImage",
                column: "CatalogImageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_FeaturesId",
                table: "RoomFeatures",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTranslationTranslation_language_id",
                table: "RoomTranslationTranslation",
                column: "language_id");

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
                name: "BookingStatusTranslations");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "CancelBookingRequest");

            migrationBuilder.DropTable(
                name: "CountryTranslation");

            migrationBuilder.DropTable(
                name: "CurrencyTranslation");

            migrationBuilder.DropTable(
                name: "DiscountUsage");

            migrationBuilder.DropTable(
                name: "DormitoryBlockTranslation");

            migrationBuilder.DropTable(
                name: "DormitoryCatalogImage");

            migrationBuilder.DropTable(
                name: "DormitoryFeatures");

            migrationBuilder.DropTable(
                name: "DormitoryTranslation");

            migrationBuilder.DropTable(
                name: "EmailAccount");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "FeaturesCategoryTranslation");

            migrationBuilder.DropTable(
                name: "FeaturesTranslation");

            migrationBuilder.DropTable(
                name: "GoodToKnowTitleValueTranslation");

            migrationBuilder.DropTable(
                name: "Locationinformation");

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
                name: "PaymentStatusTranslations");

            migrationBuilder.DropTable(
                name: "PollAnswers");

            migrationBuilder.DropTable(
                name: "PushNotification");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "RoomCatalogImage");

            migrationBuilder.DropTable(
                name: "RoomFeatures");

            migrationBuilder.DropTable(
                name: "RoomTranslationTranslation");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "GoodToKnowTitleValue");

            migrationBuilder.DropTable(
                name: "MessageTemplate");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "CatalogImages");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "GoodToKnow");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FeaturesCategory");

            migrationBuilder.DropTable(
                name: "OpeningClosingTime");

            migrationBuilder.DropTable(
                name: "DormitoryBlock");

            migrationBuilder.DropTable(
                name: "Dormitory");

            migrationBuilder.DropTable(
                name: "Seo");
        }
    }
}
