using Dau.Core.Domain.Dormitory;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Room
{
    public partial class RoomTable
    {
        public RoomTable()
        {
            RoomFacility = new HashSet<RoomFacility>();
            RoomTableTranslation = new HashSet<RoomTableTranslation>();
        }

        public int Id { get; set; }
        public int DormitoryId { get; set; }
        public string RoomPictureUrl { get; set; }
        public double RoomPrice { get; set; }
        public double RoomPriceInstallment { get; set; }
        public int NumRoomsLeft { get; set; }
        public int RoomArea { get; set; }

        public DormitoriesTable Dormitory { get; set; }
        public ICollection<RoomFacility> RoomFacility { get; set; }
        public ICollection<RoomTableTranslation> RoomTableTranslation { get; set; }
    }
}
