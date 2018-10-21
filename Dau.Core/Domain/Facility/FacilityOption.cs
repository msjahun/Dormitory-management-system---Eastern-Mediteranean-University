using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Facility
{
    public partial class FacilityOption
    {
        public FacilityOption()
        {
            FacilityOptionTranslation = new HashSet<FacilityOptionTranslation>();
        }

        public int Id { get; set; }
        public int FacilityId { get; set; }



        public FacilityTable Facility { get; set; }
        public ICollection<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
    }
}
