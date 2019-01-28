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
using Dau.Core.Domain.SliderImages;

namespace Dau.Services.Domain.ImageServices
{
   public class SliderImageService : ISliderImageService
    {
        private readonly IRepository<SliderImage> _sliderImageRepo;
        private readonly ILanguageService _languageService;
        private readonly IResolveDormitoryService _resolveDormitoryService;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepository;
        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepository;
        private readonly IRepository<CatalogImage> _imagesRepository;
        private readonly IRepository<Seo> _seoRepository;

        public SliderImageService(ILanguageService languageService,
              IResolveDormitoryService resolveDormitoryService,
              IRepository<Dormitory> DormitoryRepository,
              IRepository<DormitoryTranslation> DormitoryTransRepository,
              IRepository<DormitoryCatalogImage> DormitoryImageRepository,
              IRepository<CatalogImage> ImagesRepository,
              IRepository<Seo> SeoRepository,
              IRepository<SliderImage> sliderImageRepo)
        {
            _sliderImageRepo = sliderImageRepo;
            _languageService = languageService;
            _resolveDormitoryService = resolveDormitoryService;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTransRepository = DormitoryTransRepository;
            _dormitoryImageRepository = DormitoryImageRepository;
            _imagesRepository = ImagesRepository;
            _seoRepository = SeoRepository;

        }

        public List<HomeSlideShowImagesTable> GetHomeSlideShowImagesTable()
        {
            var SliderImages = from slider in _sliderImageRepo.List().ToList()
                               select new HomeSlideShowImagesTable
                               {  PictureId = slider.Id,
                                   PictureHeight = slider.PictureHeight +"px",
                                   PictureWidth = slider.PictureWidth+"px",
                                   PictureUrl ="/"+ slider.PictureUrl,
                                   IsVisible = slider.IsVisible,
                                   DisplayOrder = slider.DisplayOrder,
                                   UploadDate = slider.UploadDate.ToString()
                               };

            var model = SliderImages.ToList();

            return model;
        }

        public List<ExploreEmuImagesTableList> GetExploreEmuImagesTable()
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var Dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTransRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, dormTrans.DormitoryName, dorm.SeoId, dorm.DormitoryTypeId };

          
            var Images = from imageList in _imagesRepository.List().ToList()
                         join dormImage in _dormitoryImageRepository.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.Id, imageList.ImageUrl, dormImage.DormitoryId, imageList.AllowInExploreEMU, imageList.CreatedDate };

            var model = from dorm in Dormitories.ToList()
                             join image in Images.ToList() on dorm.Id equals image.DormitoryId
                             select new ExploreEmuImagesTableList
                             {
                                 PictureId = image.Id,
                                 Dormitory = dorm.DormitoryName,
                                 PictureUrl = image.ImageUrl,
                                 AllowOnExploreEmuPage = image.AllowInExploreEMU,
                                 UploadDate = image.CreatedDate.ToString(),
                                 DormitoryTypeId = dorm.DormitoryTypeId
                             };

           
            return model.ToList();

        }


        public bool AllowImageExploreEmu(long ImageId)
        {
            try { 
            var Image = _imagesRepository.GetById(ImageId);
            if (Image == null) return false;

            Image.AllowInExploreEMU = true;
            _imagesRepository.Update(Image);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DisallowImageExploreEmu(long ImageId)
        {
            try
            {
                var Image = _imagesRepository.GetById(ImageId);
                if (Image == null) return false;

                Image.AllowInExploreEMU = false;
                _imagesRepository.Update(Image);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public SliderImage GetImageInformationById(long imageId)
        {
           var sliderImage=    _sliderImageRepo.GetById(imageId);
            if (sliderImage == null) return null;
            return sliderImage;
        }

        public bool SetImageInformation(SliderImage vm)
        {
            try
            {
                var model = _sliderImageRepo.GetById(vm.Id);
                if (model == null) return false;

                model.IsVisible = vm.IsVisible;
                model.DisplayOrder = vm.DisplayOrder;
                _sliderImageRepo.Update(model);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteHomeSliderImage(long imageId)
        {
            try
            {
                var ImageToDelete = _sliderImageRepo.GetById(imageId);
                if (ImageToDelete == null) return false;

                _sliderImageRepo.Delete(ImageToDelete);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


    public class HomeSlideShowImagesTable
    {
        public long PictureId { get; set; }
        public string PictureUrl { get; set; }
        public string PictureHeight { get; set; }
        public string PictureWidth { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsVisible { get; set; }
        public string UploadDate { get; set; }
    }

    public class ExploreEmuImagesTableList

    {
        public long DormitoryTypeId { get; set; }
        public long PictureId { get; set; }
        public string PictureUrl { get; set; }
        public string Dormitory { get; set; }
        public string UploadDate { get; set; }
        public bool AllowOnExploreEmuPage { get; set; }
    }
}
