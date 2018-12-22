using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
  public  class BookingStatusTranslation : BaseLanguage
    {


        public long BookingStatusNonTransId { get; set; }
        public BookingStatus BookingStatusNonTrans { get; set; }
            public string BookingStatus { get; set; }
    }
}
