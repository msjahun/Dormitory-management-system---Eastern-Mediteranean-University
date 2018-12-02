using Dau.Core.Domain.Dormitory;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class BankCurrencyTable : BaseEntity
    {
        public BankCurrencyTable()
        {
            AccountParameterValues = new HashSet<AccountParameterValues>();
        }

        public int BankId { get; set; }
    public int ExchangeRage { get; set; }
        public string CurrencyName { get; set; }

        public DormitoryBankAccountTable Bank { get; set; }
        public ICollection<AccountParameterValues> AccountParameterValues { get; set; }
    }
}
