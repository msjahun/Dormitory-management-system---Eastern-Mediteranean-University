using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryInformationTableTranslation : BaseLanguage
    {
        
        public long DormitoryInfoNonTransId { get; set; }
        public string Information { get; set; }

        public DormitoryInformationTable DormitoryInfoNonTrans { get; set; }
       
    }
}
