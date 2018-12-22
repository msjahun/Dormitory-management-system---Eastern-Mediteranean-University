using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.DormitoryOld
{
    public partial class DormitoryType : BaseEntity
    {
        public DormitoryType()
        {
            DormitoriesTable = new HashSet<DormitoriesTable>();
            DormitoryInformationTable = new HashSet<DormitoryInformationTable>();
            DormitoryTypeTranslation = new HashSet<DormitoryTypeTranslation>();
        }

      

        public ICollection<DormitoriesTable> DormitoriesTable { get; set; }
        public ICollection<DormitoryInformationTable> DormitoryInformationTable { get; set; }
        public ICollection<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
    }
}
