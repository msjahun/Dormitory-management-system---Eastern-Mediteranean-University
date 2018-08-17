using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchDormWeb.Models
{
    public class SearchResultData
    {
        public string name_of_dormitory { get; set; }
        public string name_of_room { get; set; }
        public string gender_allocation { get; set; }
        public string room_price_currency { get; set; }
        public double price_of_room { get; set; }
        public int dormitory_type { get; set; }
        public string dormitory_address { get; set; }
        public int room_area { get; set; }
        public int num_rooms_left { get; set; }
        public string url_of_room_image { get; set; }
        public List<Facility> facility { get; set; }
        public string dormitory_account { get; set; }
        public string bank_name { get; set; }
        public List<string> turkish_lira_account_number { get; set; }
        public List<string> usd_account_number { get; set; }
        public string dormitory_website { get; set; }
        public int totalFound { get; set; }
        public string map_latitude { get; set; }
        public string map_longitude { get; set; }
    }
}