using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Dau.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dau.Services.Domain.SeoServices
{
  public  class SeoService : ISeoService
    {
        private readonly IRepository<Seo> _SeoRepo;
        private readonly IUserRolesService _userRolesService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTransRepo;

        public SeoService(IRepository<Seo> SeoRepository,
              ILanguageService languageService,
               IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTransRepository,
             IUserRolesService userRolesService)
        {
            _SeoRepo = SeoRepository;
            _userRolesService = userRolesService;
            _languageService = languageService;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _dormitoryTypeRepo = dormitoryTypeRepository;
            _dormitoryTypeTransRepo = dormitoryTypeTransRepository;
        }

        public int CheckForSeoFriendlyNameDuplicates(string SeoFriendlyName)
        {
            var seolist = from seo in _SeoRepo.List().ToList()
                          where seo.SearchEngineFriendlyPageName == SeoFriendlyName
                          select seo;

            return seolist.ToList().Count;
        }

        public string ConcatenateDuplicateIndexToSeoFriendlyName(string SeoFriendlyName, int Count)
        {
            if (Count > 0 && Count<int.MaxValue)
                return SeoFriendlyName + "-" + (Count + 1);
            else
                return SeoFriendlyName;
        }

        public string RemoveSpecialCharacters(string str)
        {//removes special characters and checks duplicates___ refactor to 2 methods
            string acceptString = Regex.Replace(str, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled);
            acceptString = acceptString.ToLower();
            return acceptString;
        }

        public string ResolveSpecialCharactersAndSeoNameDuplication(string SeoFriendlyName)
        {
            var WithoutSpecialChars = RemoveSpecialCharacters(SeoFriendlyName);
            var DuplicationCounts = CheckForSeoFriendlyNameDuplicates(WithoutSpecialChars);

            if (DuplicationCounts > 1)
                return ConcatenateDuplicateIndexToSeoFriendlyName(WithoutSpecialChars, DuplicationCounts);
            else
                return WithoutSpecialChars;
        }


        public List<SEOFriendlyPageNamesTable> GetSEOFriendlyPageNamesTable()
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            //var dormImages = from dormImage in _dormImageRepo.List().ToList()
            //                 join Image in _imageRepo.List().ToList() on dormImage.CatalogImageId equals Image.Id
            //                 select new { dormImage.DormitoryId, Image.ImageUrl, Image.Published };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitory = from dorm in _dormitoryRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.Id)).ToList().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new
                            {
                                dorm.SeoId,
                                DormitoryId = dorm.Id,
                                Picture = (dorm.DormitoryLogoUrl != null) ? ((dorm.DormitoryLogoUrl.Length > 0) ? dorm.DormitoryLogoUrl : "/Content/dist/img/default-image_100.png") : "/Content/dist/img/default-image_100.png",
                                DormitoryName = dormTrans.DormitoryName,
                                SKU = dorm.SKU,
                                DormitoryType = dormitoryType.ToList().Where(c => c.Id == dorm.DormitoryTypeId).FirstOrDefault().Title,
                                Published = dorm.Published
                            };


            var SeoList = from seo in _SeoRepo.List().ToList()
                          join dorm in dormitory.ToList() on seo.Id equals dorm.SeoId
                          select new SEOFriendlyPageNamesTable
                          {
                              Id = seo.Id,
                              SeoFriendlyName = seo.SearchEngineFriendlyPageName,
                              DormitoryId = dorm.DormitoryId,
                              DormitoryName = dorm.DormitoryName,
                              DormitoryType = dorm.DormitoryType,
                              IsActive = dorm.Published,
                          };

            return SeoList.ToList();

        }

    }

    public class SEOFriendlyPageNamesTable
    {
        public long Id { get; set; }
        public string SeoFriendlyName { get; set; }
        public long DormitoryId { get; set; }
        public string DormitoryName { get; set; }
        public bool IsActive { get; set; }

        public string EditPage { get; set; }
        public string DormitoryType { get; internal set; }
    }
}
