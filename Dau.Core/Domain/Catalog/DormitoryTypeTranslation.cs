using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public  class DormitoryTypeTranslation:BaseLanguage
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public long DormitoryTypeNonTransId { get; set; }
        public DormitoryType DormitoryTypeNonTrans { get; set; }
    }
}
