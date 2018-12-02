using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.CurrencyInformation
{
    public class CurrencyTranslation : BaseLanguage
    {
      
        public int CurrencyNonTransId { get; set; }
      public string Name { get; set; }

        public Currency CurrencyNonTrans { get; set; }
    }
}
