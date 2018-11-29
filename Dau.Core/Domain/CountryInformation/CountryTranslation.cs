using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.CountryInformation
{
    public class CountryTranslation : BaseLanguage
    {
        public int Id { get; set; }
        public int CountryNonTransId { get; set; }
       public string Name { get; set; }

        public Country CountryNonTrans{ get; set; }
    }
}
