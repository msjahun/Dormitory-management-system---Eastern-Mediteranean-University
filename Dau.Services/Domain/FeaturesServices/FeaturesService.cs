using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Domain.RoomServices;
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
        private readonly IRepository<FeaturesCategory> _featuresCategoryRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _featuresCategoryTransRepo;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepository;

        public FeaturesService(
            IRepository<Features> featuresRepository,
            IRepository<FeaturesTranslation> featuresTransRepository,
              IRepository<FeaturesCategory> featuresCategoryRepository,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepository,
            IRepository<RoomFeatures> roomFeaturesRepository,
            ILanguageService languageService
            )
        {
            _featuresRepo = featuresRepository;
            _featuresTransRepo = featuresTransRepository;
            _languageService = languageService;
            _featuresCategoryRepo = featuresCategoryRepository;
            _featuresCategoryTransRepo = featuresCategoryTransRepository;
            _roomFeaturesRepository = roomFeaturesRepository;
        }

        public List<PopularFiltersTable> GetFeaturesHitCount()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId && feature.HitCount > 0
                           orderby feature.HitCount descending
                           select new PopularFiltersTable
                           {
                               Count = feature.HitCount.ToString(),
                               Filter = featureTrans.FeatureName
                           };

            return features.ToList();
        }


        public bool UpdateFeaturesHitCount(List<int> FeaturesIds)
        {
            if (FeaturesIds != null)
                foreach (var featureId in FeaturesIds)
                {
                    var feature = _featuresRepo.GetById(featureId);
                    feature.HitCount++;
                    _featuresRepo.Update(feature);

                }

            return true;
        }


        public List<RoomFeaturesTable> GetRoomFeatures(long RoomId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new
                           {
                               feature.Id,
                               feature.FeaturesCategoryId,
                               featureTrans.FeatureName
                           };


            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                                   join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                                   where featureCatTrans.LanguageId == CurrentLanguageId
                                   select new
                                   { featureCat.Id, featureCatTrans.CategoryName };


            var fullFeatures = from feature in features.ToList()
                               join featureCat in featuresCategory.ToList() on feature.FeaturesCategoryId equals featureCat.Id
                               select new
                               {
                                   feature.Id,
                                   feature.FeatureName,
                                   featureCat.CategoryName,

                               };

            var RoomFeatures = from roomFeature in _roomFeaturesRepository.List().ToList()
                               join feature in fullFeatures.ToList() on roomFeature.FeaturesId equals feature.Id
                               where roomFeature.RoomId == RoomId
                               select new RoomFeaturesTable
                               {
                                   FeatureCategory = feature.CategoryName,
                                   Feature = feature.FeatureName,
                                   AllowFiltering = true,
                                   ShowOnRoomPage = true,
                                   DisplayOrder = 4,
                                   Id=feature.Id
                               };


            var model = RoomFeatures.ToList();

            return model;

        }

        public bool AddRoomFeature(FacilitiesTab vm)
        {
            try
            {
                var model = new RoomFeatures
                {
                    RoomId = vm.RoomId,
                    FeaturesId = vm.Feature
                    
                };
                _roomFeaturesRepository.Insert(model);
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool RemoveRoomFeature(FacilitiesTab vm)
        {
            try
            {
                var model = _roomFeaturesRepository.List().Where(c => c.RoomId == vm.RoomId && c.FeaturesId == vm.Feature).FirstOrDefault();
                   
               
                _roomFeaturesRepository.Delete(model);
                return true;
            }
            catch
            {
                return false;
            }


        }
    }

    public class PopularFiltersTable
    {
        public string Filter { get; set; }
        public string Count { get; set; }


    }


    public class RoomFeaturesTable
    {
        public long Id { get; set; }
        public string FeatureCategory { get; set; }
        public string Feature { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnRoomPage { get; set; }
        public int DisplayOrder { get; set; }

    }

}
