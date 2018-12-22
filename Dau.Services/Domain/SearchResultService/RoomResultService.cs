using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
  public  class RoomResultService : IRoomResultService
    {
        public RoomResultService()
        {
        }

        public List<RoomResultViewModel> GetRoomResult()
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
                Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{ 
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=235,
                GenderAllocation = "Boys only",
                DormitoryName = "Akdeniz Dormitory",
                DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                  DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
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

                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=2454,
                GenderAllocation = "Boys and girls",
                DormitoryName = "Novel Dormitory",
                  DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                  DormitorySeoFriendlyUrl = "Novel-Dormitory",
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
                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=454,
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                      
                 RoomId=344,
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
                  DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
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

                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=264,
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
                  DormitorySeoFriendlyUrl = "Novel-Dormitory",
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
                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=253,
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                ReviewNo = 19,
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=34,
                GenderAllocation = "Boys only",
                DormitoryName = "Akdeniz Dormitory",
                DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                RatingText = "Fantastic",
                        RoomName ="Double Room",
                ReviewNo = 19,
                  DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
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
                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=264,
                GenderAllocation = "Boys and girls",
                DormitoryName = "Novel Dormitory",
                  DormitoryRoomBlock = "A Block",
                RatingNo = 4.6,
                        RoomName ="Quadruple Room",
                RatingText = "Fantastic",
                ReviewNo = 19,
                  DormitorySeoFriendlyUrl = "Novel-Dormitory",
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
                         Features = new List<FeaturesViewModel>
                {
                    new FeaturesViewModel{
                       FeatureName="Desk lamp"
            },
                  new FeaturesViewModel
            {
                IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FeatureName="TV"
            },
                   new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                FeatureName="WC-shower"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FeatureName="Refrigerator"
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FeatureName="Room tel."
            },
                    new FeaturesViewModel
            {
                 IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FeatureName="Generator"
            }
                },
                 RoomId=234,
                GenderAllocation = "Boys & Girls only",
                DormitoryName = "Alfam Dormitory",
                RoomName ="Single Room",
                  DormitoryRoomBlock = "Studio block",
                RatingNo = 9.2,
                RatingText = "Excellent",
                ReviewNo = 19,
                  DormitorySeoFriendlyUrl = "Alfam-dormitory",
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
            return modelList;
        }
    }


    public class RoomResultViewModel
    {
        public long RoomId { get; set; }
        public List<string> ImageUrls { get; set; }
        public string GenderAllocation { get; set; }
        public string RoomName { get; set; }
        public string DormitoryName { get; set; }
        public double RatingNo { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
        public string RatingText { get; set; }
        public int ReviewNo { get; set; }

        public DateTime DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
        public List<FeaturesViewModel> Features { get; set; }
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
    public class FeaturesViewModel
    {
        public string IconUrl { get; set; }
        public string FeatureName { get; set; }
    }

}
