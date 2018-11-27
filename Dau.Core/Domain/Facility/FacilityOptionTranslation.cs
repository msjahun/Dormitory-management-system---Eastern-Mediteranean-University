using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility
{
    public partial class FacilityOptionTranslation : BaseLanguage
    {
        public int FacilityOptionNonTransId { get; set; }
       
        public string FacilityOption { get; set; }
        public string FacilityOptionDescription { get; set; }

        public FacilityOption FacilityOptionNonTrans { get; set; }
       
    }
}
