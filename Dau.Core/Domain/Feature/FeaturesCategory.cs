using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Feature
{
  public  class FeaturesCategory : BaseEntity
    {
        public FeaturesCategory()
        {
            Features = new HashSet<Features>();
            FeaturesCategoryTranslations = new HashSet<FeaturesCategoryTranslation>();
        }

       

        public ICollection<Features> Features{ get; set; }
        public ICollection<FeaturesCategoryTranslation> FeaturesCategoryTranslations{ get; set; }
    }
}
