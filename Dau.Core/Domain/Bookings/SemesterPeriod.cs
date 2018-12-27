using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
  public  class SemesterPeriod:BaseEntity
    {
        public SemesterPeriod()
        {
            SemesterPeriodTranslations = new HashSet<SemesterPeriodTranslation>();
        }

        public bool IsPublished { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCurrentSemester { get; set; }
        public bool IsNextSemester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<SemesterPeriodTranslation> SemesterPeriodTranslations { get; set; }
    }
}
