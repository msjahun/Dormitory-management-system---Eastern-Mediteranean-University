using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility { 
    public partial class FacilityTableTranslation
    {
        public int LanguageId { get; set; }
        public int FacilityTableNonTransId { get; set; }
        public string FacilityTitle { get; set; }
        public string FacilityDescription { get; set; }

        public FacilityTable FacilityTableNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
