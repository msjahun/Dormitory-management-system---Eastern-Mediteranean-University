using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class AccountParameterValues : BaseEntity
    {
        public AccountParameterValues()
        {
            AccountParameterValuesTranslation = new HashSet<AccountParameterValuesTranslation>();
        }

      
        public long CurrencyId { get; set; }
        public long ParameterId { get; set; }

        public BankCurrencyTable Currency { get; set; }
        public AccountInformationParameter Parameter { get; set; }
        public ICollection<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
    }
}
