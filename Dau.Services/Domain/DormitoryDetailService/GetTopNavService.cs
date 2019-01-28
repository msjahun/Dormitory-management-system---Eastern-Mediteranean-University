using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Domain.MapServices;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetTopNavService : IGetTopNavService
    {
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepo;
        private readonly IMapService _mapService;

        public GetTopNavService(
             ILanguageService languageService,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
            IMapService mapService)
        {
            _languageService = languageService;
            _dormitoryRepo = DormitoryRepository;
            _dormitoryTranslationRepo= DormitoryTranslationRepository;
            _mapService = mapService;
        }

        public TopNavDormitorySectionViewModel GetTopNav(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var Dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTranslationRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dorm.Id == DormitoryId && dormTrans.LanguageId == CurrentLanguageId
                            select new TopNavDormitorySectionViewModel {
                                DormitoryName = dormTrans.DormitoryName,
                                DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                               // DormitoryType = "Dormitory belongs to the category of private school dormitories/ accomodations (BOT),",
                                DormitoryLogoUrl = dorm.DormitoryLogoUrl,
                               MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),


                            };


            TopNavDormitorySectionViewModel model = Dormitory.FirstOrDefault();

            return model; }
    }


    public class TopNavDormitorySectionViewModel
    {
        public string MapSection { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryLogoUrl { get; set; }

    }

}
