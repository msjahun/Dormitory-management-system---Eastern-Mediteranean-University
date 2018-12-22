using Dau.Core.Domain.SearchEngineOptimization;

using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public class DormitoryBlock : BaseEntity, IBaseSeo
    {
        public DormitoryBlock()
        {
            DormitoryBlockTranslations = new HashSet<DormitoryBlockTranslation>();
            Rooms = new HashSet<Room>();
    }
        
        public string PictureUrl { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public Dormitory Dormitory { get; set; }
        public ICollection<DormitoryBlockTranslation> DormitoryBlockTranslations{ get; set; }

        public long SeoId { get; set; }
        public Seo Seo { get; set; }

    }
}
