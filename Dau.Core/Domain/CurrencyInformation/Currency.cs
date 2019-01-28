using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.CurrencyInformation
{
   public class Currency : BaseEntity
    {
       

        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public double Rate { get; set; }


        public string CustomFormatting { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }


 //CurrencyTranslation table
        //  public LocalizedCurrencyContent[] localizedCurrencyContent { get; set; }

        



    }
}
