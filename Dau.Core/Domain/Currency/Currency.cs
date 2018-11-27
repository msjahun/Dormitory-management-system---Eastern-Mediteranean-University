using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Currency
{
    class Currency
    {
        public Currency()
        {
            CurrencyTranslations = new HashSet<CurrencyTranslation>();
        }



      
       
        public string CurrencyCode { get; set; }

        public int Rate { get; set; }

        public int DisplayLocale { get; set; }

        public string CustomFormatting { get; set; }

        public IEnumerable<int> LimitToDormitories { get; set; }

        public int RoundingType { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }


 //CurrencyTranslation table
        //  public LocalizedCurrencyContent[] localizedCurrencyContent { get; set; }
        public ICollection<CurrencyTranslation> CurrencyTranslations{ get; set; }
        



    }
}
