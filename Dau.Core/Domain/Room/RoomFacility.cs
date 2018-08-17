using Dau.Core.Domain.Facility;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Room
{
    public partial class RoomFacility
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int RoomId { get; set; }
        public int? FacilityOptionId { get; set; }

        public FacilityTable Facility { get; set; }
        public RoomTable Room { get; set; }
    }
}
