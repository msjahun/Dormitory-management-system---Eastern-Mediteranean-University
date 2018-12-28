using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
    public class SearchService : ISearchService
    {
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTransRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly ILanguageService _languageService;

        public SearchService(
            IRepository<DormitoryType> dormitoryTypeRepo,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTransRepo,
            IRepository<Dormitory> dormitoryRepo,
            IRepository<DormitoryTranslation> dormitoryTransRepo,
               ILanguageService languageService)
        {
            _dormitoryTypeRepo = dormitoryTypeRepo;
            _dormitoryTypeTransRepo = dormitoryTypeTransRepo;
            _dormitoryTransRepo = dormitoryTransRepo;
            _dormitoryRepo = dormitoryRepo;
            _languageService = languageService;
        }

        public List<DormitoryNamesTypesViewModel> GetDormitoryTypesFilter()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new DormitoryNamesTypesViewModel
                                {
                                    Id = dormType.Id.ToString(),
                                    Name = dormTypeTrans.Title
                                };




            var model = dormitoryType.ToList();

            return model;

        }


        public List<DormitoryNamesTypesViewModel> GetDormitoriesFilter(long DormitoryTypeId=0)
        {


            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitories = new List<DormitoryNamesTypesViewModel>();
            if (DormitoryTypeId <=0) {
           dormitories = (from dorm in _dormitoryRepo.List().ToList()
                              join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId 
                               select new DormitoryNamesTypesViewModel { 
                              DormitoryTypeId= dorm.DormitoryTypeId,
                                  Id = dorm.Id.ToString(),
                                  Name = dormTrans.DormitoryName
                              }).ToList();


            }
            else
            {
                dormitories = (from dorm in _dormitoryRepo.List().ToList()
                                   join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                                   where dormTrans.LanguageId == CurrentLanguageId && dorm.DormitoryTypeId == DormitoryTypeId
                                   select new DormitoryNamesTypesViewModel
                                   {
                                       DormitoryTypeId = dorm.DormitoryTypeId,
                                       Id = dorm.Id.ToString(),
                                       Name = dormTrans.DormitoryName
                                   }).ToList();
            }

            var model = dormitories.ToList();
            return model;
        }
    }

    public class DormitoryNamesTypesViewModel
    {
        public long DormitoryTypeId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
