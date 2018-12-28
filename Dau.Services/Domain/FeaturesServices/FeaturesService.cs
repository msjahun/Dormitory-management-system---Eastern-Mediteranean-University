using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.FeaturesServices
{
    public class FeaturesService : IFeaturesService
    {
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTransRepo;
        private readonly ILanguageService _languageService;

        public FeaturesService(
            IRepository<Features> featuresRepository,
            IRepository<FeaturesTranslation> featuresTransRepository,
            ILanguageService languageService
            )
        {
            _featuresRepo= featuresRepository;
            _featuresTransRepo= featuresTransRepository;
            _languageService = languageService;
        }

        public List<PopularFiltersTable> GetFeaturesHitCount()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId && feature.HitCount >0
                           orderby feature.HitCount descending
                           select new PopularFiltersTable
                           { Count= feature.HitCount.ToString(),
                               Filter =featureTrans.FeatureName };

            return features.ToList();
        }

        
        public bool UpdateFeaturesHitCount(List<int> FeaturesIds)
        {
            if(FeaturesIds!=null)
            foreach(var featureId in FeaturesIds)
            {
                var feature = _featuresRepo.GetById(featureId);
                feature.HitCount++;
                _featuresRepo.Update(feature);

            }
         
            return true;
        }

    }

    public class PopularFiltersTable
    {
        public string Filter { get; set; }
        public string Count { get; set; }


    }

}
