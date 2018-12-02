using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
    public class RoomReservation : BaseEntity
    {
      
        //I probably won't need to use this in any relationship,
        //since you can only reserve one room at a time, I can just add a room identifier in the reservation entity
        public string Picture { get; set; }
        public int RoomId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }
      
    }
}
