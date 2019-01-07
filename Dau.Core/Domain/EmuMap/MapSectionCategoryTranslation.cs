using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.EmuMap
{
   public class MapSectionCategoryTranslation:BaseLanguage
    {

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public long MapSectionCategoryNonTransId { get; set; }
        public MapSectionCategory MapSectionCategoryNonTrans { get; set; }
    }
}
