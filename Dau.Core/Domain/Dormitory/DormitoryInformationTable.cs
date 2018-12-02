using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryInformationTable : BaseEntity
    {
        public DormitoryInformationTable()
        {
            DormitoryInformationTableTranslation = new HashSet<DormitoryInformationTableTranslation>();
        }

     
        public int DormitoryTypeId { get; set; }

        public DormitoryType DormitoryType { get; set; }
        public ICollection<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
    }
}
