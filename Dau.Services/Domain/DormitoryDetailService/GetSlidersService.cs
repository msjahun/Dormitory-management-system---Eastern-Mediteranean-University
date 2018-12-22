using Dau.Core.Domain.Catalog;
using Dau.Data;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetSlidersService : IGetSlidersService
    {
        private readonly IRepository<CatalogImage> _imagesRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepo;

        public GetSlidersService(IRepository<CatalogImage> imagesRepository,
                    IRepository<Dormitory> DormitoryRepository,
                    IRepository<DormitoryCatalogImage> DormitoryImageRepository
              
            )
        {
            _imagesRepo = imagesRepository;
            _dormitoryImageRepo = DormitoryImageRepository;
          
        }

        public SlidersSectionViewModel GetSliders(long DormitoryId)
        {

            var Images = from imageList in _imagesRepo.List().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         where dormImage.DormitoryId == DormitoryId
         select new { imageList.ImageUrl };



            var flatList = Images.Select(x => x.ImageUrl).ToList();



            SlidersSectionViewModel model = new SlidersSectionViewModel
            {
                ImageUrls = flatList
            };

         
            return model;
        }
    }

    public class SlidersSectionViewModel
    {
        public List<string> ImageUrls { get; set; }
    }


}
