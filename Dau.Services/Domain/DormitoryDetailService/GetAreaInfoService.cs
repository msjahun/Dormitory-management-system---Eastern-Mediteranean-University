using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetAreaInfoService : IGetAreaInfoService
    {
        public AreaInfoSectionViewModel GetAreaInfo()
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
            return model;

        }
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
