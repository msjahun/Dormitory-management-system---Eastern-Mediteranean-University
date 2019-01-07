using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.EmuMap
{
    public class MapSectionTranslation:BaseLanguage
    {
        public string LocationName { get; set; }
        public long MapSectionNonTransId { get; set; }
        public MapSection MapSectionNonTrans { get; set; }
    }
}
