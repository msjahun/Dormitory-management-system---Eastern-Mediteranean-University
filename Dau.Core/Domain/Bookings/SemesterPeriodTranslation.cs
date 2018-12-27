using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Bookings
{
    public class SemesterPeriodTranslation:BaseLanguage
    {

        public string SemesterPeriodName { get; set; }
        public long SemesterPeriodNonTransId { get; set; }
        public SemesterPeriod SemesterPeriodNonTrans { get; set; }
    }
}
