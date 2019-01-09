
//using Dau.Core.Domain.BankAccount;
//using Dau.Core.Domain.Dormitory;
//using Dau.Core.Domain.Facility;
//using Dau.Core.Domain.Room;
//using Dau.Core.Domain.Language;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dau.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;

//using Dau.Data.Mapping.BankAccount;
//using Dau.Data.Mapping.Dormitory;
//using Dau.Data.Mapping.Facility;
//using Dau.Data.Mapping.Language;
//using Dau.Data.Mapping.Room;
using Dau.Core.Domain.Logging;
using Dau.Data.Mapping.Logging;
using Dau.Data.Mapping.User;
using Microsoft.Extensions.Configuration;
using Dau.Core.Domain.Activity;
using Dau.Core.Domain.Addresses;
using Dau.Core.Domain.API;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.ContentManagement;
using Dau.Core.Domain.CountryInformation;
using Dau.Core.Domain.CurrencyInformation;
using Dau.Core.Domain.EmailAccountInformation;
using Dau.Core.Domain.MobileAppManager;
using Dau.Core.Domain.Notifications;
using Dau.Core.Domain.Promotions;

using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Core.Domain.System;
using Dau.Data.Mapping.Activity;
using Dau.Data.Mapping.Addresses;
using Dau.Data.Mapping.API;
using Dau.Data.Mapping.Catalog;
using Dau.Data.Mapping.ContentManagement;
using Dau.Data.Mapping.CountryInformation;
using Dau.Data.Mapping.CurrencyInformation;
using Dau.Data.Mapping.EmailAccountInformation;
using Dau.Data.Mapping.MobileAppManager;
using Dau.Data.Mapping.Notifications;
using Dau.Data.Mapping.Promotions;

using Dau.Data.Mapping.SearchEngineOptimization;
using Dau.Data.Mapping.System;
using Dau.Data.Extensions;
using Dau.Core.Domain.Localization;
using Dau.Core.Domain.Feature;
using Dau.Data.Mapping.Feature;
using Dau.Core.Domain.Bookings;
using Dau.Data.Mapping.Bookings;
using Dau.Core.Domain;
using Dau.Data.Mapping.EmuMap;
using Dau.Core.Domain.EmuMap;
using Dau.Data.Mapping.LocationInformations;
using Dau.Core.Domain.LocationInformations;

namespace Dau.Data
{
    public partial class Fees_and_facilitiesContext : IdentityDbContext<User, UserRole,string>
    {
        public Fees_and_facilitiesContext(DbContextOptions<Fees_and_facilitiesContext> options)
            : base(options)
        {
        }

      
  
        //new tables
        public virtual DbSet<Log> Log{ get; set; }
        public virtual DbSet<OnlineUsers> OnlineUsers{ get; set; }
        public virtual DbSet<ActivityLog> ActivityLog{ get; set; }
        public virtual DbSet<Address> Address{ get; set; }
        public virtual DbSet<APIClient> APIClient{ get; set; }
        public virtual DbSet<APISettings> APISettings{ get; set; }
        public virtual DbSet<DormitoryBlock> DormitoryBlock { get; set; }
        public virtual DbSet<DormitoryBlockTranslation> DormitoryBlockTranslation { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplate { get; set; }
        public virtual DbSet<MessageTemplateTranslation> MessageTemplateTranslation { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<PollAnswers> PollAnswers { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyQuestionsAndAnswers> SurveyQuestionsAndAnswers { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TopicTranslation> TopicTranslation { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryTranslation> CountryTranslation { get; set; }
        public virtual DbSet<StateAndProvince> StateAndProvince { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyTranslation> CurrencyTranslation { get; set; }
        public virtual DbSet<EmailAccount> EmailAccount { get; set; }
        public virtual DbSet<PushNotification> PushNotification { get; set; }
        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Affiliate> Affiliate { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<NewsLetterSubscribers> NewsLetterSubscribers { get; set; }
        public virtual DbSet<CancelBookingRequests> CancelReservationRequests { get; set; }
        public virtual DbSet<BookingNotes> OrderNotes { get; set; }
        public virtual DbSet<Booking> Reservation { get; set; }

        public virtual DbSet<Seo> Seo { get; set; }
        public virtual DbSet<MessageQueue> MessageQueue { get; set; }


        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Resource> Resource{ get; set; }


        public virtual DbSet<Features> Features{ get; set; }
        public virtual DbSet<FeaturesCategory> FeaturesCategory{ get; set; }
        public virtual DbSet<FeaturesTranslation> FeaturesTranslations{ get; set; }
        public virtual DbSet<FeaturesCategoryTranslation> GetFeaturesCategoryTranslations{ get; set; }



        public virtual DbSet<Dormitory> Dormitory{ get; set; }
        public virtual DbSet<DormitoryTranslation> DormitoryTranslation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomTranslation> RoomTranslation { get; set; }
        public virtual DbSet<CatalogImage> CatalogImages{ get; set; }


        public virtual DbSet<BookingStatus> BookingStatus{ get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus{ get; set; }
        public virtual DbSet<PaymentStatusTranslation> PaymentStatusTranslations{ get; set; }
        public virtual DbSet<BookingStatusTranslation> BookingStatusTranslations{ get; set; }


        public virtual DbSet<ApiDebugLog> ApiDebugLog { get; set; }

        public virtual DbSet<DormitoryType> DormitoryType{ get; set; }
        public virtual DbSet<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }


        public virtual DbSet<Cart> Cart{ get; set; }
        public virtual DbSet<SemesterPeriod> SemesterPeriod{ get; set; }
        public virtual DbSet<SemesterPeriodTranslation> SemesterPeriodTranslation{ get; set; }


        public virtual DbSet<MapSection> MapSection{ get; set; }
        public virtual DbSet<MapSectionTranslation> MapSectionTranslation{ get; set; }

        public virtual DbSet<MapSectionCategory> MapSectionCategory { get; set; }
        public virtual DbSet<MapSectionCategoryTranslation> MapSectionCategoryTranslation { get; set; }

        public virtual DbSet<Locationinformation> Locationinformation{ get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


   // optionsBuilder.UseSqlServer("Data Source=DARK-SHILLA\\SQLEXPRESS;Initial Catalog=SearchDormDb;Integrated Security=True");
     // optionsBuilder.UseSqlServer("Data Source=DARK-SHILLA\\SQLEXPRESS;Initial Catalog=fees_and_facilities;Integrated Security=True");
            //  optionsBuilder.UseSqlServer("data source=193.140.173.173;initial catalog=SearchDormDb;user id=SearchDormUsr;password=ergec.senturk@emu.edu.tr;multipleactiveresultsets=True;");
            //optionsBuilder.UseSqlServer("data source=sql6006.site4now.net;initial catalog=DB_A2B24A_testing;user id=DB_A2B24A_testing_admin;password=Mami1961;multipleactiveresultsets=True;");
          // optionsBuilder.UseSqlServer("Data Source=SQL-SERVER-INST;Initial Catalog=fees_and_facilities_prod;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new OnlineUsersMap());



            modelBuilder.ApplyConfiguration(new ActivityLogMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new APIClientMap());
            modelBuilder.ApplyConfiguration(new APISettingsMap());
            modelBuilder.ApplyConfiguration(new DormitoryBlockMap());
            modelBuilder.ApplyConfiguration(new DormitoryBlockTranslationMap());
            modelBuilder.ApplyConfiguration(new ReviewMap());
            modelBuilder.ApplyConfiguration(new MessageTemplateMap());
            modelBuilder.ApplyConfiguration(new MessageTemplateTranslationMap());
            modelBuilder.ApplyConfiguration(new PollMap());
            modelBuilder.ApplyConfiguration(new PollAnswersMap());
            modelBuilder.ApplyConfiguration(new SurveyMap());
            modelBuilder.ApplyConfiguration(new SurveyQuestionsAndAnswersMap());
            modelBuilder.ApplyConfiguration(new TopicMap());
            modelBuilder.ApplyConfiguration(new TopicTranslationMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new CountryTranslationMap());
            modelBuilder.ApplyConfiguration(new StateAndProvinceMap());
            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new CurrencyTranslationMap());
            modelBuilder.ApplyConfiguration(new EmailAccountMap());
            modelBuilder.ApplyConfiguration(new PushNotificationMap());
            modelBuilder.ApplyConfiguration(new AnnouncementsMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new AffiliateMap());
            modelBuilder.ApplyConfiguration(new CampaignMap());
            modelBuilder.ApplyConfiguration(new DiscountMap());
            modelBuilder.ApplyConfiguration(new NewsletterSubscribersMap());
            modelBuilder.ApplyConfiguration(new CancelBookingRequestMap());
            modelBuilder.ApplyConfiguration(new BookingNotesMap());
            modelBuilder.ApplyConfiguration(new BookingMap());
   
            modelBuilder.ApplyConfiguration(new SeoMap());
            modelBuilder.ApplyConfiguration(new MessageQueueMap());


            modelBuilder.ApplyConfiguration(new FeaturesMap());
            modelBuilder.ApplyConfiguration(new FeaturesCategoryMap());
            modelBuilder.ApplyConfiguration(new FeaturesCategoryTranslationMap());
            modelBuilder.ApplyConfiguration(new FeaturesTranslationMap());


            modelBuilder.ApplyConfiguration(new DormitoryMap());
            modelBuilder.ApplyConfiguration(new DormitoryTranslationMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new RoomTranslationMap());
            modelBuilder.ApplyConfiguration(new CatalogImageMap());


            modelBuilder.ApplyConfiguration(new DormitoryFeaturesMap());
            modelBuilder.ApplyConfiguration(new RoomFeaturesMap());
            modelBuilder.ApplyConfiguration(new RoomMap());

            modelBuilder.ApplyConfiguration(new DormitoryCatalogImageMap());
            modelBuilder.ApplyConfiguration(new RoomCatalogImageMap());


            modelBuilder.ApplyConfiguration(new BookingStatusMap());
            modelBuilder.ApplyConfiguration(new PaymentStatusMap());
            modelBuilder.ApplyConfiguration(new PaymentStatusTranslationMap());
            modelBuilder.ApplyConfiguration(new BookingStatusTranslationMap());


            modelBuilder.ApplyConfiguration(new DormitoryTypeMap());
            modelBuilder.ApplyConfiguration(new DormitoryTypeTranslationMap());


            modelBuilder.ApplyConfiguration(new SemesterPeriodMap());
            modelBuilder.ApplyConfiguration(new SemesterPeriodTranslationMap());


            modelBuilder.ApplyConfiguration(new MapSectionMap());
            modelBuilder.ApplyConfiguration(new MapSectionTranslationMap());



            modelBuilder.ApplyConfiguration(new MapSectionCategoryMap());
            modelBuilder.ApplyConfiguration(new MapSectionCategoryTranslationMap());
            modelBuilder.ApplyConfiguration(new LocationInformationMap());




        }
    }
}
