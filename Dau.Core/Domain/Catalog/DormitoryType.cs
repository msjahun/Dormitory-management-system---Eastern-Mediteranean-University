using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
    public class DormitoryType : BaseEntity
    {
        public DormitoryType()
        {
            DormitoryTypeTranslation = new HashSet<DormitoryTypeTranslation>();
            Dormitories = new HashSet<Dormitory>();
        }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Dormitory>Dormitories{ get; set; }
        public ICollection<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
    }
}
