using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.HomeService
{
   public class HomeService : IHomeService
    {
        private readonly ILanguageService _languageService;
     
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepository;
        private readonly IRepository<Seo> _seoRepository;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTransRepo;

        public HomeService(
             ILanguageService languageService,
             
              IRepository<Dormitory> DormitoryRepository,
              IRepository<DormitoryTranslation> DormitoryTransRepository,
              IRepository<DormitoryType> DormitoryTypeRepository,
              IRepository<DormitoryTypeTranslation> DormitoryTypeTranslationRepository,
              IRepository<Seo> SeoRepository)
        {

            _languageService = languageService;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTransRepository = DormitoryTransRepository;
            _seoRepository = SeoRepository;
            _dormitoryTypeRepo = DormitoryTypeRepository;
            _dormitoryTypeTransRepo = DormitoryTypeTranslationRepository;
        }

        public List<GetSearchSuggestionsViewModel> GetSearchSuggestions(string searchTerm)
        {
            searchTerm = searchTerm.ToUpper();
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var Dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTransRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, dorm.DormitoryTypeId, dormTrans.DormitoryName, dorm.SeoId };

            var DormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var DormitoryWithType = from dorm in Dormitories.ToList()
                                    join dormType in DormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                    select new
                                    {
                                        dorm.Id,
                                        dorm.DormitoryName,
                                        dorm.SeoId,
                                        DormitoryTypeName = dormType.Title

                                    };


            var DormSeo = (from Dorm in DormitoryWithType.ToList()
                           join seo in _seoRepository.List().ToList() on Dorm.SeoId equals seo.Id

                           select new GetSearchSuggestionsViewModel {

                               DormitoryName = Dorm.DormitoryName,
                               NormalizedDormName = Dorm.DormitoryName.ToUpper(),
                           DormitoryType = Dorm.DormitoryTypeName,
                           SeoFriendlyUrlName = seo.SearchEngineFriendlyPageName
                          }).Where(p=> p.NormalizedDormName.Contains(searchTerm) || p.NormalizedDormName.EndsWith(searchTerm) || p.NormalizedDormName.StartsWith(searchTerm)).ToList();

            var dormitories = DormSeo;

            return dormitories;
        }

    }

    public class GetSearchSuggestionsViewModel
    {
        public string DormitoryName { get; set; }
        public string DormitoryType { get; set; }
        public string NormalizedDormName { get; set; }
        public string SeoFriendlyUrlName { get; set; }

    }
}
