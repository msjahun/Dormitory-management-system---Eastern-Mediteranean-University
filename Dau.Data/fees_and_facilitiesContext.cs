
using Dau.Core.Domain.BankAccount;
using Dau.Core.Domain.Dormitory;
using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Room;
using Dau.Core.Domain.Language;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dau.Core.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Dau.Data
{
    public partial class fees_and_facilitiesContext : IdentityDbContext<User, UserRole,string>
    {
      

        public fees_and_facilitiesContext()
           
        {
        }

        public virtual DbSet<AccountInformationParameter> AccountInformationParameter { get; set; }
        public virtual DbSet<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
        public virtual DbSet<AccountParameterValues> AccountParameterValues { get; set; }
        public virtual DbSet<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
        public virtual DbSet<BankCurrencyTable> BankCurrencyTable { get; set; }
        public virtual DbSet<DormitoriesTable> DormitoriesTable { get; set; }
        public virtual DbSet<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
        public virtual DbSet<DormitoryBankAccountTable> DormitoryBankAccountTable { get; set; }
        public virtual DbSet<DormitoryInformationTable> DormitoryInformationTable { get; set; }
        public virtual DbSet<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
        public virtual DbSet<DormitoryType> DormitoryType { get; set; }
        public virtual DbSet<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
        public virtual DbSet<FacilityOption> FacilityOption { get; set; }
        public virtual DbSet<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
        public virtual DbSet<FacilityTable> FacilityTable { get; set; }
        public virtual DbSet<FacilityTableTranslation> FacilityTableTranslation { get; set; }
        public virtual DbSet<LanguageTable> LanguageTable { get; set; }
       
        public virtual DbSet<RoomFacility> RoomFacility { get; set; }
        public virtual DbSet<RoomTable> RoomTable { get; set; }
        public virtual DbSet<RoomTableTranslation> RoomTableTranslation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



              optionsBuilder.UseSqlServer("Data Source=DARK-SHILLA\\SQLEXPRESS;Initial Catalog=fees_and_facilities;Integrated Security=True");
            //  optionsBuilder.UseSqlServer("data source=193.140.173.173;initial catalog=SearchDormDb;user id=SearchDormUsr;password=ergec.senturk@emu.edu.tr;multipleactiveresultsets=True;");
            //optionsBuilder.UseSqlServer("data source=sql6006.site4now.net;initial catalog=DB_A2B24A_testing;user id=DB_A2B24A_testing_admin;password=Mami1961;multipleactiveresultsets=True;");
             // optionsBuilder.UseSqlServer("Data Source=SQL-SERVER-INST;Initial Catalog=fees_and_facilities_prod;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.ApplyConfiguration(new AccountInformationParameterConfiguration());


         // modelBuilder.Configurations.Add(new AccountInformationParameterConfiguration());
            modelBuilder.Entity<AccountInformationParameter>(entity =>
            {
                entity.ToTable("account_information_parameter");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<AccountInformationParameterTranslation>(entity =>
            {
                entity.HasKey(e => new { e.AccountInfoNonTransId, e.LanguageId });

                entity.ToTable("account_information_parameter_translation");

                entity.HasIndex(e => e.AccountInfoNonTransId)
                    .HasName("IX_account_info_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.AccountInfoNonTransId).HasColumnName("account_info_non_trans_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Parameter)
                    .IsRequired()
                    .HasColumnName("parameter")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountInfoNonTrans)
                    .WithMany(p => p.AccountInformationParameterTranslation)
                    .HasForeignKey(d => d.AccountInfoNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_information_parameter_translation_dbo.account_information_parameter_account_info_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.AccountInformationParameterTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_information_parameter_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<AccountParameterValues>(entity =>
            {
                entity.ToTable("account_parameter_values");

                entity.HasIndex(e => e.CurrencyId)
                    .HasName("IX_currency_id");

                entity.HasIndex(e => e.ParameterId)
                    .HasName("IX_parameter_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.ParameterId).HasColumnName("parameter_id");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.AccountParameterValues)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_parameter_values_dbo.bank_currency_table_currency_id");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.AccountParameterValues)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_parameter_values_dbo.account_information_parameter_parameter_id");
            });

            modelBuilder.Entity<AccountParameterValuesTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.AccountParamsValuesNonTransId });

                entity.ToTable("account_parameter_values_translation");

                entity.HasIndex(e => e.AccountParamsValuesNonTransId)
                    .HasName("IX_account_params_values_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.AccountParamsValuesNonTransId).HasColumnName("account_params_values_non_trans_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountParamsValuesNonTrans)
                    .WithMany(p => p.AccountParameterValuesTranslation)
                    .HasForeignKey(d => d.AccountParamsValuesNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_parameter_values_translation_dbo.account_parameter_values_account_params_values_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.AccountParameterValuesTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.account_parameter_values_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<BankCurrencyTable>(entity =>
            {
                entity.ToTable("bank_currency_table");

                entity.HasIndex(e => e.BankId)
                    .HasName("IX_bank_id");

                entity.Property(e => e.Id).HasColumnName("id");

               

                entity.Property(e => e.BankId).HasColumnName("bank_id");

            

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("currency_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankCurrencyTable)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.bank_currency_table_dbo.dormitory_bank_account_table_bank_id");
            });

            modelBuilder.Entity<DormitoriesTable>(entity =>
            {
                entity.ToTable("dormitories_table");

                entity.HasIndex(e => e.DormitoryTypeId)
                    .HasName("IX_dormitory_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

                entity.Property(e => e.MapLatitude)
                    .IsRequired()
                    .HasColumnName("map_latitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MapLongitude)
                    .IsRequired()
                    .HasColumnName("map_longitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPriceCurrency)
                    .IsRequired()
                    .HasColumnName("room_price_currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPriceCurrencySymbol)
                    .IsRequired()
                    .HasColumnName("room_price_currency_symbol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryType)
                    .WithMany(p => p.DormitoriesTable)
                    .HasForeignKey(d => d.DormitoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitories_table_dbo.dormitory_type_dormitory_type_id");
            });

            modelBuilder.Entity<DormitoriesTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoriesTableNonTransId });

                entity.ToTable("dormitories_table_translation");

                entity.HasIndex(e => e.DormitoriesTableNonTransId)
                    .HasName("IX_dormitories_table_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.DormitoriesTableNonTransId).HasColumnName("dormitories_table_non_trans_id");

                entity.Property(e => e.DormitoryAddress)
                    .IsRequired()
                    .HasColumnName("dormitory_address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DormitoryName)
                    .IsRequired()
                    .HasColumnName("dormitory_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.GenderAllocation)
                    .IsRequired()
                    .HasColumnName("gender_allocation")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoomsPaymentPeriod)
                    .IsRequired()
                    .HasColumnName("rooms_payment_period")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoriesTableNonTrans)
                    .WithMany(p => p.DormitoriesTableTranslation)
                    .HasForeignKey(d => d.DormitoriesTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitories_table_translation_dbo.dormitories_table_dormitories_table_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoriesTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitories_table_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<DormitoryBankAccountTable>(entity =>
            {
                entity.ToTable("dormitory_bank_account_table");

                entity.HasIndex(e => e.DormitoryId)
                    .HasName("IX_dormitory_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bank_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.DormitoryBankAccountTable)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_bank_account_table_dbo.dormitories_table_dormitory_id");
            });

            modelBuilder.Entity<DormitoryInformationTable>(entity =>
            {
                entity.ToTable("dormitory_information_table");

                entity.HasIndex(e => e.DormitoryTypeId)
                    .HasName("IX_dormitory_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

                entity.HasOne(d => d.DormitoryType)
                    .WithMany(p => p.DormitoryInformationTable)
                    .HasForeignKey(d => d.DormitoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_information_table_dbo.dormitory_type_dormitory_type_id");
            });

            modelBuilder.Entity<DormitoryInformationTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoryInfoNonTransId });

                entity.ToTable("dormitory_information_table_translation");

                entity.HasIndex(e => e.DormitoryInfoNonTransId)
                    .HasName("IX_dormitory_info_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.DormitoryInfoNonTransId).HasColumnName("dormitory_info_non_trans_id");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnName("information")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryInfoNonTrans)
                    .WithMany(p => p.DormitoryInformationTableTranslation)
                    .HasForeignKey(d => d.DormitoryInfoNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_information_table_translation_dbo.dormitory_information_table_dormitory_info_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoryInformationTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_information_table_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<DormitoryType>(entity =>
            {
                entity.ToTable("dormitory_type");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<DormitoryTypeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoryTypeNonTransId });

                entity.ToTable("dormitory_type_translation");

                entity.HasIndex(e => e.DormitoryTypeNonTransId)
                    .HasName("IX_dormitory_type_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.DormitoryTypeNonTransId).HasColumnName("dormitory_type_non_trans_id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("type_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryTypeNonTrans)
                    .WithMany(p => p.DormitoryTypeTranslation)
                    .HasForeignKey(d => d.DormitoryTypeNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_type_translation_dbo.dormitory_type_dormitory_type_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoryTypeTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.dormitory_type_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<FacilityOption>(entity =>
            {
                entity.ToTable("facility_option");

                entity.HasIndex(e => e.FacilityId)
                    .HasName("IX_facility_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityOption)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.facility_option_dbo.facility_table_facility_id");
            });

            modelBuilder.Entity<FacilityOptionTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FacilityOptionNonTransId, e.LanguageId });

                entity.ToTable("facility_option_translation");

                entity.HasIndex(e => e.FacilityOptionNonTransId)
                    .HasName("IX_facility_option_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.FacilityOptionNonTransId).HasColumnName("facility_option_non_trans_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FacilityOption)
                    .IsRequired()
                    .HasColumnName("facility_option")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityOptionDescription)
                    .IsRequired()
                    .HasColumnName("facility_option_description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacilityOptionNonTrans)
                    .WithMany(p => p.FacilityOptionTranslation)
                    .HasForeignKey(d => d.FacilityOptionNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.facility_option_translation_dbo.facility_option_facility_option_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FacilityOptionTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.facility_option_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<FacilityTable>(entity =>
            {
                entity.ToTable("facility_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityIconUrl)
                    .IsRequired()
                    .HasColumnName("facility_icon_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacilityTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.FacilityTableNonTransId });

                entity.ToTable("facility_table_translation");

                entity.HasIndex(e => e.FacilityTableNonTransId)
                    .HasName("IX_facility_table_non_trans_id");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FacilityTableNonTransId).HasColumnName("facility_table_non_trans_id");

                entity.Property(e => e.FacilityDescription)
                    .IsRequired()
                    .HasColumnName("facility_description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityTitle)
                    .IsRequired()
                    .HasColumnName("facility_title")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacilityTableNonTrans)
                    .WithMany(p => p.FacilityTableTranslation)
                    .HasForeignKey(d => d.FacilityTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.facility_table_translation_dbo.facility_table_facility_table_non_trans_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FacilityTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.facility_table_translation_dbo.language_table_language_id");
            });

            modelBuilder.Entity<LanguageTable>(entity =>
            {
                entity.ToTable("language_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasColumnName("language_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

       

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.ToTable("room_facility");

                entity.HasIndex(e => e.FacilityId)
                    .HasName("IX_facility_id");

                entity.HasIndex(e => e.RoomId)
                    .HasName("IX_room_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.FacilityOptionId).HasColumnName("facility_option_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.RoomFacility)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.room_facility_dbo.facility_table_facility_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomFacility)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.room_facility_dbo.room_table_room_id");
            });

            modelBuilder.Entity<RoomTable>(entity =>
            {
                entity.ToTable("room_table");

                entity.HasIndex(e => e.DormitoryId)
                    .HasName("IX_dormitory_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

                entity.Property(e => e.NumRoomsLeft).HasColumnName("num_rooms_left");

                entity.Property(e => e.RoomArea).HasColumnName("room_area");

                entity.Property(e => e.RoomPictureUrl)
                    .IsRequired()
                    .HasColumnName("room_picture_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPrice).HasColumnName("room_price");

                entity.Property(e => e.RoomPriceInstallment).HasColumnName("room_price_installment");

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.RoomTable)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.room_table_dbo.dormitories_table_dormitory_id");
            });

            modelBuilder.Entity<RoomTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.RoomTableNonTransId });

                entity.ToTable("room_table_translation");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_language_id");

                entity.HasIndex(e => e.RoomTableNonTransId)
                    .HasName("IX_room_table_non_trans_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.RoomTableNonTransId).HasColumnName("room_table_non_trans_id");

                entity.Property(e => e.RoomTitle)
                    .IsRequired()
                    .HasColumnName("room_title")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasColumnName("room_type")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.RoomTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.room_table_translation_dbo.language_table_language_id");

                entity.HasOne(d => d.RoomTableNonTrans)
                    .WithMany(p => p.RoomTableTranslation)
                    .HasForeignKey(d => d.RoomTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.room_table_translation_dbo.room_table_room_table_non_trans_id");
            });
        }
    }
}
