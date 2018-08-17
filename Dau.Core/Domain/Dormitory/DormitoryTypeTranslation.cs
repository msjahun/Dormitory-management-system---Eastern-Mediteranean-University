using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryTypeTranslation
    {
        public int LanguageId { get; set; }
        public int DormitoryTypeNonTransId { get; set; }
        public string TypeName { get; set; }

        public DormitoryType DormitoryTypeNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
