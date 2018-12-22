using Dau.Core.Domain.Facility;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.RoomOld
{
    public partial class RoomFacility : BaseEntity
    {
      
        public long FacilityId { get; set; }
        public long RoomId { get; set; }
        public long? FacilityOptionId { get; set; }

        public FacilityTable Facility { get; set; }
        public RoomTable Room { get; set; }
    }
}
