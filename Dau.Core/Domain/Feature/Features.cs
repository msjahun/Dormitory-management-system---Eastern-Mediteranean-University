using Dau.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Feature
{
   public class Features : BaseEntity
    {
        public Features()
        {
            FeaturesTranslations = new HashSet<FeaturesTranslation>();
            DormitoryFeatures = new HashSet<DormitoryFeatures>();
            RoomFeatures = new HashSet<RoomFeatures>();


    }

        public bool IsPublished { get; set; }
        public string IconUrl { get; set; }
        public int HitCount { get; set; }

        public FeaturesCategory FeaturesCategory{ get; set; }
        public long FeaturesCategoryId { get; set; }
        public ICollection<DormitoryFeatures> DormitoryFeatures { get; set; }
        public ICollection<RoomFeatures> RoomFeatures { get; set; }
        public ICollection<FeaturesTranslation> FeaturesTranslations { get; set; }
    }
}
