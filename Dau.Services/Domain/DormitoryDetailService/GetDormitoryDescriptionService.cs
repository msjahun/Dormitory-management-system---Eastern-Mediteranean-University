using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public class GetDormitoryDescriptionService : IGetDormitoryDescriptionService
    {
        public DormitoryDescriptionSectionViewModel GetDormitoryDescription()
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

            return model;

        }
    }

    public class DormitoryDescriptionSectionViewModel
    {
        public string DormitoryDescription { get; set; }
        public string RatingText { get; set; }
        public int NoOfStudents { get; set; }
        public string RatingNo { get; set; }
        public int ReviewNo { get; set; }
        public string Location { get; set; }
        public string Option { get; set; }//staff
        public string OptionValue { get; set; }//staff are very friendly
        public string StandAloneOption { get; set; }//has a gym!
        public string NoOfNewFacilities { get; set; }
        public string NoOfStaff { get; set; }
        public string NoOfAwards { get; set; }

    }

}
