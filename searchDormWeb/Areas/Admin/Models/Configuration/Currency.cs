using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class CurrencyAdd
    {
        [Display(Name = "Name",
        Description = "The name of the currency."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "CurrencyCode",
        Description = "The currency code.For a list of currency codes, go to: http://www.iso.org/iso/support/currency_codes_list-1.htm."), DataType(DataType.Text), MaxLength(256)]
        public string CurrencyCode { get; set; }

        [Display(Name = "Rate",
        Description = "The exchange rate against the primary exchange rate currency."), MaxLength(256)]
        public int Rate { get; set; }

        [Display(Name = "DisplayLocale",
        Description = "The currency specific culture code."), MaxLength(256)]
        public int DisplayLocale { get; set; }

        [Display(Name = "CustomFormatting",
        Description = "Custom formatting to be applied to the currency values."), DataType(DataType.Text), MaxLength(256)]
        public string CustomFormatting { get; set; }

        [Display(Name = "LimitToDormitories",
        Description = "Option to limit this currency to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "RoundingType",
        Description = "The rounding type."), MaxLength(256)]
        public int RoundingType { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether the currency is published.")]
        public bool Published { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order of this currency. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

    }

    public class CurrencyEdit
    {
        [Display(Name = "Name",
        Description = "The name of the currency."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "CurrencyCode",
        Description = "The currency code.For a list of currency codes, go to: http://www.iso.org/iso/support/currency_codes_list-1.htm."), DataType(DataType.Text), MaxLength(256)]
        public string CurrencyCode { get; set; }

        [Display(Name = "Rate",
        Description = "The exchange rate against the primary exchange rate currency."), MaxLength(256)]
        public int Rate { get; set; }

        [Display(Name = "DisplayLocale",
        Description = "The currency specific culture code."), MaxLength(256)]
        public int DisplayLocale { get; set; }

        [Display(Name = "CustomFormatting",
        Description = "Custom formatting to be applied to the currency values."), DataType(DataType.Text), MaxLength(256)]
        public string CustomFormatting { get; set; }

        [Display(Name = "LimitToDormitories",
        Description = "Option to limit this currency to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "RoundingType",
        Description = "The rounding type."), MaxLength(256)]
        public int RoundingType { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether the currency is published.")]
        public bool Published { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order of this currency. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "CreatedOn",
        Description = "The date/time the currency was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }
    }
}
