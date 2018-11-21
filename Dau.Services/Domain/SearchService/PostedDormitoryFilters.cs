using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.SearchService
{
    public class PostedDormitoryFilters
    {
        public string name_of_dormitory { get; set; }
        public int dormitory_type { get; set; }

        public double min_price_of_room { get; set; }
        public double max_price_of_room { get; set; }
        public int room_areaMin { get; set; }
        public int room_areaMax { get; set; }
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
