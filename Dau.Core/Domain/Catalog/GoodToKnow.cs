using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
    public class GoodToKnow : BaseEntity
    {
        public GoodToKnow()
        { OtherInfosList = new HashSet<GoodToKnowTitleValue>();
        }

        public long DormitoryId { get; set; }
        public OpeningClosingTime WeekdaysOpeningTime { get; set; }
        public OpeningClosingTime WeekendsOpeningTime { get; set; }
        public ICollection<GoodToKnowTitleValue> OtherInfosList { get; set; }
       
    }
}
