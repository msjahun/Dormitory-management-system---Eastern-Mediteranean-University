using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.DormitoryOld
{
    public partial class DormitoryTypeTranslation : BaseLanguage
    {
        
        public long DormitoryTypeNonTransId { get; set; }
        public string TypeName { get; set; }

        public DormitoryType DormitoryTypeNonTrans { get; set; }
        
    }
}
