using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.ExploreEmuService
{
   public class ExploreEmuPicsService : IExploreEmuPicsService
    {

        public List<ExploreImages>  GetExploreEmuPics()
        {
            var model = new List<ExploreImages> {
            new ExploreImages{
                ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=9",
               DormitoryName = "Alfam Dormitory",
                 DormitorySeoFriendlyUrl = "Alfam-dormitory",
                DormitoryDescription = "Wonderful dormitory"},


                new ExploreImages { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047915.jpg?RenditionID=5",
                DormitoryName = "Akdeniz private Studio",
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
                DormitoryDescription = "Wonderful dormitory"},


              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0050%20(1).jpg?RenditionID=8",
                  DormitoryName = "EMU Sabanci",
                DormitorySeoFriendlyUrl = "EMU-Sabanci",
                DormitoryDescription = "Wonderful dormitory"},

                      new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=7",
                DormitoryName = "Novel Dormitory",
                 DormitorySeoFriendlyUrl = "Novel-dormitory",
                DormitoryDescription = "Wonderful dormitory"},


                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0004.jpg?RenditionID=8",
                DormitoryName = "Pop art Dormitory",
                 DormitorySeoFriendlyUrl = "Pop-art-dormitory",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/astra/IMG-20171014-WA0010.jpg?RenditionID=5",
                DormitoryName = "Sanel Dormitory",
                 DormitorySeoFriendlyUrl = "sanel-dormitory",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                DormitoryName = "Hasan Uzuk Dormitory",
                 DormitorySeoFriendlyUrl = "Hasan-Uzuk-dormitory",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=8",
                 DormitoryName = "Longson Dormitory",
                 DormitorySeoFriendlyUrl = "Longson-dormitory",
                DormitoryDescription = "Wonderful dormitory"},


            };
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
