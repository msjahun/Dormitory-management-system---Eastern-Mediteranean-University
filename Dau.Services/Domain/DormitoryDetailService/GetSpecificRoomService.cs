using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetSpecificRoomService : IGetSpecificRoomService
    {
        public SpecificRoomViewModel GetSpecificRoom()
        {
            SpecificRoomViewModel model = new SpecificRoomViewModel
            {
                Sliders = new SlidersSectionViewModel
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

                },
                Facilities = new List<FacilitiesSectionViewModel>
            {
                 new FacilitiesSectionViewModel
            {

                FacilityName="Desk lamp"
            },
                  new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FacilityName="TV"
            },
                   new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-shower-50.png",
                FacilityName="WC-shower"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FacilityName="Refrigerator"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FacilityName="Room tel."
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FacilityName="Generator"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Study room"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Sensor taps"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Kitchenette"
            },       new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-restaurant-table-64.png",
                FacilityName="Cafeteria"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-hotel-bed-64.png",
                FacilityName="Bed"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-exercise-64.png",
                FacilityName="Gym"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-microwave-64.png",
                FacilityName="Microwave"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                FacilityName="Internet"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-cooling-64.png",
                FacilityName="Air-condition"
            },


                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            },      new FacilitiesSectionViewModel
            {

                FacilityName="Desk lamp"
            },
                  new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FacilityName="TV"
            },
                   new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-shower-50.png",
                FacilityName="WC-shower"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FacilityName="Refrigerator"
            }, new FacilitiesSectionViewModel{
                FacilityImageUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FacilityName="Room tel."
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FacilityName="Generator"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-restaurant-table-64.png",
                FacilityName="Cafeteria"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-hotel-bed-64.png",
                FacilityName="Bed"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-exercise-64.png",
                FacilityName="Gym"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-microwave-64.png",
                FacilityName="Microwave"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                FacilityName="Internet"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-cooling-64.png",
                FacilityName="Air-condition"
            },
                    new FacilitiesSectionViewModel


            {

                FacilityName="Study room"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Sensor taps"
            },
               new FacilitiesSectionViewModel {
                FacilityImageUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                FacilityName="TV"
            },
                   new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-shower-50.png",
                FacilityName="WC-shower"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-fridge-64.png",
                FacilityName="Refrigerator"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-restaurant-table-64.png",
                FacilityName="Cafeteria"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-hotel-bed-64.png",
                FacilityName="Bed"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Kitchenette"
            },

                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            },      new FacilitiesSectionViewModel
            {

                FacilityName="Desk lamp"
            },
                  new FacilitiesSectionViewModel


            {
                FacilityImageUrl="/dusk/png/facilities/icons8-exercise-64.png",
                FacilityName="Gym"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-microwave-64.png",
                FacilityName="Microwave"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                FacilityName="Internet"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-cooling-64.png",
                FacilityName="Air-condition"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Sensor taps"
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-office-phone-64.png",
                FacilityName="Room tel."
            },
                    new FacilitiesSectionViewModel
            {
                FacilityImageUrl="/dusk/png/facilities/icons8-compressor-64.png",
                FacilityName="Generator"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Study room"
            },
                    new FacilitiesSectionViewModel
            {

                FacilityName="Kitchenette"
            },

                    new FacilitiesSectionViewModel
            {

                FacilityName="Full-wardrope"
            }


            },
                RoomName = "Double room ",
                DormitoryBlock = "A block",
                GenderAllocation = "Separate floors for males and females",
                DormitoryName = "Alfam vista",
                BedType = "Normal Bed",
                NoOfStudents = 4,
                Price = "2.3456,00",
                OldPrice = "2.3456,00",
                NoRoomQuota = 4,
                HasDeposit = true

            };

            return model;
        }
    }

    public class SpecificRoomViewModel
    {
        public SlidersSectionViewModel Sliders { get; set; }
        public List<FacilitiesSectionViewModel> Facilities { get; set; }
        public string RoomName { get; set; }
        public string DormitoryBlock { get; set; }
        public string GenderAllocation { get; set; }
        public string DormitoryName { get; set; }
        public string BedType { get; set; }
        public int NoOfStudents { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public bool HasDeposit { get; set; }
        public int NoRoomQuota { get; set; }
    }
}
