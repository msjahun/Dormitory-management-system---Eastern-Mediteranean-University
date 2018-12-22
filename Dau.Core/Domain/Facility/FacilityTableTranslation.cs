using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility { 
    public partial class FacilityTableTranslation : BaseLanguage
    {
        

        public long FacilityTableNonTransId { get; set; }
        public string FacilityTitle { get; set; }
        public string FacilityDescription { get; set; }

        public FacilityTable FacilityTableNonTrans { get; set; }
      
    }
}
