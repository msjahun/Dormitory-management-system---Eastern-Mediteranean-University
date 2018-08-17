using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Dormitory
{
    public partial class DormitoryInformationTable
    {
        public DormitoryInformationTable()
        {
            DormitoryInformationTableTranslation = new HashSet<DormitoryInformationTableTranslation>();
        }

        public int Id { get; set; }
        public int DormitoryTypeId { get; set; }

        public DormitoryType DormitoryType { get; set; }
        public ICollection<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
    }
}
