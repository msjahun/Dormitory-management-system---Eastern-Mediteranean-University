using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class DormitoryController : Controller
    {
        public IActionResult Detail()
        {

            return View("DormitoryDetail");
        }


        public IActionResult GetAreaInfoSection()


        {
            AreaInfoSectionViewModel model = new AreaInfoSectionViewModel
            {
                LocationRemark = "Excellent location",
                DormitoryName = "Alfam Dormitory",
                MapSection = "https://www.emu.edu.tr/campusmap?design=empty#b85",
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                CloseLocations = new List<Locationinformation>
        {
            new Locationinformation
            {
                NameOfLocation="Computer Engineering dept.",
                Distance="4 mi",
                Duration="2 mins",
                MapSection="https://www.emu.edu.tr/campusmap?design=empty#b21"
            },
             new Locationinformation
            {
                NameOfLocation="Health center",
                Distance="7 mi",
                Duration="3 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b32"
            },

              new Locationinformation
            {
                NameOfLocation="Koop bank atm machine",
                Distance="12 mi",
                Duration="13 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b87"
            }
        }
            };

            return PartialView("_AreaInfoSection", model);
        }


        public IActionResult GetCommentsSection()
        {
            List<CommentSectionViewModel> modelList = new List<CommentSectionViewModel>
            {
                 new CommentSectionViewModel
                {
                    UserFullName = "Ahmed Bassiouny",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://scontent-vie1-1.xx.fbcdn.net/v/t1.0-0/p168x128/16472881_1354143061327538_335400885864373680_n.jpg?_nc_cat=104&_nc_ht=scontent-vie1-1.xx&oh=05d8c8f18b5014a974a5b90ff4a7f7ac&oe=5C8647DD",
                    UserComment = "Cras at, tempus viverra turpis..."
                },
                   new CommentSectionViewModel
                {
                    UserFullName = "Ahmet Önder Beşiroğlu",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100000249531894&width=72&height=72",
                    UserComment = "Cras sitstibulum in vulputate at, tempus viverra turpis...."
                },

                            new CommentSectionViewModel
                {
                    UserFullName = "Abdullahi Ismail",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://avatars3.githubusercontent.com/u/35945225?s=460&v=4",
                    UserComment = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metusras purus odio, vestibulum in vulputate at, tempus viverra turpis."
                },
                     new CommentSectionViewModel
                {
                    UserFullName = "Ivy Thompson",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://avatars0.githubusercontent.com/u/14825113?s=400&v=4",
                    UserComment = "Cras at, tempus viverra turpis..."
                },

              

                         new CommentSectionViewModel
                {
                    UserFullName = "Kamal MG",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100001237759702&width=72&height=72",
                    UserComment = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metusras purus odio, vestibulum in vulputate at, tempus viverra turpis."
                }

               
            };
            
            return PartialView("_CommentsSection", modelList);
        }

        public IActionResult GetDormitoryDescriptionSection()
        {

            DormitoryDescriptionSectionViewModel model = new DormitoryDescriptionSectionViewModel
            {

                RatingText = "Excellent",
                RatingNo = "9.7",
                ReviewNo = 23,
                Location = "South-Campus",
                NoOfStudents = 200,
                Option = "Staff",
                OptionValue = "Staff are very friendly",
                StandAloneOption = "Has a gym!",
                NoOfAwards = "3",
                NoOfNewFacilities = "5",
                NoOfStaff = "4",

                DormitoryDescription = " Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +
           
           " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

            "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

           "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."

            };
            return PartialView("_DormitoryDescriptionSection", model);
        }


        public IActionResult GetFacilitiesSection()
        {
            return PartialView("_FacilitiesSection");
        }
        public IActionResult GetFilterSection()
        {
            return PartialView("_FilterSection");
        }


        public IActionResult GetGoodToKnowSection()
        {
            return PartialView("_GoodToKnowSection");
        }


        public IActionResult GetReviewBottomSection()
        {
            return PartialView("_ReviewBottomSection");
        }


        public IActionResult GetRoomSection()
        {
            List<RoomSectionViewModel> modelList = new List<RoomSectionViewModel>
            {
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Single Room",
                DormitoryBlock="A block",
                GenderAllocation="Females only",
                NoOfStudents = 1,
                BedType = "Normal Bed",
                Price = "5.3456,00",
                //  PriceOld ,
                RoomsQuota = 0,
                HasDeposit = false,
                ShowPrice = true,
            },

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Quadruble Room",
                 GenderAllocation="Males",
                NoOfStudents = 4,
                DormitoryBlock="C block",
                BedType = "Bunk Bed",
                Price = "2.3456,00",
                PriceOld="2.3456,00",
                RoomsQuota = 2,
                HasDeposit = false,
                ShowPrice = true,
            },
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Double room",
                NoOfStudents = 2,
                 GenderAllocation="Males and female",
                DormitoryBlock="Alfam vista",
                BedType = "Normal Bed",
                Price = "3.3456,00",
                //  PriceOld ,
                RoomsQuota = 3,
                HasDeposit = true,
                ShowPrice = true,
            },
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Studio apartment",
                NoOfStudents = 2,
                DormitoryBlock="C block",
                 GenderAllocation="Females only",
                BedType = "Normal Bed",
                Price = "6.3456,00",
                PriceOld="8.3456,00", 
                RoomsQuota = 4,
                HasDeposit = true,
                ShowPrice = false,
            },

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Single Room",
                NoOfStudents = 2,
                 GenderAllocation="Males only",
                DormitoryBlock="B block",
                BedType = "Normal Bed",
                Price = "6.3456,00",
                PriceOld="8.3456,00",
                RoomsQuota = 0,
                HasDeposit = false,
                ShowPrice = true,
            }
,

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Studio apartment",
                NoOfStudents = 2,
                BedType = "Normal Bed",
                 GenderAllocation="Males and female",
                DormitoryBlock="Alfam studio block",
                Price = "6.3456,00",
                PriceOld="8.3456,00",
                RoomsQuota = 4,
                HasDeposit = false,
                ShowPrice = true,
            }
            };
            return PartialView("_RoomSection", modelList);
        }


        public IActionResult GetSlidersSection()

        {
            SlidersSectionViewModel model = new SlidersSectionViewModel
            {
                ImageUrls = new List<string>
                {
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=4",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=10",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=12",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=5",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
                    "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9"
                }
            };
            return PartialView("_SlidersSection", model);
        }

        public IActionResult GetTopnavDormitorySection()
        {
            TopNavDormitorySectionViewModel model = new TopNavDormitorySectionViewModel
            {
                DormitoryName = "Alfam Dormitory EMU University",
                DormitoryStreetAddress = "EMU charles Darwin street",
                DormitoryType = "Dormitory belongs to the category of private school dormitories/ accomodations (BOT),",
                DormitoryLogoUrl = "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg"
            };

            return PartialView("_TopnavDormitorySection", model);
        }

    }


    public class TopNavDormitorySectionViewModel
    {
        public string DormitoryName { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryLogoUrl { get; set; }

    }


    public class SlidersSectionViewModel
    {
        public List<string> ImageUrls { get; set; }
    }

    public class CommentSectionViewModel
    {
        public string UserFullName { get; set; }
        public string UserImageUrl { get; set; }
        public string UserComment { get; set; }
        public double UserRatingNo { get; set; }
    }


    public class DormitoryDescriptionSectionViewModel
    {
        public string DormitoryDescription { get; set; }
        public string RatingText { get; set; }
        public int NoOfStudents { get; set; }
        public string RatingNo { get; set; }
        public int ReviewNo{ get; set; }
        public string Location { get; set; }
        public string Option { get; set; }//staff
        public string OptionValue { get; set; }//staff are very friendly
        public string StandAloneOption { get; set; }//has a gym!
        public string NoOfNewFacilities { get; set; }
        public string NoOfStaff { get; set; }
        public string NoOfAwards { get; set; }

    }


    public class RoomSectionViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string GenderAllocation { get; set; }
        public int NoOfStudents { get; set; }
        public string DormitoryBlock { get; set; }
        public string BedType { get; set; }
        public string Price { get; set; }
        public string PriceOld { get; set; }
        public int RoomsQuota { get; set; }
        public bool HasDeposit { get; set; }
        public bool ShowPrice { get; set; }

    }

    public class AreaInfoSectionViewModel
    {
        public string LocationRemark { get; set; }
        public string DormitoryName { get; set; }
        public string MapSection { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public List<Locationinformation> CloseLocations { get; set; }

    }

    public class Locationinformation
    {
        public string NameOfLocation { get; set; }
        public string Distance { get; set; }
        public string MapSection { get; set; }
        public string Duration { get; set; }
    }
}
