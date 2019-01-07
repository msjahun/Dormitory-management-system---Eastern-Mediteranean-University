using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.EmuMap
{
   public class MapSectionCategory:BaseEntity
    {
        public MapSectionCategory()
        {
            MapSectionCategoryTranslation = new HashSet<MapSectionCategoryTranslation>();
            MapSections = new HashSet<MapSection>();
        }

        public DateTime CreatedDate { get; set; }
        public ICollection<MapSection> MapSections{ get; set; }
        public ICollection<MapSectionCategoryTranslation> MapSectionCategoryTranslation { get; set; }
    }
}
