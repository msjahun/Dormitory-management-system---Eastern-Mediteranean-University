using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Dau.Core.Domain.BankAccount;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.ContentManagement;

using Dau.Core.Domain.CountryInformation;

using Dau.Core.Domain.CurrencyInformation;
//using Dau.Core.Domain.Dormitory;
//using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Feature;
//using Dau.Core.Domain.Room;

namespace Dau.Core.Domain.Localization
{
    [Table("Language", Schema = "Localization")]
    public class Language:BaseEntity
    {
        public Language()
        {
           // AccountInformationParameterTranslation = new HashSet<AccountInformationParameterTranslation>();
           // AccountParameterValuesTranslation = new HashSet<AccountParameterValuesTranslation>();
         //   DormitoriesTableTranslation = new HashSet<DormitoriesTableTranslation>();
         //   DormitoryInformationTableTranslation = new HashSet<DormitoryInformationTableTranslation>();
          //  DormitoryTypeTranslation = new HashSet<DormitoryTypeTranslation>();
           // FacilityOptionTranslation = new HashSet<FacilityOptionTranslation>();
           // FacilityTableTranslation = new HashSet<FacilityTableTranslation>();
        //    RoomTableTranslation = new HashSet<RoomTableTranslation>();

            //new
            DormitoryBlockTranslations = new HashSet<DormitoryBlockTranslation>();
            MessageTemplateTranslations = new HashSet<MessageTemplateTranslation>();
            TopicTranslations = new HashSet<TopicTranslation>();
            CountryTranslations = new HashSet<CountryTranslation>();
      //      CurrencyTranslations = new HashSet<CurrencyTranslation>();



            FeaturesTranslations = new HashSet<FeaturesTranslation>();
            FeaturesCategoryTranslations = new HashSet<FeaturesCategoryTranslation>();
        }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Culture Name")]
        public string CultureName { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Region")]
        public string Region { get; set; }

        public bool IsDefaultLanguage { get; set; }

        public virtual List<Resource> Resources { get; set; }

       // public ICollection<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
        //public ICollection<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
      //  public ICollection<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
     //   public ICollection<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
      //  public ICollection<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
      //  public ICollection<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
      //  public ICollection<FacilityTableTranslation> FacilityTableTranslation { get; set; }
      //  public ICollection<RoomTableTranslation> RoomTableTranslation { get; set; }

        //new
        public ICollection<DormitoryBlockTranslation> DormitoryBlockTranslations { get; set; }
        public ICollection<MessageTemplateTranslation> MessageTemplateTranslations { get; set; }
        public ICollection<TopicTranslation> TopicTranslations { get; set; }
        public ICollection<CountryTranslation> CountryTranslations { get; set; }
    //    public ICollection<CurrencyTranslation> CurrencyTranslations { get; set; }

        public ICollection<FeaturesTranslation> FeaturesTranslations { get; set; }
        public ICollection<FeaturesCategoryTranslation> FeaturesCategoryTranslations { get; set; }


    }
}
