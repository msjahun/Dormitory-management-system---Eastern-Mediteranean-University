using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
   public class Cart:BaseEntity
    {
        public long RoomId { get; set; }
        public Room Room { get; set; }
        public long SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }
        public double TotalAmount { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
