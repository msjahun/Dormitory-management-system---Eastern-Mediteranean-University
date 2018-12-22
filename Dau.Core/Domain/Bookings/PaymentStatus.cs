using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
  public  class PaymentStatus:BaseEntity
    {
        public PaymentStatus()
        {
            PaymentStatusTranslations = new HashSet<PaymentStatusTranslation>();
        }
        public DateTime CreatedDate { get; set; }
        public ICollection<PaymentStatusTranslation> PaymentStatusTranslations{ get; set; }
    }
}
