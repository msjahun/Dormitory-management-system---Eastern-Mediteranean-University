using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility
{
    public partial class FacilityOptionTranslation : BaseLanguage
    {
        public long FacilityOptionNonTransId { get; set; }
       
        public string FacilityOption { get; set; }
        public string FacilityOptionDescription { get; set; }

        public FacilityOption FacilityOptionNonTrans { get; set; }
       
    }
}
