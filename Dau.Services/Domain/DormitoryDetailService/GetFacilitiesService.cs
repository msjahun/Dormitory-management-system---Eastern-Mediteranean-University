using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetFacilitiesService : IGetFacilitiesService
    {
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryFeatures> _dormitoryFeaturesRepo;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTranslation;

        public GetFacilitiesService(
            IRepository<DormitoryFeatures> DormitoryFeaturesRepo,
            IRepository<Features> featuresRepo,
             ILanguageService languageService,
            IRepository<FeaturesTranslation> featuresTranslation)
        {
            _languageService = languageService;
            _dormitoryFeaturesRepo = DormitoryFeaturesRepo;
            _featuresRepo = featuresRepo;
            _featuresTranslation = featuresTranslation;
        }

        public List<FacilitiesSectionViewModel> GetFacilities(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTranslation.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };


            var dormFeatures = from dormFeature in _dormitoryFeaturesRepo.List().ToList()
                               join feature in features.ToList() on dormFeature.FeaturesId equals feature.Id
                               where dormFeature.DormitoryId == DormitoryId
                               select new FacilitiesSectionViewModel
                               {
                                   FacilityName = feature.FeatureName,
                                   IconUrl = feature.IconUrl
                               };






            List<FacilitiesSectionViewModel> modelList = dormFeatures.ToList();

            return modelList;
        }
    }

    public class FacilitiesSectionViewModel
    {

        public string FacilityName { get; set; }
        public string IconUrl { get; set; }
    }

}
