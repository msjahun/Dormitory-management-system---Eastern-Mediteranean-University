using Dau.Core.Domain.Dormitory;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.BankAccount
{
    public partial class BankCurrencyTable
    {
        public BankCurrencyTable()
        {
            AccountParameterValues = new HashSet<AccountParameterValues>();
        }

        public int Id { get; set; }
        public int BankId { get; set; }
        public string BankAddress { get; set; }
        public string BankRegistrationNo { get; set; }
        public string CurrencyName { get; set; }

        public DormitoryBankAccountTable Bank { get; set; }
        public ICollection<AccountParameterValues> AccountParameterValues { get; set; }
    }
}
