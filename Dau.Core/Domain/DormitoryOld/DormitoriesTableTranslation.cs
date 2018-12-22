using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.DormitoryOld
{
    public partial class DormitoriesTableTranslation : BaseLanguage
    {
       
        public long DormitoriesTableNonTransId { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryAddress { get; set; }
        public string GenderAllocation { get; set; }
        public string RoomsPaymentPeriod { get; set; }

        public DormitoriesTable DormitoriesTableNonTrans { get; set; }
        
    }
}
