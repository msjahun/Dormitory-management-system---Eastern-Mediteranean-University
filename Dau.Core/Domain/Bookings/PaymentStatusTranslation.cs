using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
  public  class PaymentStatusTranslation : BaseLanguage
    {

        public long PaymentStatusNonTransId { get; set; }
        public PaymentStatus PaymentStatusNonTrans { get; set; }
        public string PaymentStatus { get; set; }
    }
}
