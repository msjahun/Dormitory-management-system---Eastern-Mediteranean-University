using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Results()
        {
            return View("SearchResultPage");
        }


        public IActionResult GetDormitoryResultView()
        {
            IEnumerable<DormitoryResultViewModel> modelList = new List<DormitoryResultViewModel>
            {
                new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                DormitoryType = "Apartments",
                DormitoryName = "Alfam Dormitory",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                ReviewNo = 19,
                Location = "North-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NoTimesBooked = 55,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                IsbookedInlast24hours=false

            },
                   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",
                 
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Studio",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.8,
                RatingText = "Very Good",
                ReviewNo = 13,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Charles Darwin Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b63",
                ClosestLandMark = "(1.2 km from Pharmacy department)",
                UniqueAttribute = "2 mins to international office",
                   IsbookedInlast24hours=false

            },
                      new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1232.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
              
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
              
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Girls dormitory",
                DormitoryName = "EMU Sabanci",
                RatingNo = 9.1,
                RatingText = "Good",
                ReviewNo = 23,
                Location = "East-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Leonardo da Vinci Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b62",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Cafeteria access",
                   IsbookedInlast24hours=false

            },   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                         "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                  
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Dormitory",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.1,
                RatingText = "Excellent",
                ReviewNo = 34,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b66",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Bus stop access",
                   IsbookedInlast24hours=true

            },
                         new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                DormitoryType = "Apartments",
                DormitoryName = "Alfam Dormitory",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                ReviewNo = 19,
                Location = "North-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NoTimesBooked = 55,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                IsbookedInlast24hours=false

            },
                   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Studio",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.8,
                RatingText = "Very Good",
                ReviewNo = 13,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Charles Darwin Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b63",
                ClosestLandMark = "(1.2 km from Pharmacy department)",
                UniqueAttribute = "2 mins to international office",
                   IsbookedInlast24hours=false

            },
                      new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1232.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Girls dormitory",
                DormitoryName = "EMU Sabanci",
                RatingNo = 9.1,
                RatingText = "Good",
                ReviewNo = 23,
                Location = "East-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Leonardo da Vinci Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b62",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Cafeteria access",
                   IsbookedInlast24hours=false

            },   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                         "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Dormitory",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.1,
                RatingText = "Excellent",
                ReviewNo = 34,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b66",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Bus stop access",
                   IsbookedInlast24hours=true

            },
                         new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                DormitoryType = "Apartments",
                DormitoryName = "Alfam Dormitory",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                ReviewNo = 19,
                Location = "North-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NoTimesBooked = 55,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                IsbookedInlast24hours=false

            },
                   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Studio",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.8,
                RatingText = "Very Good",
                ReviewNo = 13,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Charles Darwin Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b63",
                ClosestLandMark = "(1.2 km from Pharmacy department)",
                UniqueAttribute = "2 mins to international office",
                   IsbookedInlast24hours=false

            },
                      new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1232.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Girls dormitory",
                DormitoryName = "EMU Sabanci",
                RatingNo = 9.1,
                RatingText = "Good",
                ReviewNo = 23,
                Location = "East-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Leonardo da Vinci Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b62",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Cafeteria access",
                   IsbookedInlast24hours=false

            },   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                         "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Dormitory",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.1,
                RatingText = "Excellent",
                ReviewNo = 34,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b66",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Bus stop access",
                   IsbookedInlast24hours=true

            },
                         new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                DormitoryType = "Apartments",
                DormitoryName = "Alfam Dormitory",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                ReviewNo = 19,
                Location = "North-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NoTimesBooked = 55,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                IsbookedInlast24hours=false

            },
                   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Studio",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.8,
                RatingText = "Very Good",
                ReviewNo = 13,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Charles Darwin Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b63",
                ClosestLandMark = "(1.2 km from Pharmacy department)",
                UniqueAttribute = "2 mins to international office",
                   IsbookedInlast24hours=false

            },
                      new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1232.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Girls dormitory",
                DormitoryName = "EMU Sabanci",
                RatingNo = 9.1,
                RatingText = "Good",
                ReviewNo = 23,
                Location = "East-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = true,
                DormitoryStreetAddress = "Leonardo da Vinci Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b62",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Cafeteria access",
                   IsbookedInlast24hours=false

            },   new DormitoryResultViewModel
            {
                ImageUrls = new List<string>
                {
                         "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6"

                },
                DormitoryType = "Dormitory",
                DormitoryName = "Akdeniz private Studio",
                RatingNo = 7.1,
                RatingText = "Excellent",
                ReviewNo = 34,
                Location = "South-Campus",
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                ReservationPosibleWithoutCreditCard = false,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                NoTimesBooked = 22,
                NoHours = 2,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty"+"#b66",
                ClosestLandMark = "(1.2 km from Central lecture hall)",
                UniqueAttribute = "Bus stop access",
                   IsbookedInlast24hours=true

            }

            };
           
            return PartialView("_DormitoryResultView", modelList);
        }


        public IActionResult GetFilterbottomFacilities()
        {
            List<FiltersFacilityViewModel> modelList = new List<FiltersFacilityViewModel>
            {new FiltersFacilityViewModel
            {
                FacilityName = "TV",
                FacilityIconUrl = "Dormitories_files/tv.png",
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="In Room",
                        OptionCount=236
                    },
                    new FacilityOptions
                    {
                        OptionName="In Hall",
                        OptionCount=6
                    }
                }
            },

            new FiltersFacilityViewModel
            {
                FacilityName = "Internet",
                FacilityIconUrl = "Dormitories_files/internet_wifi.png",
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Wireless",
                        OptionCount=2
                    },
                    new FacilityOptions
                    {
                        OptionName="Cable",
                        OptionCount=36
                    }
                }
            },


            new FiltersFacilityViewModel
            {
                FacilityName = "WC-Shower",
                FacilityIconUrl = "Dormitories_files/wc-shower.png",
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="In Room",
                        OptionCount=19
                    },  new FacilityOptions
                    {
                        OptionName="Common",
                        OptionCount=25
                    },
                    new FacilityOptions
                    {
                        OptionName="Flats",
                        OptionCount=24
                    }
                }
            },


            new FiltersFacilityViewModel
            {
                FacilityName = "Kitchenette",
                FacilityIconUrl = null,
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="In Room",
                        OptionCount=4
                    },
                    new FacilityOptions
                    {
                        OptionName="Cable",
                        OptionCount=0
                    }
                }
            },


            new FiltersFacilityViewModel
            {
                FacilityName = "Bed",
                FacilityIconUrl = "Dormitories_files/bed.png",
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Bunk",
                        OptionCount=42
                    },
                    new FacilityOptions
                    {
                        OptionName="Normal",
                        OptionCount=16
                    }
                }
            },


            new FiltersFacilityViewModel
            {
                FacilityName = "Necessities",
                FacilityIconUrl = null,
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Air Condition(AC)",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="Central Heating",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="Refrigerator",
                        OptionCount=16
                    },

                       new FacilityOptions
                    {
                        OptionName="Laundry",
                        OptionCount=24
                    },
                    new FacilityOptions
                    {
                        OptionName="Room Tel",
                        OptionCount=2
                    },
                       new FacilityOptions
                    {
                        OptionName="Generator",
                        OptionCount=5
                    }
                }
            }

            };
         




            return PartialView("_FilterbottomFacilities", modelList);
        }


        public IActionResult GetRoomResultView()
        {
            List<RoomResultViewModel> modelList = new List<RoomResultViewModel>
            {
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",
                
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys only",
                DormitoryName = "Akdeniz Dormitory",
                DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                        RoomName ="Double Room",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=true,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
               Price="1,839.00",
              

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                       "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
              
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys and girls",
                DormitoryName = "Novel Dormitory",
                  DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                        RoomName ="Quadruple Room",
                RatingText = "Fantastic",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=false,
                PercentageOff = 20,
                DisplayDeal=false,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                   Price="1,839.00"
           

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=false,
                PercentageOff = 20,
                DisplayDeal=false,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                Price="1,839.00"
              

            },
                 new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys only",
                DormitoryName = "Akdeniz Dormitory",
                DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                        RoomName ="Double Room",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 3,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=true,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
               Price="1,839.00",
                OldPrice="2,000.99"

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                       "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys and girls",
                DormitoryName = "Novel Dormitory",
                  DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                        RoomName ="Quadruple Room",
                RatingText = "Fantastic",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=false,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                   Price="1,839.00",
                OldPrice="2,000.99"

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(-3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 5,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=true,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                Price="1,839.00",
                OldPrice="2,000.99"

            },
                 new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                          "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys only",
                DormitoryName = "Akdeniz Dormitory",
                DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                        RoomName ="Double Room",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=true,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
               Price="1,839.00",
                OldPrice="2,000.99"

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {
                       "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys and girls",
                DormitoryName = "Novel Dormitory",
                  DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                        RoomName ="Quadruple Room",
                RatingText = "Fantastic",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 55,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=false,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                   Price="1,839.00",
                OldPrice="2,000.99"

            },
                new RoomResultViewModel
            {
                ImageUrls = new List<string>
                {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
                    "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

                },
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                ReviewNo = 19,
                DealEndTime = DateTime.Now.AddDays(3),
                ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
                DormitoryStreetAddress = "Albert-Einstein, Street",
                NumberOfRoomsLeft = 2,
                DisplayNoRoomsLeft=true,
                PercentageOff = 20,
                DisplayDeal=false,
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
                ClosestLandMark = "(2 min to Health center and CMPE dept.)",
                UniqueAttribute = "Bus stop access",
                Price="1,839.00",
            

            }
            };
        

            return PartialView("_RoomResultView", modelList);
        }


        public IActionResult GetSortingButtonSection()
        {
            return PartialView("_SortingButtonsSection");
        }
        public IActionResult GetOnScrollAlert()
        {
            List<onScrollAlert> modelList = new List<onScrollAlert>
            {
                new onScrollAlert
            {
                Text="Someone just booked a room from {0}!, book yours now",
                Icon="fas fa-lock",
                name="Alfam Dormitory",
                link="http://35.204.232.129/Dormitory/Detail",
                Color="alert-danger"


            },
                new onScrollAlert
            {
                Text="Would you like to partake in a {0} survey!, you'll get free coupons afterwards",
            Icon="fas fa-lock",
                name="Student feedback",
                link="http://35.204.232.129/Account/Billing",
                Color="alert-success"


            },
                new onScrollAlert
            {
                Text="{0}!, you still haven't confirmed your booking, would you like to do it now",
                Icon="fas fa-lock",
                name="Musa",
                Color="alert-success",
                 link="http://35.204.232.129/Account/Billing"


            },
                new onScrollAlert
            {
                Text="Hi there would you like to check out the  {0}!, students are saying it's awesome",
                Icon="fas fa-lock",
                name="EMU explore page",
                link="https://localhost:44340/Explore/Dormitories",
                Color="alert-info"


            },       new onScrollAlert
            {
                Text="Hi did you know you don't need credit card to book a room {0}!",
                Icon="fas fa-lock",
                name=" ",
      
                Color="alert-info"


            }
            };

            Random rnd = new Random();
       
            int randomNumber = rnd.Next(modelList.Count);

            return PartialView("_onScrollAlert", modelList[randomNumber]);
        }
    }


public class DormitoryResultViewModel
    {
        public List<string> ImageUrls { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryName { get; set; }
        public double RatingNo { get; set; }
        public string RatingText { get; set; }
        public int ReviewNo { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public bool ReservationPosibleWithoutCreditCard { get; set; }

        public string DormitoryStreetAddress { get; set; }
        //Booked 3 times in the last 4 hours
        public int NoTimesBooked { get; set; }
        public int NoHours { get; set; }
        public bool IsbookedInlast24hours { get; set; }

        //mapSection in ergec campus map
        public string MapSection { get; set; }

        //(1.8 km from Central lecture hall
        public string ClosestLandMark { get; set; }

        //-Bus stop access
        public string UniqueAttribute { get; set; }



    }



    public class RoomResultViewModel
    {
        public List<string> ImageUrls { get; set; }
        public string GenderAllocation { get; set; }
        public string RoomName { get; set; }
        public string DormitoryName { get; set; }
        public double RatingNo { get; set; }
        public string RatingText { get; set; }
        public int ReviewNo { get; set; }
       
        public DateTime DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }

        public int PercentageOff { get; set; }

        public string DormitoryRoomBlock { get; set; }
        public string ShortDescription { get; set; }
       
        public string DormitoryStreetAddress { get; set; }
        //Booked 3 times in the last 4 hours
      public int NumberOfRoomsLeft { get; set; }
       public bool DisplayNoRoomsLeft { get; set; }
        //mapSection in ergec campus map
        public string MapSection { get; set; }

        //(1.8 km from Central lecture hall
        public string ClosestLandMark { get; set; }

        //-Bus stop access
        public string UniqueAttribute { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }



    }

    public class FiltersFacilityViewModel
    {
        public string FacilityName { get; set; }
        public string FacilityIconUrl { get; set; }
        public List<FacilityOptions> FacilityOptions { get; set; }

    }

    public class FacilityOptions
    {
        public string OptionName { get; set; }
        public int OptionCount { get; set; }
    }

    public class onScrollAlert
    {
        public string Text { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }

}
