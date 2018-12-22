using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
    public class BookingStatus:BaseEntity
    {
        public BookingStatus()
        {

            BookingStatusTranslations = new HashSet<BookingStatusTranslation>();
        }

        public DateTime CreatedDate { get; set; }
        public ICollection<BookingStatusTranslation> BookingStatusTranslations { get; set; }
    }
}
