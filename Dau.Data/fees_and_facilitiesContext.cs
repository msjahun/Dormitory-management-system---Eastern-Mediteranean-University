
using Dau.Core.Domain.BankAccount;
using Dau.Core.Domain.Dormitory;
using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Room;
using Dau.Core.Domain.Language;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dau.Core.Domain.User;
using Microsoft.EntityFrameworkCore;

using Dau.Data.Mapping.BankAccount;
using Dau.Data.Mapping.Dormitory;
using Dau.Data.Mapping.Facility;
using Dau.Data.Mapping.Language;
using Dau.Data.Mapping.Room;
using Dau.Core.Domain.Logging;
using Dau.Data.Mapping.Logging;
using Dau.Data.Mapping.User;

namespace Dau.Data
{
    public partial class Fees_and_facilitiesContext : IdentityDbContext<User, UserRole,string>
    {
      

        public Fees_and_facilitiesContext()
           
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


        //new tables
        public virtual DbSet<Log> Log{ get; set; }
        public virtual DbSet<OnlineUsers> OnlineUsers{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


               //optionsBuilder.UseSqlServer("Data Source=DARK-SHILLA\\SQLEXPRESS;Initial Catalog=fees_and_facilities;Integrated Security=True");
            //  optionsBuilder.UseSqlServer("data source=193.140.173.173;initial catalog=SearchDormDb;user id=SearchDormUsr;password=ergec.senturk@emu.edu.tr;multipleactiveresultsets=True;");
            //optionsBuilder.UseSqlServer("data source=sql6006.site4now.net;initial catalog=DB_A2B24A_testing;user id=DB_A2B24A_testing_admin;password=Mami1961;multipleactiveresultsets=True;");
            optionsBuilder.UseSqlServer("Data Source=SQL-SERVER-INST;Initial Catalog=fees_and_facilities_prod;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new AccountInformationParameterMap());
            modelBuilder.ApplyConfiguration(new AccountInformationParameterTranslationMap());
            modelBuilder.ApplyConfiguration(new AccountParameterValuesMap());
            modelBuilder.ApplyConfiguration(new AccountParameterValuesTranslationMap());
            modelBuilder.ApplyConfiguration(new BankCurrencyTableMap());
            modelBuilder.ApplyConfiguration(new DormitoriesTableMap());
            modelBuilder.ApplyConfiguration(new DormitoriesTableTranslationMap());
            modelBuilder.ApplyConfiguration(new DormitoryBankAccountTableMap());
            modelBuilder.ApplyConfiguration(new DormitoryInformationTableMap());
            modelBuilder.ApplyConfiguration(new DormitoryInformationTableTranslationMap());
            modelBuilder.ApplyConfiguration(new DormitoryTypeMap());
            modelBuilder.ApplyConfiguration(new DormitoryTypeTranslationMap());
            modelBuilder.ApplyConfiguration(new FacilityOptionMap());
            modelBuilder.ApplyConfiguration(new FacilityOptionTranslationMap());
            modelBuilder.ApplyConfiguration(new FacilityTableMap());
            modelBuilder.ApplyConfiguration(new FacilityTableTranslationMap());
            modelBuilder.ApplyConfiguration(new LanguageTableMap());
            modelBuilder.ApplyConfiguration(new RoomFacilityMap());
            modelBuilder.ApplyConfiguration(new RoomTableMap());
            modelBuilder.ApplyConfiguration(new RoomTableTranslationMap());


            //new tables config
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new OnlineUsersMap());
         
        }
    }
}
