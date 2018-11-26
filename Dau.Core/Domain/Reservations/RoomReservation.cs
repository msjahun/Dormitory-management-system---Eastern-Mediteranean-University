using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Reservations
{
    class RoomReservation
    {
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string Edit { get; set; }
    }
}
