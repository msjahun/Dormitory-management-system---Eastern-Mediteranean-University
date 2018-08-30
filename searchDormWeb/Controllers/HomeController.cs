
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Globalization;
using Dau.Services.SearchService;
using Microsoft.Extensions.Localization;
using Dau.Data;
using Dau.Services.Dormitory;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace searchDormWeb.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private ISearchService _searchService;
        private IDormitoryService _dormitoryService;


        public HomeController(
            IStringLocalizer<HomeController> _localizer, 
            ISearchService _searchService, 
            IDormitoryService _dormitoryService
            )
        {
            this._localizer = _localizer;
            this._searchService = _searchService;
            this._dormitoryService = _dormitoryService;
        }


        // GET: Home
        [DisplayName("HomePage")]
       public ActionResult Index(string Id = "en")
        {


            CultureInfo ci = new CultureInfo(Id);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            ViewBag.ContentFormat_language_id = _localizer["language_id"];
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.ContentFormat_logo_image_url = _localizer["logo_image_url"];
            ViewBag.ContentFormat_lang_trans_link = _localizer["lang_trans_link"];
            ViewBag.ContentFormat_language_next = _localizer["language_next"];
            ViewBag.ContentFormat_language_next_flag_url = _localizer["language_next_flag_url"];
            ViewBag.ContentFormat_menu_accomodation = _localizer["menu_accomodation"];
            ViewBag.ContentFormat_menu_dormitories_and_cafeteria = _localizer["menu_dormitories_and_cafeteria"];

            ViewBag.ContentFormat_btn_clear_filter = _localizer["btn_clear_filter"];
            ViewBag.ContentFormat_btn_apply_filter = _localizer["btn_apply_filter"];
            ViewBag.Contentfilter_header_filter_by = _localizer["filter_header_filter_by"];

            ViewBag.ContentFormat_sort_by = _localizer["sort_by"];
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_sort_by_az = _localizer["sort_by_az"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];


           

            ViewBag.ContentFormat_filter_select_dormitory_name = _localizer["filter_select_dormitory_name"];
            ViewBag.ContentFormat_filter_select_dormitory_type = _localizer["filter_select_dormitory_type"];

           
            ViewBag.ContentFormat_filter_dormitory_type_emu_dormitories = _localizer["filter_dormitory_type_emu_dormitories"];
            ViewBag.ContentFormat_filter_dormitory_type_bot_dormitories = _localizer["filter_dormitory_type_bot_dormitories"];

            ViewBag.ContentFormat_filter_header_price = _localizer["filter_header_price"];
            ViewBag.ContentFormat_filter_header_room_area = _localizer["filter_header_room_area"];

            ViewBag.ContentFormat_filter_head_internet = _localizer["filter_head_internet"];
            ViewBag.ContentFormat_filter_head_tv = _localizer["filter_head_tv"];
            ViewBag.ContentFormat_filter_header_bed = _localizer["filter_header_bed"];
            ViewBag.ContentFormat_filter_header_kitchenette = _localizer["filter_header_kitchenette"];
            ViewBag.ContentFormat_filter_header_nececities = _localizer["filter_header_nececities"];
            ViewBag.ContentFormat_filter_header_wc_shower = _localizer["filter_header_wc_shower"];


            ViewBag.ContentFormat_filter_option_air_condition = _localizer["filter_option_air_condition"];
            ViewBag.ContentFormat_filter_option_bed_bunk = _localizer["filter_option_bed_bunk"];
            ViewBag.ContentFormat_filter_option_bed_normal = _localizer["filter_option_bed_normal"];
            ViewBag.ContentFormat_filter_option_cafeteria = _localizer["filter_option_cafeteria"];
            ViewBag.ContentFormat_filter_option_center_heating_cooling = _localizer["filter_option_center_heating_cooling"];
            ViewBag.ContentFormat_filter_option_generator = _localizer["filter_option_generator"];
            ViewBag.ContentFormat_filter_option_internet_wireless = _localizer["filter_option_internet_wireless"];
            ViewBag.ContentFormat_filter_option_internt_cable = _localizer["filter_option_internt_cable"];
            ViewBag.ContentFormat_filter_option_kitchenette_flats = _localizer["filter_option_kitchenette_flats"];
            ViewBag.ContentFormat_filter_option_kitchenette_room = _localizer["filter_option_kitchenette_room"];
            ViewBag.ContentFormat_filter_option_laundry = _localizer["filter_option_laundry"];
            ViewBag.ContentFormat_filter_option_refrigerator = _localizer["filter_option_refrigerator"];
            ViewBag.ContentFormat_filter_option_room_tel = _localizer["filter_option_room_tel"];
            ViewBag.ContentFormat_filter_option_tv_hall = _localizer["filter_option_tv_hall"];
            ViewBag.ContentFormat_filter_option_tv_room = _localizer["filter_option_tv_room"];
            ViewBag.ContentFormat_filter_option_wc_shower_common = _localizer["filter_option_wc_shower_common"];
            ViewBag.ContentFormat_filter_option_wc_shower_flats = _localizer["filter_option_wc_shower_flats"];
            ViewBag.ContentFormat_filter_option_wc_shower_room = _localizer["filter_option_wc_shower_room"];

            ViewBag.ContentFormat_filter_options_price_responsive_greater_than_6000 = _localizer["filter_options_price_responsive_greater_than_6000"];
            ViewBag.ContentFormat_filter_options_price_responsive_5000_to_6000 = _localizer["filter_options_price_responsive_5000_to_6000"];
            ViewBag.ContentFormat_filter_options_price_responsive_4000_to_4999 = _localizer["filter_options_price_responsive_4000_to_4999"];
            ViewBag.ContentFormat_filter_options_price_responsive_3000_to_3499 = _localizer["filter_options_price_responsive_3000_to_3499"];
            ViewBag.ContentFormat_filter_options_price_responsive_2500_to_2999 = _localizer["filter_options_price_responsive_2500_to_2999"];
            ViewBag.ContentFormat_filter_options_price_responsive_2000_to_2499 = _localizer["filter_options_price_responsive_2000_to_2499"];

            ViewBag.ContentFormat_filter_options_room_area_responsive_10m2_to_20m2 = _localizer["filter_options_room_area_responsive_10m2_to_20m2"];
            ViewBag.ContentFormat_filter_options_room_area_responsive_21m2_to_25m2 = _localizer["filter_options_room_area_responsive_21m2_to_25m2"];
            ViewBag.ContentFormat_filter_options_room_area_responsive_26m2_to_30m2 = _localizer["filter_options_room_area_responsive_26m2_to_30m2"];
            ViewBag.ContentFormat_filter_options_room_area_responsive_greater_than_30m2 = _localizer["filter_options_room_area_responsive_greater_than_30m2"];
            ViewBag.ContentFormat_map_view = _localizer["map_view"];

            ViewBag.ContentFormat_emu_intro_text = _localizer["emu_intro_text"];

            ViewBag.ContentFormat_search_result_text = _localizer["search_result_text"];
            ViewBag.ContentFormat_results_from_map_text = _localizer["results_from_map_text"];

            ViewBag.ContentFormat_language_id = _localizer["language_id"];

            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];


            return View("Index");
        }

        public ActionResult GetView(PostedDormitoryFilters data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            PostedDormitoryFilters filter = new PostedDormitoryFilters();
            
            //  var data=  
            var obj = data;
            filter.name_of_dormitory = obj.name_of_dormitory==null?"": obj.name_of_dormitory;

            filter.dormitory_type = obj.dormitory_type;
            filter.min_price_of_room= obj.min_price_of_room;
            filter.max_price_of_room = obj.max_price_of_room;
            filter.room_areaMin= obj.room_areaMin;
            filter.room_areaMax = obj.room_areaMax;
            filter.langId = obj.langId;

            filter.facility_TV = obj.facility_TV == null ? "" : obj.facility_TV;
            filter.facility_Internet = obj.facility_Internet == null ? "" : obj.facility_Internet;
            filter.facility_Wc_shower= obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            filter.facility_Kitchenette = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            filter.facility_bed = obj.facility_bed == null ? "" : obj.facility_bed;
            filter.sort_by= obj.sort_by == null ? "" : obj.sort_by;
            filter.facility_air_condition = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            filter.facility_central_ac = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            filter.facility_refrigerator = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            filter.facility_laundry = obj.facility_laundry == null ? "" : obj.facility_laundry;
            filter.facility_cafeteria = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            filter.facility_room_tel = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            filter.facility_generator = obj.facility_generator == null ? "" : obj.facility_generator;

            string locale = "en";

            if (filter.langId == 2)
            {
                locale = "tr";
            }
           
            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.LangId = filter.langId;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_sort_by_az = _localizer["sort_by_az"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];



           


            ArrayList sa = new ArrayList();
            
            sa.Add(filter.facility_TV);
            sa.Add(filter.facility_Internet);
            sa.Add(filter.facility_Wc_shower);
            sa.Add(filter.facility_Kitchenette);
            sa.Add(filter.facility_bed);
            sa.Add(filter.facility_air_condition);
            sa.Add(filter.facility_central_ac);
            sa.Add(filter.facility_refrigerator);
            sa.Add(filter.facility_laundry);
            sa.Add(filter.facility_cafeteria);
            sa.Add(filter.facility_room_tel);
            sa.Add(filter.facility_generator);
            
            if (filter.name_of_dormitory == " ")
                filter.name_of_dormitory = "";
            
            var query = _searchService.GetSearchData(filter.langId);

            //filtering
            query = _searchService.Filtering(query, filter, sa);
            

            //sorting
            query = _searchService.SortSeachResult(query, filter.sort_by);

            return PartialView("SearchResultParialView", query);


        }


        public ActionResult GetMapView(PostedDormitoryFilters data)
        {

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            PostedDormitoryFilters filter = new PostedDormitoryFilters();
          
            //  var data=  
            var obj = data;
            filter.name_of_dormitory = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;

            filter.dormitory_type = obj.dormitory_type;
            filter.min_price_of_room  = obj.min_price_of_room;
            filter.max_price_of_room = obj.max_price_of_room;
            filter.room_areaMin= obj.room_areaMin;
            filter.room_areaMax = obj.room_areaMax;
            filter.langId = obj.langId;

            filter.facility_TV = obj.facility_TV == null ? "" : obj.facility_TV;
            filter.facility_Internet = obj.facility_Internet == null ? "" : obj.facility_Internet;
            filter.facility_Wc_shower= obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            filter.facility_Kitchenette = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            filter.facility_bed = obj.facility_bed == null ? "" : obj.facility_bed;
            filter.sort_by= obj.sort_by == null ? "" : obj.sort_by;
            filter.facility_air_condition = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            filter.facility_central_ac = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            filter.facility_refrigerator = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            filter.facility_laundry = obj.facility_laundry == null ? "" : obj.facility_laundry;
            filter.facility_cafeteria = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            filter.facility_room_tel = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            filter.facility_generator = obj.facility_generator == null ? "" : obj.facility_generator;




            string locale = "en";

            if (filter.langId == 2)
            {
                locale = "tr";
            }

            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_loading_facility = _localizer["loading_facility"];
            ViewBag.ContentFormat_loading_Dormitory_name = _localizer["loading_Dormitory_name"];
            ViewBag.ContentFormat_loading_gender_allocation = _localizer["loading_gender_allocation"];
            ViewBag.ContentFormat_loading_room_type = _localizer["loading_room_type"];
            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];
         

            ArrayList sa = new ArrayList();
            
            sa.Add(filter.facility_TV);
            sa.Add(filter.facility_Internet);
            sa.Add(filter.facility_Wc_shower);
            sa.Add(filter.facility_Kitchenette);
            sa.Add(filter.facility_bed);

            sa.Add(filter.facility_air_condition);
            sa.Add(filter.facility_central_ac);
            sa.Add(filter.facility_refrigerator);
            sa.Add(filter.facility_laundry);
            sa.Add(filter.facility_cafeteria);
            sa.Add(filter.facility_room_tel);
            sa.Add(filter.facility_generator);

       
            if (filter.name_of_dormitory == " ")
                filter.name_of_dormitory = "";

            var query = _searchService.GetSearchData(filter.langId);

            //filtering

            query = _searchService.Filtering(query, filter, sa);
            

            //sorting
            query = _searchService.SortSeachResult(query, filter.sort_by);

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));


            return PartialView("MapSearchResult_partialView", query);


        }


        public ActionResult GetMainSearchLoader(PostedDormitoryTypeLang data)
        {
            var obj = data;
            string locale = "en";

            if (obj.langId == 2)
            {
                locale = "tr";
            }

            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.ContentFormat_loading_facility = _localizer["loading_facility"];
            ViewBag.ContentFormat_loading_Dormitory_name = _localizer["loading_Dormitory_name"];
            return PartialView("LoadingSearchMainView");
        }

        public ActionResult GetMapAreaLoader()
        {
            return PartialView("MapAreaLoaderView");
        }

        public ActionResult GetMiniSearchMapLoader(PostedDormitoryTypeLang data)
        {
            var obj = data;
            string locale = "en";

            if (obj.langId == 2)
            {
                locale = "tr";
            }

            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_loading_facility = _localizer["loading_facility"];
            ViewBag.ContentFormat_loading_Dormitory_name = _localizer["loading_Dormitory_name"];
            ViewBag.ContentFormat_loading_gender_allocation = _localizer["loading_gender_allocation"];
            ViewBag.ContentFormat_loading_room_type = _localizer["loading_room_type"];
            return PartialView("LoaderMiniSearchMap");
        }





        public ActionResult GetSearchResultResponsive(PostedDormitoryFiltersResponsive data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            PostedDormitoryFiltersResponsive filter = new PostedDormitoryFiltersResponsive();
          
            //  var data=  
            var obj = data;
            filter = obj;

            filter.name_of_dormitory = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;
            filter.facility_TV = obj.facility_TV == null ? "" : obj.facility_TV;
            filter.facility_Internet = obj.facility_Internet == null ? "" : obj.facility_Internet;
            filter.facility_Wc_shower= obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            filter.facility_Kitchenette = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            filter.facility_bed = obj.facility_bed == null ? "" : obj.facility_bed;
            filter.sort_by= obj.sort_by == null ? "" : obj.sort_by;
            filter.facility_air_condition = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            filter.facility_central_ac = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            filter.facility_refrigerator = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            filter.facility_laundry = obj.facility_laundry == null ? "" : obj.facility_laundry;
            filter.facility_cafeteria = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            filter.facility_room_tel = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            filter.facility_generator = obj.facility_generator == null ? "" : obj.facility_generator;


            string locale = "en";

            if (filter.langId == 2)
            {
                locale = "tr";
            }

            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.LangId = filter.langId;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_sort_by_az = _localizer["sort_by_az"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];
            


           
            ArrayList sa = new ArrayList();
           

            sa.Add(filter.facility_TV);
            sa.Add(filter.facility_Internet);
            sa.Add(filter.facility_Wc_shower);
            sa.Add(filter.facility_Kitchenette);
            sa.Add(filter.facility_bed);

            sa.Add(filter.facility_air_condition);
            sa.Add(filter.facility_central_ac);
            sa.Add(filter.facility_refrigerator);
            sa.Add(filter.facility_laundry);
            sa.Add(filter.facility_cafeteria);
            sa.Add(filter.facility_room_tel);
            sa.Add(filter.facility_generator);

           

            if (filter.name_of_dormitory == " ")
                filter.name_of_dormitory = "";

            var query = _searchService.GetSearchData(filter.langId);

            //filtering
            query = _searchService.Filtering(query, filter, sa);


            //sorting
            query = _searchService.SortSeachResult(query, filter.sort_by);

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));
            return PartialView("SearchResultParialView", query);


        }
        
        public ActionResult GetSearchResultMapViewResponsive(PostedDormitoryFiltersResponsive data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            PostedDormitoryFiltersResponsive filter = new PostedDormitoryFiltersResponsive();
            
            //  var data=  
            var obj = data;
            filter = obj;
            filter.name_of_dormitory = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;
            filter.facility_TV = obj.facility_TV == null ? "" : obj.facility_TV;
            filter.facility_Internet = obj.facility_Internet == null ? "" : obj.facility_Internet;
            filter.facility_Wc_shower= obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            filter.facility_Kitchenette = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            filter.facility_bed = obj.facility_bed == null ? "" : obj.facility_bed;
            filter.sort_by= obj.sort_by == null ? "" : obj.sort_by;
            filter.facility_air_condition = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            filter.facility_central_ac = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            filter.facility_refrigerator = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            filter.facility_laundry = obj.facility_laundry == null ? "" : obj.facility_laundry;
            filter.facility_cafeteria = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            filter.facility_room_tel = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            filter.facility_generator = obj.facility_generator == null ? "" : obj.facility_generator;




            ArrayList sa = new ArrayList();
            sa.Add(filter.facility_TV);
            sa.Add(filter.facility_Internet);
            sa.Add(filter.facility_Wc_shower);
            sa.Add(filter.facility_Kitchenette);
            sa.Add(filter.facility_bed);
            sa.Add(filter.facility_air_condition);
            sa.Add(filter.facility_central_ac);
            sa.Add(filter.facility_refrigerator);
            sa.Add(filter.facility_laundry);
            sa.Add(filter.facility_cafeteria);
            sa.Add(filter.facility_room_tel);
            sa.Add(filter.facility_generator);

           

            if (filter.name_of_dormitory == " ")
                filter.name_of_dormitory = "";

            var query = _searchService.GetSearchData(filter.langId);


            //filtering
            query = _searchService.Filtering(query, filter, sa);

            //sorting
            query = _searchService.SortSeachResult(query, filter.sort_by);
            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));
            return PartialView("MapSearchResult_partialView", query);


        }

        public ActionResult GetDormitoriesBasedOnType(PostedDormitoryTypeLang data)
        {
            PostedDormitoryTypeLang filter = new PostedDormitoryTypeLang();
            filter = data;
            List<string> listDormitories = new List<string>();
            listDormitories = _dormitoryService.GetListAllDormitoriesByLangAndType(filter.dormitory_type, filter.langId);
            return PartialView("OptionsDropdownView", listDormitories);
        }


    }
}