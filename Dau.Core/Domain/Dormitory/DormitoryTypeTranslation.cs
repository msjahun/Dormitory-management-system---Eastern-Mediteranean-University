using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryTypeTranslation : BaseLanguage
    {
        
        public int DormitoryTypeNonTransId { get; set; }
        public string TypeName { get; set; }

        public DormitoryType DormitoryTypeNonTrans { get; set; }
        
    }
}
