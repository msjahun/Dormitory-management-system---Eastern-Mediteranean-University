using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.DormitoryOld
{
    public partial class DormitoryInformationTableTranslation : BaseLanguage
    {
        
        public long DormitoryInfoNonTransId { get; set; }
        public string Information { get; set; }

        public DormitoryInformationTable DormitoryInfoNonTrans { get; set; }
       
    }
}
