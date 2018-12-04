using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{


    public class CurrenciesVm
    {
        [Display(Name = "Current exchange rate provider",
        Description = "Select an exchange rate provider."),
        MaxLength(256)]
        public int CurrentExchangeRateProvider { get; set; }

        [Display(Name = "Auto enabled",
        Description = "Determines whether exchange rates will be updated automatically.")]
        public bool AutoEnabled { get; set; }

    }

    public class CurrencyAdd
    {
        public LocalizedCurrencyContent[] localizedCurrencyContent { get; set; }

        [Display(Name = "Currency Code",
        Description = "The currency code.For a list of currency codes, go to: http://www.iso.org/iso/support/currency_codes_list-1.htm."), DataType(DataType.Text), MaxLength(256)]
        public string CurrencyCode { get; set; }

        [Display(Name = "Rate",
        Description = "The exchange rate against the primary exchange rate currency."), MaxLength(256)]
        public int Rate { get; set; }

        [Display(Name = "Display Locale",
        Description = "The currency specific culture code."), MaxLength(256)]
        public int DisplayLocale { get; set; }

        [Display(Name = "Custom Formatting",
        Description = "Custom formatting to be applied to the currency values."), DataType(DataType.Text), MaxLength(256)]
        public string CustomFormatting { get; set; }

        [Display(Name = "Limit To Dormitories",
        Description = "Option to limit this currency to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "Rounding Type",
        Description = "The rounding type."), MaxLength(256)]
        public int RoundingType { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether the currency is published.")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order of this currency. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

    }

    public class CurrencyEdit
    {
        public LocalizedCurrencyContent[] localizedCurrencyContent { get; set; }



        [Display(Name = "Currency Code",
        Description = "The currency code.For a list of currency codes, go to: http://www.iso.org/iso/support/currency_codes_list-1.htm."), DataType(DataType.Text), MaxLength(256)]
        public string CurrencyCode { get; set; }

        [Display(Name = "Rate",
        Description = "The exchange rate against the primary exchange rate currency."), MaxLength(256)]
        public int Rate { get; set; }

        [Display(Name = "Display Locale",
        Description = "The currency specific culture code."), MaxLength(256)]
        public int DisplayLocale { get; set; }

        [Display(Name = "Custom Formatting",
        Description = "Custom formatting to be applied to the currency values."), DataType(DataType.Text), MaxLength(256)]
        public string CustomFormatting { get; set; }

        [Display(Name = "Limit To Dormitories",
        Description = "Option to limit this currency to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "Rounding Type",
        Description = "The rounding type."), MaxLength(256)]
        public int RoundingType { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether the currency is published.")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order of this currency. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Created On",
        Description = "The date/time the currency was created."), DataType(DataType.Text), MaxLength(256)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated On",
      Description = "The date/time the currency was updated."), DataType(DataType.Text), MaxLength(256)]
        public DateTime UpdatedOn { get; set; }
    }


    public class LocalizedCurrencyContent
    {
        [Display(Name = "Name",
      Description = "The name of the currency."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }
    }
}
