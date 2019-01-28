using System.Collections.Generic;
using Dau.Core.Domain.SliderImages;

namespace Dau.Services.Domain.ImageServices
{
    public interface ISliderImageService
    {
        List<ExploreEmuImagesTableList> GetExploreEmuImagesTable();
        List<HomeSlideShowImagesTable> GetHomeSlideShowImagesTable();
        bool DisallowImageExploreEmu(long ImageId);
        bool AllowImageExploreEmu(long ImageId);
        SliderImage GetImageInformationById(long imageId);
        bool SetImageInformation(SliderImage vm);
        bool DeleteHomeSliderImage(long imageId);
    }
}