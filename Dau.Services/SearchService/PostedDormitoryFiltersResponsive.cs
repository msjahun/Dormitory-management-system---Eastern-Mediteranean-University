using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.SearchService
{
    public class PostedDormitoryFiltersResponsive
    {
        public string name_of_dormitory { get; set; }
        public int dormitory_type { get; set; }

        public MinMaxStruct price_2000_to_2499 { get; set; }
        public MinMaxStruct price_2500_to_2999 { get; set; }
        public MinMaxStruct price_3000_to_3499 { get; set; }
        public MinMaxStruct price_4000_to_4999 { get; set; }
        public MinMaxStruct price_5000_to_6000 { get; set; }
        public MinMaxStruct price_greater_than_6000 { get; set; }

        public MinMaxStruct room_area_10_to_20 { get; set; }
        public MinMaxStruct room_area_21_to_25 { get; set; }
        public MinMaxStruct room_area_26_to_30 { get; set; }
        public MinMaxStruct room_area_greater_than_30 { get; set; }


        public int langId { get; set; }

        public string facility_TV { get; set; }
        public string facility_Internet { get; set; }
        public string facility_Wc_shower { get; set; }
        public string facility_Kitchenette { get; set; }
        public string facility_bed { get; set; }

        public string facility_air_condition { get; set; }
        public string facility_central_ac { get; set; }
        public string facility_refrigerator { get; set; }
        public string facility_laundry { get; set; }
        public string facility_cafeteria { get; set; }
        public string facility_room_tel { get; set; }
        public string facility_generator { get; set; }
        public string sort_by { get; set; }

    }
}
