using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility
{
    public partial class FacilityOptionTranslation
    {
        public int FacilityOptionNonTransId { get; set; }
        public int LanguageId { get; set; }
        public string FacilityOption { get; set; }
        public string FacilityOptionDescription { get; set; }

        public FacilityOption FacilityOptionNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
