﻿using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class DormitoryBlockTranslation: BaseLanguage
    {public int Id { get; set; }
        public int DormitoryBlockNonTransId { get; set; }
        public string Name { get; set; }

       public string Description { get; set; }

        public DormitoryBlock DormitoryBlockNonTrans{ get; set; }
    }
}
