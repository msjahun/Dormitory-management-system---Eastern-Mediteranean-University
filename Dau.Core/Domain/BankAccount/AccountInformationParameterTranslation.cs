using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class AccountInformationParameterTranslation : BaseEntity
    {
        public long AccountInfoNonTransId { get; set; }
        public long LanguageId { get; set; }
        public string Parameter { get; set; }

        public AccountInformationParameter AccountInfoNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
