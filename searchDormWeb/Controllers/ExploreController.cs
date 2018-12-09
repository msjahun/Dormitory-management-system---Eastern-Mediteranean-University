using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class ExploreController : Controller
    {

        public IActionResult Dormitories()
        {
            return View("ExploreEMU");
        }



        public IActionResult ExploreEMUPicsApi()
        {




            return Json(new List<ExploreImages> {
            new ExploreImages{
                ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=9",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},


                new ExploreImages { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047915.jpg?RenditionID=5",
                DormitoryName = "Alfam Dormitory5",
                DormitoryDescription = "Wonderful dormitory"},


              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0050%20(1).jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},

                      new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=7",
                DormitoryName = "Alfam Dormitory7",
                DormitoryDescription = "Wonderful dormitory"},


                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0004.jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory8",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/astra/IMG-20171014-WA0010.jpg?RenditionID=5",
                DormitoryName = "Alfam Dormitory5",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory8",
                DormitoryDescription = "Wonderful dormitory"},


            }


                );

        }


    }

    public class ExploreImages
    {
        public string ImageUrl { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryDescription { get; set; }
    }
}
