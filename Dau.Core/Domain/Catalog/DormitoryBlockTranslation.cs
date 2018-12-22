//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class DormitoryBlockTranslation:  BaseLanguage
    {
        

        public string Name { get; set; }
        public string Description { get; set; }
        public long DormitoryBlockNonTransId { get; set; }
        public DormitoryBlock DormitoryBlockNonTrans{ get; set; }
    }
}
