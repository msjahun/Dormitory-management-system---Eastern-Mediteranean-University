using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.HomeService
{
    public class GetHomeBackgroundImagesService : IGetHomeBackgroundImagesService
    {
        public List<string> GetBackgrouindImages()
        {
            var model = new List<string> {
                "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=12",
           "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=12",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1232.jpg?RenditionID=12",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=12",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=12" };

            return model;
        }
    }
}
