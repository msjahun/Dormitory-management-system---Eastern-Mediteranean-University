//using Dau.Core.Domain.BankAccount;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.ContentManagement;

using Dau.Core.Domain.CountryInformation;

using Dau.Core.Domain.CurrencyInformation;
//using Dau.Core.Domain.Dormitory;
//using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Feature;
//using Dau.Core.Domain.Room;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Language
{
    public partial class LanguageTable : BaseEntity
    {
        public LanguageTable()
        {
          //  AccountInformationParameterTranslation = new HashSet<AccountInformationParameterTranslation>();
          //  AccountParameterValuesTranslation = new HashSet<AccountParameterValuesTranslation>();
        //    DormitoriesTableTranslation = new HashSet<DormitoriesTableTranslation>();
         //   DormitoryInformationTableTranslation = new HashSet<DormitoryInformationTableTranslation>();
        //    DormitoryTypeTranslation = new HashSet<DormitoryTypeTranslation>();
         //   FacilityOptionTranslation = new HashSet<FacilityOptionTranslation>();
         //   FacilityTableTranslation = new HashSet<FacilityTableTranslation>();
         //   RoomTableTranslation = new HashSet<RoomTableTranslation>();

            //new
            DormitoryBlockTranslations = new HashSet<DormitoryBlockTranslation>();
            MessageTemplateTranslations = new HashSet<MessageTemplateTranslation>();
            TopicTranslations = new HashSet<TopicTranslation>();
            CountryTranslations = new HashSet<CountryTranslation>();
            CurrencyTranslations = new HashSet<CurrencyTranslation>();



            FeaturesTranslations = new HashSet<FeaturesTranslation>();
            FeaturesCategoryTranslations = new HashSet<FeaturesCategoryTranslation>();
        }

        public string Name { get; set; }
        public string LanguageCode { get; set; }

        //public ICollection<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
       // public ICollection<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
       // public ICollection<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
      //  public ICollection<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
       // public ICollection<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
       //public ICollection<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
       //public ICollection<FacilityTableTranslation> FacilityTableTranslation { get; set; }
       // public ICollection<RoomTableTranslation> RoomTableTranslation { get; set; }

        //new
        public ICollection<DormitoryBlockTranslation> DormitoryBlockTranslations{ get; set; }
        public ICollection<MessageTemplateTranslation> MessageTemplateTranslations{ get; set; }
        public ICollection<TopicTranslation> TopicTranslations{ get; set; }
        public ICollection<CountryTranslation> CountryTranslations{ get; set; }
        public ICollection<CurrencyTranslation> CurrencyTranslations{ get; set; }

        public ICollection<FeaturesTranslation> FeaturesTranslations { get; set; }
        public ICollection<FeaturesCategoryTranslation> FeaturesCategoryTranslations { get; set; }









    }
}
