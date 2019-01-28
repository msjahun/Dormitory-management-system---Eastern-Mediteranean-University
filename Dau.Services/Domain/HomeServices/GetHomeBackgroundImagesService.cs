using Dau.Core.Domain.SliderImages;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.HomeService
{
    public class GetHomeBackgroundImagesService : IGetHomeBackgroundImagesService
    {
        private readonly IRepository<SliderImage> _sliderImageRepo;

        public GetHomeBackgroundImagesService(IRepository<SliderImage> sliderImageRepo)
        {
            _sliderImageRepo = sliderImageRepo;
        }

        public List<string> GetBackgrouindImages()
        {
            var sliderImages = from sliderImage in _sliderImageRepo.List().ToList()
                               where sliderImage.IsVisible == true
                               orderby sliderImage.DisplayOrder ascending
                               select sliderImage.PictureUrl;
            var model = sliderImages.ToList();
            return model;
        }
    }
}
