using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class AccountParameterValuesTranslation : BaseLanguage
    {
      
        public long AccountParamsValuesNonTransId { get; set; }
        public string Value { get; set; }

        public AccountParameterValues AccountParamsValuesNonTrans { get; set; }
     
    }
}
