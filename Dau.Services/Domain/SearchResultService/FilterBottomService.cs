using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
  public  class FilterBottomService : IFilterBottomService
    {
       
        private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Features> _Featuresrepository;
        private readonly IRepository<FeaturesTranslation> _FeaturesTranslationRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _FeaturesCategoryTranslationRepo;
        private readonly IRepository<FeaturesCategory> _FeatureCategoryrepository;

        public FilterBottomService(IRepository<FeaturesCategory> FeatureCategoryrepository,
            IRepository<FeaturesCategoryTranslation> FeaturesCategoryTranslationRepo,
            IRepository<RoomFeatures> roomFeaturesRepo,
             IRepository<Features> Featuresrepository,
             ILanguageService languageService,
             IRepository<FeaturesTranslation> FeaturesTranslationRepo)
        {
            _roomFeaturesRepo = roomFeaturesRepo;
            _languageService =languageService;
            _Featuresrepository = Featuresrepository;
            _FeaturesTranslationRepo = FeaturesTranslationRepo;
            _FeaturesCategoryTranslationRepo = FeaturesCategoryTranslationRepo;
            _FeatureCategoryrepository = FeatureCategoryrepository;
        }

        public IEnumerable<FiltersFacilityViewModel> GetFilterBottom()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var FeaturesCategoryJoined = from FC in _FeatureCategoryrepository.List().ToList()
                                         join FCTrans in _FeaturesCategoryTranslationRepo.List().ToList() on FC.Id equals FCTrans.FeaturesCategoryNonTransId
                                         where FCTrans.LanguageId == CurrentLanguageId
                                         select new { FeatureCategoryName = FCTrans.CategoryName, FeatureCategoryId = FC.Id };



            var FeaturesJoined = from F in _Featuresrepository.List().ToList()
                                 join FTrans in _FeaturesTranslationRepo.List().ToList() on F.Id equals FTrans.FeaturesNonTransId
                                 where FTrans.LanguageId == CurrentLanguageId && F.IsPublished==true && F.AllowFiltering
                                 orderby F.DisplayOrder ascending
                                 select new { FTrans.FeatureName, FeatureId = F.Id, FeaturesCategoryId = F.FeaturesCategory.Id };


            var CombinedQuery = from FC in FeaturesCategoryJoined.ToList()
                                join F in FeaturesJoined.ToList() on FC.FeatureCategoryId equals F.FeaturesCategoryId
                                select new { FC.FeatureCategoryName, FC.FeatureCategoryId, F.FeatureName, F.FeatureId };

            var modelList = from p in CombinedQuery
                          group new FacilityOptions { OptionId = p.FeatureId, OptionName = p.FeatureName, OptionCount =_roomFeaturesRepo.List().Where(c=> c.FeaturesId==p.FeatureId).Count()} by new {
                              p.FeatureCategoryId,
                              p.FeatureCategoryName ,
                              FeaturesInCategoryCount = _Featuresrepository.List().Where(c=>c.FeaturesCategoryId==p.FeatureCategoryId && c.IsPublished==true && c.AllowFiltering==true).Count()
                          } into g
                          select new FiltersFacilityViewModel { FacilityName = g.Key.FeatureCategoryName, FeaturesInCategoryCount=g.Key.FeaturesInCategoryCount, FacilityOptions = g.ToList() };

            return modelList;

        }


    }

    public class FiltersFacilityViewModel
    {
        public int FeaturesInCategoryCount { get; set; }
        public string FacilityName { get; set; }
        public string FacilityIconUrl { get; set; }
        public IEnumerable<FacilityOptions> FacilityOptions { get; set; }

    }

    public class FacilityOptions
    {
        public long OptionId { get; set; }
        public string OptionName { get; set; }
        public int OptionCount { get; set; }
    }

}
