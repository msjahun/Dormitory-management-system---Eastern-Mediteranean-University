using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
  public class ResolveDormitoryService : IResolveDormitoryService
    {
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<Seo> _SeoRepository;

        public ResolveDormitoryService(IRepository<Dormitory> DormitoryRepository, IRepository<Seo> SeoRepository)
        {
            _dormitoryRepository = DormitoryRepository;
            _SeoRepository = SeoRepository;
        }

        public long GetDormitoryIdBySEOFriendlyName(string SearchEngineFriendlyName)
        {
            var CombinedQuery = from _dormitories in _dormitoryRepository.List().ToList()
                                join _seo in _SeoRepository.List().ToList() on _dormitories.Seo.Id equals _seo.Id
                                where _seo.SearchEngineFriendlyPageName == SearchEngineFriendlyName
                                select new { _dormitories.Id };
            var dormitoryId = CombinedQuery.FirstOrDefault();

            if (dormitoryId != null)
                return dormitoryId.Id;
            return 0;
        }


        public string GetDormitorySEOFriendlyNameById(long id)
        {

            var CombinedQuery = from _dormitories in _dormitoryRepository.List().ToList()
                                join _seo in _SeoRepository.List().ToList() on _dormitories.Seo.Id equals _seo.Id
                                where _dormitories.Id == id
                                select new { _seo.SearchEngineFriendlyPageName };
            var SeoFriendlySearchEngineName = CombinedQuery.FirstOrDefault().SearchEngineFriendlyPageName.ToString();

            return SeoFriendlySearchEngineName.ToString();
        }

    }
}
