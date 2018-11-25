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

    public class CountryAdd
    {
        public LocalizedContentCountry[] localizedContentCountry { get; set; }

          [Display(Name = "AllowBilling",
        Description = "Allow billing to customers located in this country.")]
        public bool AllowBilling { get; set; }

        [Display(Name = "AllowBooking",
        Description = "Allow booking to customers located in this country.")]
        public bool AllowBooking { get; set; }

        [Display(Name = "TwoLetterIsoCode",
        Description = "The two letter ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_alpha."), DataType(DataType.Text), MaxLength(256)]
        public string TwoLetterIsoCode { get; set; }

        [Display(Name = "ThreeLetterIsoCode",
        Description = "The three letter ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_alpha-3."), DataType(DataType.Text), MaxLength(256)]
        public string ThreeLetterIsoCode { get; set; }

        [Display(Name = "NumericIsoCode",
        Description = "The numeric ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_numeric."), MaxLength(256)]
        public int NumericIsoCode { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this country is published(visible for creation of booking/billing addresses).")]
        public bool Published { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order for this country. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

    }


    public class CountryEdit
    {

        public LocalizedContentCountry[] localizedContentCountry { get; set; }

        [Display(Name = "AllowBilling",
        Description = "Allow billing to customers located in this country.")]
        public bool AllowBilling { get; set; }

        [Display(Name = "AllowBooking",
        Description = "Allow booking to customers located in this country.")]
        public bool AllowBooking { get; set; }

        [Display(Name = "TwoLetterIsoCode",
        Description = "The two letter ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_alpha."), DataType(DataType.Text), MaxLength(256)]
        public string TwoLetterIsoCode { get; set; }

        [Display(Name = "ThreeLetterIsoCode",
        Description = "The three letter ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_alpha-3."), DataType(DataType.Text), MaxLength(256)]
        public string ThreeLetterIsoCode { get; set; }

        [Display(Name = "NumericIsoCode",
        Description = "The numeric ISO code for this country.For a complete list of ISO codes go to: http://en.wikipedia.org/wiki/ISO_3166-1_numeric."), MaxLength(256)]
        public int NumericIsoCode { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this country is published(visible for creation of booking/billing addresses).")]
        public bool Published { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order for this country. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }


    public class StateAndProvinceTable
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Published { get; set; }
        public string DisplayOrder { get; set; }


    }


    public class LocalizedContentCountry
    {
        [Display(Name = "Name",
        Description = "The name of the country."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }
    }

}
