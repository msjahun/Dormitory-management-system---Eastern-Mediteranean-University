using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
    class RoomReservation
    {

        //I probably won't need to use this in any relationship,
        //since you can only reserve one room at a time, I can just add a room identifier in the reservation entity
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string Edit { get; set; }
    }
}
