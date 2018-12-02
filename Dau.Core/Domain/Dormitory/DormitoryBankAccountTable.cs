using Dau.Core.Domain.BankAccount;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryBankAccountTable : BaseEntity
    {
        public DormitoryBankAccountTable()
        {
            BankCurrencyTable = new HashSet<BankCurrencyTable>();
        }

      
        public int DormitoryId { get; set; }
        public string BankName { get; set; }

        public DormitoriesTable Dormitory { get; set; }
        public ICollection<BankCurrencyTable> BankCurrencyTable { get; set; }
    }
}
