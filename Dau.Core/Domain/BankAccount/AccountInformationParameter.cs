using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class AccountInformationParameter
    {
        public AccountInformationParameter()
        {
            AccountInformationParameterTranslation = new HashSet<AccountInformationParameterTranslation>();
            AccountParameterValues = new HashSet<AccountParameterValues>();
        }

        public int Id { get; set; }

        public ICollection<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
        public ICollection<AccountParameterValues> AccountParameterValues { get; set; }
    }
}
