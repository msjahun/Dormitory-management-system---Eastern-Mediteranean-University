using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class AccountInformationParameterTranslation : BaseLanguage
    {
        public long AccountInfoNonTransId { get; set; }
       
        public string Parameter { get; set; }

        public AccountInformationParameter AccountInfoNonTrans { get; set; }
      
    }
}
