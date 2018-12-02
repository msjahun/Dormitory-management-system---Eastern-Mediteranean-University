using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.CountryInformation
{
  public  class Country : BaseEntity
    {
        public Country()
        {
            CountryTranslations = new HashSet<CountryTranslation>();
            StateAndProvinces = new HashSet<StateAndProvince>();
        }




        //CountryTranslation table
        public bool AllowBilling { get; set; }

        public bool AllowBooking { get; set; }
        public string TwoLetterIsoCode { get; set; }

        public string ThreeLetterIsoCode { get; set; }

        public int NumericIsoCode { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

       

        // public LocalizedContentCountry[] localizedContentCountry { get; set; }
        public ICollection<CountryTranslation> CountryTranslations{ get; set; }


        //state and province table  

        public ICollection<StateAndProvince> StateAndProvinces { get; set; }
    }
}
