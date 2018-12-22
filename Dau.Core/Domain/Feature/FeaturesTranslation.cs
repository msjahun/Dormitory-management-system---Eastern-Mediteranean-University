//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Feature
{
   public class FeaturesTranslation : BaseLanguage
    {

        public long FeaturesNonTransId { get; set; }
       
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public Features FeaturesNonTrans { get; set; }
    }
}
