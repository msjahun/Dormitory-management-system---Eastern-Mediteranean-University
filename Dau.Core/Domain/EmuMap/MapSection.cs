using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.EmuMap
{
   public class MapSection:BaseEntity
    {
        public MapSection()
        {
            MapSectionTranslation = new HashSet<MapSectionTranslation>();
        }

        public int BuildingId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedDate { get; set; }

        public MapSectionCategory MapSectionCategory{ get; set; }
        public long MapSectionCategoryId { get; set; }
        public ICollection<MapSectionTranslation> MapSectionTranslation{ get; set; }
    }
}
