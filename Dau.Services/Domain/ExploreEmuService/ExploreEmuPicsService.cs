using Dau.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Dau.Services.Languages;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Core.Domain.SearchEngineOptimization;

namespace Dau.Services.Domain.ExploreEmuService
{
   public class ExploreEmuPicsService : IExploreEmuPicsService
    {
        private readonly ILanguageService _languageService;
        private readonly IResolveDormitoryService _resolveDormitoryService;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepository;
        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepository;
        private readonly IRepository<CatalogImage> _imagesRepository;
        private readonly IRepository<Seo> _seoRepository;

        public ExploreEmuPicsService(
             ILanguageService languageService,
              IResolveDormitoryService resolveDormitoryService,
              IRepository<Dormitory> DormitoryRepository,
              IRepository<DormitoryTranslation> DormitoryTransRepository,
              IRepository<DormitoryCatalogImage> DormitoryImageRepository,
              IRepository<CatalogImage> ImagesRepository,
              IRepository<Seo> SeoRepository)
        {
            _languageService = languageService;
            _resolveDormitoryService = resolveDormitoryService;
            _dormitoryRepository=  DormitoryRepository;
            _dormitoryTransRepository= DormitoryTransRepository;
            _dormitoryImageRepository= DormitoryImageRepository;
            _imagesRepository= ImagesRepository;
            _seoRepository = SeoRepository;

        }

        public List<ExploreImages> GetExploreEmuPics()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var Dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTransRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, dormTrans.DormitoryName, dorm.SeoId};

            var DormSeo = from Dorm in Dormitories.ToList()
                          join seo in _seoRepository.List().ToList() on Dorm.SeoId equals seo.Id
                          select new { Dorm.Id, Dorm.DormitoryName, seo.SearchEngineFriendlyPageName };

            var Images = from imageList in _imagesRepository.List().ToList()
                         join dormImage in _dormitoryImageRepository.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.Id, imageList.ImageUrl, dormImage.DormitoryId };

            var dormImages = from dorm in DormSeo.ToList()
                             join image in Images.ToList() on dorm.Id equals image.DormitoryId
                             select new ExploreImages
                             {
                                 DormitoryName = dorm.DormitoryName,
                                 ImageUrl = image.ImageUrl,
                                 DormitorySeoFriendlyUrl = dorm.SearchEngineFriendlyPageName
                             };


            




            var model = dormImages.OrderBy(x => Guid.NewGuid()).Take(4).ToList();

          //  var model = new List<ExploreImages>();
            return model;


                
        }
    }

    public class ExploreImages
    {
        public string ImageUrl { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryDescription { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
    }
}
