using Dau.Core.Domain.Feature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class DormitoryFeatures:BaseEntity
    {
        public long DormitoryId { get; set; }
        public Dormitory Dormitory { get; set; }

        public long FeaturesId { get; set; }
        public Features Features { get; set; }
    }
}
