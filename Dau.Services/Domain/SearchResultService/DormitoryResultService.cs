using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
    public class DormitoryResultService : IDormitoryResultService
    {
        public List<DormitoryResultViewModel> GetDormitoryResult()
        {
            List<DormitoryResultViewModel> modelList = new List<DormitoryResultViewModel>
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
                 DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "EMU-Sabanci",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "EMU-Sabanci",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "EMU-Sabanci",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
                DormitorySeoFriendlyUrl = "EMU-Sabanci",
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
                  DormitorySeoFriendlyUrl = "Akdeniz-private-Studio",
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
            return modelList;
        }
    }


    public class DormitoryResultViewModel
    {
        public List<string> ImageUrls { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryName { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
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
}
