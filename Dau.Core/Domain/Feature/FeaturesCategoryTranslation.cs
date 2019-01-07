//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Feature
{
    public class FeaturesCategoryTranslation : BaseLanguage
    {


    
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public long FeaturesCategoryNonTransId { get; set; }
        public FeaturesCategory FeaturesCategoryNonTrans { get; set; }
    }
}
