
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;
using System.Collections;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Dau.Core.Domain.BankAccount;
using Dau.Core.Domain.Dormitory;
using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Room;
using Dau.Core.Domain.Language;

using Microsoft.Extensions.Localization;

using searchDormWeb.Models;


namespace searchDormWeb.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }


        // GET: Home
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

        public ActionResult GetView(PostData2 data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            String name_of_dormitoryPosted = " ";
            int dormitory_typePosted = 1;
            double min_price_of_roomPosted = 0;
            double max_price_of_roomPosted = 10000;
            int room_areaPostedMin = 0;
            int room_areaPostedMax = 10000;
            int langIDPosted = 0;

            String facility_TVPosted = " ";
            String facility_InternetPosted = " ";
            String facility_Wc_showerPosted = " ";
            String facility_KitchenettePosted = " ";
            String facility_bedPosted = " ";
          
            String facility_air_conditionPosted = " ";
            String facility_central_acPosted = " ";
            String facility_refrigeratorPosted = " ";
            String facility_laundryPosted = " ";
            String facility_cafeteriaPosted = " ";
            String facility_room_telPosted = " ";
            String facility_generatorPosted = " ";
            String sort_byPosted = " ";

            //  var data=  
            var obj = data;
            name_of_dormitoryPosted = obj.name_of_dormitory==null?"": obj.name_of_dormitory;

            dormitory_typePosted = obj.dormitory_type;
            min_price_of_roomPosted = obj.min_price_of_room;
            max_price_of_roomPosted = obj.max_price_of_room;
            room_areaPostedMin = obj.room_areaMin;
            room_areaPostedMax = obj.room_areaMax;
            langIDPosted = obj.langId;

            facility_TVPosted = obj.facility_TV == null ? "" : obj.facility_TV;
            facility_InternetPosted = obj.facility_Internet == null ? "" : obj.facility_Internet;
            facility_Wc_showerPosted = obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            facility_KitchenettePosted = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            facility_bedPosted = obj.facility_bed == null ? "" : obj.facility_bed;
            sort_byPosted = obj.sort_by == null ? "" : obj.sort_by;
            facility_air_conditionPosted = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            facility_central_acPosted = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            facility_refrigeratorPosted = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            facility_laundryPosted = obj.facility_laundry == null ? "" : obj.facility_laundry;
            facility_cafeteriaPosted = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            facility_room_telPosted = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            facility_generatorPosted = obj.facility_generator == null ? "" : obj.facility_generator;

            string locale = "en";

            if (langIDPosted == 2)
            {
                locale = "tr";
            }
           
            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.LangId = langIDPosted;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_sort_by_az = _localizer["sort_by_az"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];
            //name_of_dormitoryPosted = "";
            //dormitory_typePosted = 0;
            //min_price_of_roomPosted = 0;
            //max_price_of_roomPosted = 4992;
            //room_areaPostedMin = 100000;
            //room_areaPostedMax = 0;
            //langIDPosted = 1;

            //facility_TVPosted = "";
            //facility_InternetPosted = "";
            //facility_Wc_showerPosted = "";
            //facility_KitchenettePosted = "";
            //facility_bedPosted = "";
            //sort_byPosted = "";
            //facility_air_conditionPosted = "";
            //facility_central_acPosted = "";
            //facility_refrigeratorPosted = "";
            //facility_laundryPosted = "";
            //facility_cafeteriaPosted = "";
            //facility_room_telPosted = "";
            //facility_generatorPosted = "";


            List<SearchResultData> arr = new List<SearchResultData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci = new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();


            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();




                usd_acct_num = new List<string>();
                usd_acct_num.Add("Account No: 6820-57259db");
                usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(dorm_trans =>
                    {




                        context.RoomTable.Where(r => r.DormitoryId == dorm.Id).Include(r => r.RoomTableTranslation).Include(r => r.RoomFacility).ToList().ForEach(room_t =>
                        {


                            room_t.RoomTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(room_trans =>
                            {
                                tr_acct_num = new List<string>();
                                ///  tr_acct_num.Add("Account No: 6820-174392db");
                                //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");
                                usd_acct_num = new List<string>();
                                string usdd = "";
                                string trr = "";
                                //usd_acct_num.Add("Account No: 6820-57259db");
                                //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                                context.DormitoryBankAccountTable.Include(r => r.BankCurrencyTable).Where(c => c.DormitoryId == room_t.DormitoryId && room_trans.RoomTableNonTransId == room_t.Id).ToList().ForEach(dorm_bank_acc =>
                                {
                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "USD").ToList().ForEach(bk_curr =>
                                    {
                                        usdd += dorm_bank_acc.BankName + "  ";
                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        usdd += "  " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        usd_acct_num.Add(usdd);
                                        usdd = "";

                                    });



                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "TL").ToList().ForEach(bk_curr =>
                                    {
                                        trr += dorm_bank_acc.BankName + "  ";

                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        trr += "  " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        tr_acct_num.Add(trr);
                                        trr = "";

                                    });
                                });

                                faci = new List<Facility>();
                                //I smell desaster from this part
                                context.RoomFacility.Where(r => r.RoomId == room_t.Id).Include(r => r.Facility).ToList().ForEach(room_faci =>
                                {
                                    context.FacilityTable.Where(r => r.Id == room_faci.FacilityId).Include(r => r.FacilityTableTranslation).ToList().ForEach(facii =>
                                    {
                                        facii.FacilityTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(faci_trans =>
                                        {
                                            string facility_o = "";
                                            context.FacilityOption.Where(r => r.FacilityId == room_faci.FacilityId && facii.Id == room_faci.FacilityId)
                                                        .Include(r => r.FacilityOptionTranslation).ToList().ForEach(faci_op =>
                                                        {
                                                            faci_op.FacilityOptionTranslation
                                                                        .Where(r => r.LanguageId == langIDPosted && r.FacilityOptionNonTransId == room_faci.FacilityOptionId)

                                                                    .ToList().ForEach(faci_op_trans =>
                                                                    {
                                                                        facility_o += " | " + faci_op_trans.FacilityOption;

                                                                    });

                                                        });

                                            faci.Add(new Facility { facility_name = faci_trans.FacilityTitle + facility_o, facility_icon_url = facii.FacilityIconUrl});




                                        });
                                    });


                                });






                                //faci.Add(new Facility { facility_name = "Room Area: " + room_t.room_area + " m" + "<sup style=\"font-size: smaller; \">2</sup>", facility_icon_url = "../../Content/Dormitories_files/room_area.jpg" });
                                //faci.Add(new Facility { facility_name = "<b style=\"color:#0ab21b\">Price: " + dorm.room_price_currency + " " + room_t.room_price + "</b>", facility_icon_url = "../../Content/Dormitories_files/price.png" });




                                //if (langIDPosted == 1)


                                //    if (room_t.num_rooms_left > 1)
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  rooms left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //    }
                                //    else
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  room left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });

                                //    }

                                //else

                                //       if (room_t.num_rooms_left > 1)
                                //{


                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + "  Oda  kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}
                                //else
                                //{
                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + " oda kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}


                                arr.Add(new SearchResultData
                                {
                                    name_of_dormitory = dorm_trans.DormitoryName,
                                    dormitory_address = dorm_trans.DormitoryAddress,
                                    name_of_room = room_trans.RoomTitle,
                                    gender_allocation = dorm_trans.GenderAllocation,
                                    room_price_currency = dorm.RoomPriceCurrency,
                                    map_latitude = dorm.MapLatitude,
                                    map_longitude = dorm.MapLongitude,
                                    url_of_room_image = room_t.RoomPictureUrl,
                                    facility = faci,
                                    dormitory_type = dorm.DormitoryTypeId,
                                    price_of_room = room_t.RoomPrice,
                                    room_area = room_t.RoomArea,
                                    num_rooms_left = room_t.NumRoomsLeft,
                                    dormitory_account = dorm_trans.DormitoryName,
                                    bank_name = "bank name",
                                    turkish_lira_account_number = tr_acct_num,
                                    usd_account_number = usd_acct_num,
                                    dormitory_website = dorm_trans.DormitoryAddress
                                });
                            });

                        });




                    });
                });










            }
            //tr_acct_num = new List<string>();
            //tr_acct_num.Add("Account No: 6820-174392db");
            //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");

            //usd_acct_num = new List<string>();
            //usd_acct_num.Add("Account No: 6820-57259db");
            //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

            //faci = new List<Facility>();
            //faci.Add(new Facility { facility_name = "buckets", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(5).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });

            //arr.Add(new PostData
            //{
            //    name_of_dormitory = "Sample dormitory",
            //    name_of_room = "Sample room",
            //    url_of_room_image = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TEK%20K%C4%B0%C5%9E%C4%B0L%C4%B0K%20EXCLUS%C4%B0VE.jpg?RenditionID=7",
            //    facility = faci,
            //    room_area = 25,
            //    dormitory_type = 1,
            //    dormitory_account = "dormitory_account",
            //    bank_name = "bank name",
            //    price_of_room = 2700,
            //    turkish_lira_account_number = tr_acct_num,
            //    usd_account_number = usd_acct_num,
            //    dormitory_website = "dormitory website"
            //});

            //var faci_query = from Facility f in arr
            //                 where (f.facility_name.Contains("TV"))
            //                 select f;
            //var query = from PostData s in arr
            //            where (s.facility.
            //            select s;

            //var query = from s in arr
            //            where s.Facility.Any(c => c.facility_name.contains("TV"))
            //            select s;

            //  PostData query = arr.fin
            ArrayList sa = new ArrayList();
            //sa.Add("Kitchenette | Flats");
            //sa.Add("TV | In room");
            //sa.Add("Central conditioning system | Cooling");

            sa.Add(facility_TVPosted);
            sa.Add(facility_InternetPosted);
            sa.Add(facility_Wc_showerPosted);
            sa.Add(facility_KitchenettePosted);
            sa.Add(facility_bedPosted);

            sa.Add(facility_air_conditionPosted);
            sa.Add(facility_central_acPosted);
            sa.Add(facility_refrigeratorPosted);
            sa.Add(facility_laundryPosted);
            sa.Add(facility_cafeteriaPosted);
            sa.Add(facility_room_telPosted);
            sa.Add(facility_generatorPosted);

            //string name_of_dormitoryPosted = " ";

            if (name_of_dormitoryPosted == " ")
                name_of_dormitoryPosted = "";

            if (name_of_dormitoryPosted == null)
                name_of_dormitoryPosted = "";
            

            var query = arr;


            if (dormitory_typePosted == 0)
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&

                    item.room_area >= room_areaPostedMin && item.room_area <= room_areaPostedMax &&
                      item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted
                      &&
                     item.facility.Any(fac => fac.facility_name.Contains(q.ToString()))
                      )
                   .ToList();
            }
            else
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                      item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                      item.dormitory_type == dormitory_typePosted &&
                      item.room_area >= room_areaPostedMin && item.room_area <= room_areaPostedMax &&
                      item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }




            if (sort_byPosted == "Price")
                query = query.OrderBy(s => s.price_of_room).ToList();
            else if (sort_byPosted == "a-z")
                query = query.OrderBy(s => s.name_of_dormitory).ToList();
            else if (sort_byPosted == "area")
                query = query.OrderBy(s => s.room_area).ToList();

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));
            return PartialView("SearchResultParialView", query);


        }


        public ActionResult GetMapView(PostData2 data)
        {

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            string name_of_dormitoryPosted = " ";
            int dormitory_typePosted = 1;
            double min_price_of_roomPosted = 0;
            double max_price_of_roomPosted = 10000;
            int room_areaPostedMin = 0;
            int room_areaPostedMax = 10000;
            int langIDPosted = 0;

            string facility_TVPosted = " ";
            string facility_InternetPosted = " ";
            string facility_Wc_showerPosted = " ";
            string facility_KitchenettePosted = " ";
            string facility_bedPosted = " ";

            string facility_air_conditionPosted = " ";
            string facility_central_acPosted = " ";
            string facility_refrigeratorPosted = " ";
            string facility_laundryPosted = " ";
            string facility_cafeteriaPosted = " ";
            string facility_room_telPosted = " ";
            string facility_generatorPosted = " ";
            string sort_byPosted = " ";

            //  var data=  
            var obj = data;
            name_of_dormitoryPosted = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;

            dormitory_typePosted = obj.dormitory_type;
            min_price_of_roomPosted = obj.min_price_of_room;
            max_price_of_roomPosted = obj.max_price_of_room;
            room_areaPostedMin = obj.room_areaMin;
            room_areaPostedMax = obj.room_areaMax;
            langIDPosted = obj.langId;

            facility_TVPosted = obj.facility_TV == null ? "" : obj.facility_TV;
            facility_InternetPosted = obj.facility_Internet == null ? "" : obj.facility_Internet;
            facility_Wc_showerPosted = obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            facility_KitchenettePosted = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            facility_bedPosted = obj.facility_bed == null ? "" : obj.facility_bed;
            sort_byPosted = obj.sort_by == null ? "" : obj.sort_by;
            facility_air_conditionPosted = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            facility_central_acPosted = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            facility_refrigeratorPosted = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            facility_laundryPosted = obj.facility_laundry == null ? "" : obj.facility_laundry;
            facility_cafeteriaPosted = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            facility_room_telPosted = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            facility_generatorPosted = obj.facility_generator == null ? "" : obj.facility_generator;




            string locale = "en";

            if (langIDPosted == 2)
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
            //name_of_dormitoryPosted = "";
            //dormitory_typePosted = 0;
            //min_price_of_roomPosted = 0;
            //max_price_of_roomPosted = 4992;
            //room_areaPostedMin = 100000;
            //room_areaPostedMax = 0;
            //langIDPosted = 1;

            //facility_TVPosted = "";
            //facility_InternetPosted = "";
            //facility_Wc_showerPosted = "";
            //facility_KitchenettePosted = "";
            //facility_bedPosted = "";
            //sort_byPosted = "";
            //facility_air_conditionPosted = "";
            //facility_central_acPosted = "";
            //facility_refrigeratorPosted = "";
            //facility_laundryPosted = "";
            //facility_cafeteriaPosted = "";
            //facility_room_telPosted = "";
            //facility_generatorPosted = "";


            List<SearchResultData> arr = new List<SearchResultData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci = new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();


            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();




                usd_acct_num = new List<string>();
                usd_acct_num.Add("Account No: 6820-57259db");
                usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(dorm_trans =>
                    {




                        context.RoomTable.Where(r => r.DormitoryId == dorm.Id).Include(r => r.RoomTableTranslation).Include(r => r.RoomFacility).ToList().ForEach(room_t =>
                        {


                            room_t.RoomTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(room_trans =>
                            {
                                tr_acct_num = new List<string>();
                                ///  tr_acct_num.Add("Account No: 6820-174392db");
                                //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");
                                usd_acct_num = new List<string>();
                                string usdd = "";
                                string trr = "";
                                //usd_acct_num.Add("Account No: 6820-57259db");
                                //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                                context.DormitoryBankAccountTable.Include(r => r.BankCurrencyTable).Where(c => c.DormitoryId == room_t.DormitoryId && room_trans.RoomTableNonTransId == room_t.Id).ToList().ForEach(dorm_bank_acc =>
                                {
                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "USD").ToList().ForEach(bk_curr =>
                                    {
                                        usdd += dorm_bank_acc.BankName;
                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        usdd += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        usd_acct_num.Add(usdd);
                                        usdd = "";

                                    });



                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "TL").ToList().ForEach(bk_curr =>
                                    {
                                        trr += dorm_bank_acc.BankName;

                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        trr += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        tr_acct_num.Add(trr);
                                        trr = "";

                                    });
                                });

                                faci = new List<Facility>();
                                //I smell desaster from this part
                                context.RoomFacility.Where(r => r.RoomId == room_t.Id).Include(r => r.Facility).ToList().ForEach(room_faci =>
                                {
                                    context.FacilityTable.Where(r => r.Id == room_faci.FacilityId).Include(r => r.FacilityTableTranslation).ToList().ForEach(facii =>
                                    {
                                        facii.FacilityTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(faci_trans =>
                                        {
                                            string facility_o = "";
                                            context.FacilityOption.Where(r => r.FacilityId == room_faci.FacilityId && facii.Id == room_faci.FacilityId)
                                                        .Include(r => r.FacilityOptionTranslation).ToList().ForEach(faci_op =>
                                                        {
                                                            faci_op.FacilityOptionTranslation
                                                                        .Where(r => r.LanguageId == langIDPosted && r.FacilityOptionNonTransId == room_faci.FacilityOptionId)

                                                                    .ToList().ForEach(faci_op_trans =>
                                                                    {
                                                                        facility_o += " | " + faci_op_trans.FacilityOption;

                                                                    });

                                                        });

                                            faci.Add(new Facility { facility_name = faci_trans.FacilityTitle + facility_o, facility_icon_url = facii.FacilityIconUrl });




                                        });
                                    });


                                });






                                //faci.Add(new Facility { facility_name = "Room Area: " + room_t.room_area + " m" + "<sup style=\"font-size: smaller; \">2</sup>", facility_icon_url = "../../Content/Dormitories_files/room_area.jpg" });
                                //faci.Add(new Facility { facility_name = "<b style=\"color:#0ab21b\">Price: " + dorm.room_price_currency + " " + room_t.room_price + "</b>", facility_icon_url = "../../Content/Dormitories_files/price.png" });




                                //if (langIDPosted == 1)


                                //    if (room_t.num_rooms_left > 1)
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  rooms left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //    }
                                //    else
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  room left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });

                                //    }

                                //else

                                //       if (room_t.num_rooms_left > 1)
                                //{


                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + "  Oda  kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}
                                //else
                                //{
                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + " oda kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}


                                arr.Add(new SearchResultData
                                {
                                    name_of_dormitory = dorm_trans.DormitoryName,
                                    dormitory_address = dorm_trans.DormitoryAddress,
                                    name_of_room = room_trans.RoomTitle,
                                    gender_allocation = dorm_trans.GenderAllocation,
                                    room_price_currency = dorm.RoomPriceCurrency,
                                    map_latitude = dorm.MapLatitude,
                                    map_longitude = dorm.MapLongitude,
                                    url_of_room_image = room_t.RoomPictureUrl,
                                    facility = faci,
                                    dormitory_type = dorm.DormitoryTypeId,
                                    price_of_room = room_t.RoomPrice,
                                    room_area = room_t.RoomArea,
                                    num_rooms_left = room_t.NumRoomsLeft,
                                    dormitory_account = dorm_trans.DormitoryName,
                                    bank_name = "bank name",
                                    turkish_lira_account_number = tr_acct_num,
                                    usd_account_number = usd_acct_num,
                                    dormitory_website = dorm_trans.DormitoryAddress
                                });
                            });

                        });




                    });
                });










            }
            //tr_acct_num = new List<string>();
            //tr_acct_num.Add("Account No: 6820-174392db");
            //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");

            //usd_acct_num = new List<string>();
            //usd_acct_num.Add("Account No: 6820-57259db");
            //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

            //faci = new List<Facility>();
            //faci.Add(new Facility { facility_name = "buckets", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(5).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });

            //arr.Add(new PostData
            //{
            //    name_of_dormitory = "Sample dormitory",
            //    name_of_room = "Sample room",
            //    url_of_room_image = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TEK%20K%C4%B0%C5%9E%C4%B0L%C4%B0K%20EXCLUS%C4%B0VE.jpg?RenditionID=7",
            //    facility = faci,
            //    room_area = 25,
            //    dormitory_type = 1,
            //    dormitory_account = "dormitory_account",
            //    bank_name = "bank name",
            //    price_of_room = 2700,
            //    turkish_lira_account_number = tr_acct_num,
            //    usd_account_number = usd_acct_num,
            //    dormitory_website = "dormitory website"
            //});

            //var faci_query = from Facility f in arr
            //                 where (f.facility_name.Contains("TV"))
            //                 select f;
            //var query = from PostData s in arr
            //            where (s.facility.
            //            select s;

            //var query = from s in arr
            //            where s.Facility.Any(c => c.facility_name.contains("TV"))
            //            select s;

            //  PostData query = arr.fin
            ArrayList sa = new ArrayList();
            //sa.Add("Kitchenette | Flats");
            //sa.Add("TV | In room");
            //sa.Add("Central conditioning system | Cooling");

            sa.Add(facility_TVPosted);
            sa.Add(facility_InternetPosted);
            sa.Add(facility_Wc_showerPosted);
            sa.Add(facility_KitchenettePosted);
            sa.Add(facility_bedPosted);

            sa.Add(facility_air_conditionPosted);
            sa.Add(facility_central_acPosted);
            sa.Add(facility_refrigeratorPosted);
            sa.Add(facility_laundryPosted);
            sa.Add(facility_cafeteriaPosted);
            sa.Add(facility_room_telPosted);
            sa.Add(facility_generatorPosted);

            //string name_of_dormitoryPosted = " ";

            if (name_of_dormitoryPosted == " ")
                name_of_dormitoryPosted = "";

            var query = arr;


            if (dormitory_typePosted == 0)
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&

                    item.room_area >= room_areaPostedMin && item.room_area <= room_areaPostedMax &&
                      item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted
                      &&
                     item.facility.Any(fac => fac.facility_name.Contains(q.ToString()))
                      )
                   .ToList();
            }
            else
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                      item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                      item.dormitory_type == dormitory_typePosted &&
                      item.room_area >= room_areaPostedMin && item.room_area <= room_areaPostedMax &&
                      item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }




            if (sort_byPosted == "Price")
                query = query.OrderBy(s => s.price_of_room).ToList();
            else if (sort_byPosted == "a-z")
                query = query.OrderBy(s => s.name_of_dormitory).ToList();
            else if (sort_byPosted == "area")
                query = query.OrderBy(s => s.room_area).ToList();

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));


            return PartialView("MapSearchResult_partialView", query);


        }


        public ActionResult GetMainSearchLoader(dormitory_struct data)
        {
            var obj = data;
            var langIDPosted = obj.langId;
            string locale = "en";

            if (langIDPosted == 2)
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

        public ActionResult GetMiniSearchMapLoader(dormitory_struct data)
        {
            var obj = data;
            var langIDPosted = obj.langId;
            string locale = "en";

            if (langIDPosted == 2)
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





        public ActionResult GetSearchResultResponsive(PostDataResponsive data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            string name_of_dormitoryPosted = " ";
            int dormitory_typePosted = 1;


            int price_2000_to_2499Posted_min = 0;
            int price_2000_to_2499Posted_max = 0;

            int price_2500_to_2999Posted_min = 0;
            int price_2500_to_2999Posted_max = 0;

            int price_3000_to_3499Posted_min = 0;
            int price_3000_to_3499Posted_max = 0;

            int price_4000_to_4999Posted_min = 0;
            int price_4000_to_4999Posted_max = 0;

            int price_5000_to_6000Posted_min = 0;
            int price_5000_to_6000Posted_max = 0;

            int price_greater_thanPosted_min = 0;
            int price_greater_thanPosted_max = 0;

            int room_area_10_to_20Posted_min = 0;
            int room_area_10_to_20Posted_max = 0;

            int room_area_21_to_25Posted_min = 0;
            int room_area_21_to_25Posted_max = 0;

            int room_area_26_to_30Posted_min = 0;
            int room_area_26_to_30Posted_max = 0;

            int room_area_greater_than_30Posted_min = 0;
            int room_area_greater_than_30Posted_max = 0;



            int langIDPosted = 0;

            string facility_TVPosted = " ";
            string facility_InternetPosted = " ";
            string facility_Wc_showerPosted = " ";
            string facility_KitchenettePosted = " ";
            string facility_bedPosted = " ";

            string facility_air_conditionPosted = " ";
            string facility_central_acPosted = " ";
            string facility_refrigeratorPosted = " ";
            string facility_laundryPosted = " ";
            string facility_cafeteriaPosted = " ";
            string facility_room_telPosted = " ";
            string facility_generatorPosted = " ";
            string sort_byPosted = " ";

            //  var data=  
            var obj = data;
           
    name_of_dormitoryPosted = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;
            dormitory_typePosted = obj.dormitory_type;


            price_2000_to_2499Posted_min = obj.price_2000_to_2499.min;
            price_2000_to_2499Posted_max = obj.price_2000_to_2499.max;

            price_2500_to_2999Posted_min = obj.price_2500_to_2999.min;
            price_2500_to_2999Posted_max = obj.price_2500_to_2999.max;

            price_3000_to_3499Posted_min = obj.price_3000_to_3499.min;
            price_3000_to_3499Posted_max = obj.price_3000_to_3499.max;

            price_4000_to_4999Posted_min = obj.price_4000_to_4999.min;
            price_4000_to_4999Posted_max = obj.price_4000_to_4999.max;

            price_5000_to_6000Posted_min = obj.price_5000_to_6000.min;
            price_5000_to_6000Posted_max = obj.price_5000_to_6000.max;

            price_greater_thanPosted_min = obj.price_greater_than_6000.min;
            price_greater_thanPosted_max = obj.price_greater_than_6000.max;

            room_area_10_to_20Posted_min = obj.room_area_10_to_20.min;
            room_area_10_to_20Posted_max = obj.room_area_10_to_20.max;

            room_area_21_to_25Posted_min = obj.room_area_21_to_25.min;
            room_area_21_to_25Posted_max = obj.room_area_21_to_25.max;

            room_area_26_to_30Posted_min = obj.room_area_26_to_30.min;
            room_area_26_to_30Posted_max = obj.room_area_26_to_30.max;

            room_area_greater_than_30Posted_min = obj.room_area_greater_than_30.min;
            room_area_greater_than_30Posted_max = obj.room_area_greater_than_30.max;



            langIDPosted = obj.langId;

        

           
         
        

            facility_TVPosted = obj.facility_TV == null ? "" : obj.facility_TV;
            facility_InternetPosted = obj.facility_Internet == null ? "" : obj.facility_Internet;
            facility_Wc_showerPosted = obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            facility_KitchenettePosted = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            facility_bedPosted = obj.facility_bed == null ? "" : obj.facility_bed;
            sort_byPosted = obj.sort_by == null ? "" : obj.sort_by;
            facility_air_conditionPosted = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            facility_central_acPosted = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            facility_refrigeratorPosted = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            facility_laundryPosted = obj.facility_laundry == null ? "" : obj.facility_laundry;
            facility_cafeteriaPosted = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            facility_room_telPosted = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            facility_generatorPosted = obj.facility_generator == null ? "" : obj.facility_generator;


            string locale = "en";

            if (langIDPosted == 2)
            {
                locale = "tr";
            }

            CultureInfo ci = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            ViewBag.ContentFormat_account_number_text = _localizer["account_number_text"];
            ViewBag.LangId = langIDPosted;
            ViewBag.ContentFormat_sort_by_price = _localizer["sort_by_price"];
            ViewBag.ContentFormat_sort_by_az = _localizer["sort_by_az"];
            ViewBag.ContentFormat_sort_by_area = _localizer["sort_by_area"];
            ViewBag.ContentFormat_rooms_found = _localizer["rooms_found"];
            //name_of_dormitoryPosted = "";
            //dormitory_typePosted = 0;
            //min_price_of_roomPosted = 0;
            //max_price_of_roomPosted = 4992;
            //room_areaPostedMin = 100000;
            //room_areaPostedMax = 0;
            //langIDPosted = 1;

            //facility_TVPosted = "";
            //facility_InternetPosted = "";
            //facility_Wc_showerPosted = "";
            //facility_KitchenettePosted = "";
            //facility_bedPosted = "";
            //sort_byPosted = "";
            //facility_air_conditionPosted = "";
            //facility_central_acPosted = "";
            //facility_refrigeratorPosted = "";
            //facility_laundryPosted = "";
            //facility_cafeteriaPosted = "";
            //facility_room_telPosted = "";
            //facility_generatorPosted = "";


            List<SearchResultData> arr = new List<SearchResultData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci = new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();


            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();




                usd_acct_num = new List<string>();
                usd_acct_num.Add("Account No: 6820-57259db");
                usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(dorm_trans =>
                    {




                        context.RoomTable.Where(r => r.DormitoryId == dorm.Id).Include(r => r.RoomTableTranslation).Include(r => r.RoomFacility).ToList().ForEach(room_t =>
                        {


                            room_t.RoomTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(room_trans =>
                            {
                                tr_acct_num = new List<string>();
                                ///  tr_acct_num.Add("Account No: 6820-174392db");
                                //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");
                                usd_acct_num = new List<string>();
                                string usdd = "";
                                string trr = "";
                                //usd_acct_num.Add("Account No: 6820-57259db");
                                //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                                context.DormitoryBankAccountTable.Include(r => r.BankCurrencyTable).Where(c => c.DormitoryId == room_t.DormitoryId && room_trans.RoomTableNonTransId == room_t.Id).ToList().ForEach(dorm_bank_acc =>
                                {
                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "USD").ToList().ForEach(bk_curr =>
                                    {
                                        usdd += dorm_bank_acc.BankName;
                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        usdd += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        usd_acct_num.Add(usdd);
                                        usdd = "";

                                    });



                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName== "TL").ToList().ForEach(bk_curr =>
                                    {
                                        trr += dorm_bank_acc.BankName;

                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        trr += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        tr_acct_num.Add(trr);
                                        trr = "";

                                    });
                                });

                                faci = new List<Facility>();
                                //I smell desaster from this part
                                context.RoomFacility.Where(r => r.RoomId == room_t.Id).Include(r => r.Facility).ToList().ForEach(room_faci =>
                                {
                                    context.FacilityTable.Where(r => r.Id == room_faci.FacilityId).Include(r => r.FacilityTableTranslation).ToList().ForEach(facii =>
                                    {
                                        facii.FacilityTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(faci_trans =>
                                        {
                                            string facility_o = "";
                                            context.FacilityOption.Where(r => r.FacilityId == room_faci.FacilityId && facii.Id == room_faci.FacilityId)
                                                        .Include(r => r.FacilityOptionTranslation).ToList().ForEach(faci_op =>
                                                        {
                                                            faci_op.FacilityOptionTranslation
                                                                        .Where(r => r.LanguageId == langIDPosted && r.FacilityOptionNonTransId == room_faci.FacilityOptionId)

                                                                    .ToList().ForEach(faci_op_trans =>
                                                                    {
                                                                        facility_o += " | " + faci_op_trans.FacilityOption;

                                                                    });

                                                        });

                                            faci.Add(new Facility { facility_name = faci_trans.FacilityTitle + facility_o, facility_icon_url = facii.FacilityIconUrl });




                                        });
                                    });


                                });






                                //faci.Add(new Facility { facility_name = "Room Area: " + room_t.room_area + " m" + "<sup style=\"font-size: smaller; \">2</sup>", facility_icon_url = "../../Content/Dormitories_files/room_area.jpg" });
                                //faci.Add(new Facility { facility_name = "<b style=\"color:#0ab21b\">Price: " + dorm.room_price_currency + " " + room_t.room_price + "</b>", facility_icon_url = "../../Content/Dormitories_files/price.png" });




                                //if (langIDPosted == 1)


                                //    if (room_t.num_rooms_left > 1)
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  rooms left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //    }
                                //    else
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  room left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });

                                //    }

                                //else

                                //       if (room_t.num_rooms_left > 1)
                                //{


                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + "  Oda  kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}
                                //else
                                //{
                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + " oda kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}


                                arr.Add(new SearchResultData
                                {
                                    name_of_dormitory = dorm_trans.DormitoryName,
                                    dormitory_address = dorm_trans.DormitoryAddress,
                                    name_of_room = room_trans.RoomTitle,
                                    gender_allocation = dorm_trans.GenderAllocation,
                                    room_price_currency = dorm.RoomPriceCurrency,
                                    map_latitude = dorm.MapLatitude,
                                    map_longitude = dorm.MapLongitude,
                                    url_of_room_image = room_t.RoomPictureUrl,
                                    facility = faci,
                                    dormitory_type = dorm.DormitoryTypeId,
                                    price_of_room = room_t.RoomPrice,
                                    room_area = room_t.RoomArea,
                                    num_rooms_left = room_t.NumRoomsLeft,
                                    dormitory_account = dorm_trans.DormitoryName,
                                    bank_name = "bank name",
                                    turkish_lira_account_number = tr_acct_num,
                                    usd_account_number = usd_acct_num,
                                    dormitory_website = dorm_trans.DormitoryAddress
                                });
                            });

                        });




                    });
                });










            }
            //tr_acct_num = new List<string>();
            //tr_acct_num.Add("Account No: 6820-174392db");
            //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");

            //usd_acct_num = new List<string>();
            //usd_acct_num.Add("Account No: 6820-57259db");
            //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

            //faci = new List<Facility>();
            //faci.Add(new Facility { facility_name = "buckets", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(5).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });

            //arr.Add(new PostData
            //{
            //    name_of_dormitory = "Sample dormitory",
            //    name_of_room = "Sample room",
            //    url_of_room_image = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TEK%20K%C4%B0%C5%9E%C4%B0L%C4%B0K%20EXCLUS%C4%B0VE.jpg?RenditionID=7",
            //    facility = faci,
            //    room_area = 25,
            //    dormitory_type = 1,
            //    dormitory_account = "dormitory_account",
            //    bank_name = "bank name",
            //    price_of_room = 2700,
            //    turkish_lira_account_number = tr_acct_num,
            //    usd_account_number = usd_acct_num,
            //    dormitory_website = "dormitory website"
            //});

            //var faci_query = from Facility f in arr
            //                 where (f.facility_name.Contains("TV"))
            //                 select f;
            //var query = from PostData s in arr
            //            where (s.facility.
            //            select s;

            //var query = from s in arr
            //            where s.Facility.Any(c => c.facility_name.contains("TV"))
            //            select s;

            //  PostData query = arr.fin
            ArrayList sa = new ArrayList();
            //sa.Add("Kitchenette | Flats");
            //sa.Add("TV | In room");
            //sa.Add("Central conditioning system | Cooling");

            sa.Add(facility_TVPosted);
            sa.Add(facility_InternetPosted);
            sa.Add(facility_Wc_showerPosted);
            sa.Add(facility_KitchenettePosted);
            sa.Add(facility_bedPosted);

            sa.Add(facility_air_conditionPosted);
            sa.Add(facility_central_acPosted);
            sa.Add(facility_refrigeratorPosted);
            sa.Add(facility_laundryPosted);
            sa.Add(facility_cafeteriaPosted);
            sa.Add(facility_room_telPosted);
            sa.Add(facility_generatorPosted);

            //string name_of_dormitoryPosted = " ";

            if (name_of_dormitoryPosted == " ")
                name_of_dormitoryPosted = "";

            var query = arr;










            if (dormitory_typePosted == 0)
            {



                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                     item.facility.Any(fac => fac.facility_name.Contains(q.ToString()))
                      )
                   .ToList();



            }
            else
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                      item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                      item.dormitory_type == dormitory_typePosted &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }














            ///highest to lowest
            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_greater_thanPosted_min && item.price_of_room <= price_greater_thanPosted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_5000_to_6000Posted_min && item.price_of_room <= price_5000_to_6000Posted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.price_of_room >= price_4000_to_4999Posted_min && item.price_of_room <= price_4000_to_4999Posted_max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_3000_to_3499Posted_min && item.price_of_room <= price_3000_to_3499Posted_max)

                  )
               .ToList();




            foreach (var q in sa)
                query = query
               .Where(item =>

                 (item.price_of_room >= price_2500_to_2999Posted_min && item.price_of_room <= price_2500_to_2999Posted_max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>


                  item.price_of_room >= price_2000_to_2499Posted_min && item.price_of_room <= price_2000_to_2499Posted_max

                  )
               .ToList();


            //end highest to lowest




            //highest to lowest begin
            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_greater_than_30Posted_min && item.room_area <= room_area_greater_than_30Posted_max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_26_to_30Posted_min && item.room_area <= room_area_26_to_30Posted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_21_to_25Posted_min && item.room_area <= room_area_21_to_25Posted_max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>


               (item.room_area >= room_area_10_to_20Posted_min && item.room_area <= room_area_10_to_20Posted_max)

                  )
               .ToList();



            if (sort_byPosted == "Price")
                query = query.OrderBy(s => s.price_of_room).ToList();
            else if (sort_byPosted == "a-z")
                query = query.OrderBy(s => s.name_of_dormitory).ToList();
            else if (sort_byPosted == "area")
                query = query.OrderBy(s => s.room_area).ToList();

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));
            return PartialView("SearchResultParialView", query);


        }
        
        public ActionResult GetSearchResultMapViewResponsive(PostDataResponsive data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            string name_of_dormitoryPosted = " ";
            int dormitory_typePosted = 1;


            int price_2000_to_2499Posted_min = 0;
            int price_2000_to_2499Posted_max = 0;

            int price_2500_to_2999Posted_min = 0;
            int price_2500_to_2999Posted_max = 0;

            int price_3000_to_3499Posted_min = 0;
            int price_3000_to_3499Posted_max = 0;

            int price_4000_to_4999Posted_min = 0;
            int price_4000_to_4999Posted_max = 0;

            int price_5000_to_6000Posted_min = 0;
            int price_5000_to_6000Posted_max = 0;

            int price_greater_thanPosted_min = 0;
            int price_greater_thanPosted_max = 0;

            int room_area_10_to_20Posted_min = 0;
            int room_area_10_to_20Posted_max = 0;

            int room_area_21_to_25Posted_min = 0;
            int room_area_21_to_25Posted_max = 0;

            int room_area_26_to_30Posted_min = 0;
            int room_area_26_to_30Posted_max = 0;

            int room_area_greater_than_30Posted_min = 0;
            int room_area_greater_than_30Posted_max = 0;



            int langIDPosted = 0;

            string facility_TVPosted = " ";
            string facility_InternetPosted = " ";
            string facility_Wc_showerPosted = " ";
            string facility_KitchenettePosted = " ";
            string facility_bedPosted = " ";

            string facility_air_conditionPosted = " ";
            string facility_central_acPosted = " ";
            string facility_refrigeratorPosted = " ";
            string facility_laundryPosted = " ";
            string facility_cafeteriaPosted = " ";
            string facility_room_telPosted = " ";
            string facility_generatorPosted = " ";
            string sort_byPosted = " ";

            //  var data=  
            var obj = data;
            
name_of_dormitoryPosted = obj.name_of_dormitory == null ? "" : obj.name_of_dormitory;
            dormitory_typePosted = obj.dormitory_type;


            price_2000_to_2499Posted_min = obj.price_2000_to_2499.min;
            price_2000_to_2499Posted_max = obj.price_2000_to_2499.max;

            price_2500_to_2999Posted_min = obj.price_2500_to_2999.min;
            price_2500_to_2999Posted_max = obj.price_2500_to_2999.max;

            price_3000_to_3499Posted_min = obj.price_3000_to_3499.min;
            price_3000_to_3499Posted_max = obj.price_3000_to_3499.max;

            price_4000_to_4999Posted_min = obj.price_4000_to_4999.min;
            price_4000_to_4999Posted_max = obj.price_4000_to_4999.max;

            price_5000_to_6000Posted_min = obj.price_5000_to_6000.min;
            price_5000_to_6000Posted_max = obj.price_5000_to_6000.max;

            price_greater_thanPosted_min = obj.price_greater_than_6000.min;
            price_greater_thanPosted_max = obj.price_greater_than_6000.max;

            room_area_10_to_20Posted_min = obj.room_area_10_to_20.min;
            room_area_10_to_20Posted_max = obj.room_area_10_to_20.max;

            room_area_21_to_25Posted_min = obj.room_area_21_to_25.min;
            room_area_21_to_25Posted_max = obj.room_area_21_to_25.max;

            room_area_26_to_30Posted_min = obj.room_area_26_to_30.min;
            room_area_26_to_30Posted_max = obj.room_area_26_to_30.max;

            room_area_greater_than_30Posted_min = obj.room_area_greater_than_30.min;
            room_area_greater_than_30Posted_max = obj.room_area_greater_than_30.max;



            langIDPosted = obj.langId;

            

        

            facility_TVPosted = obj.facility_TV == null ? "" : obj.facility_TV;
            facility_InternetPosted = obj.facility_Internet == null ? "" : obj.facility_Internet;
            facility_Wc_showerPosted = obj.facility_Wc_shower == null ? "" : obj.facility_Wc_shower;
            facility_KitchenettePosted = obj.facility_Kitchenette == null ? "" : obj.facility_Kitchenette;
            facility_bedPosted = obj.facility_bed == null ? "" : obj.facility_bed;
            sort_byPosted = obj.sort_by == null ? "" : obj.sort_by;
            facility_air_conditionPosted = obj.facility_air_condition == null ? "" : obj.facility_air_condition;
            facility_central_acPosted = obj.facility_central_ac == null ? "" : obj.facility_central_ac;
            facility_refrigeratorPosted = obj.facility_refrigerator == null ? "" : obj.facility_refrigerator;
            facility_laundryPosted = obj.facility_laundry == null ? "" : obj.facility_laundry;
            facility_cafeteriaPosted = obj.facility_cafeteria == null ? "" : obj.facility_cafeteria;
            facility_room_telPosted = obj.facility_room_tel == null ? "" : obj.facility_room_tel;
            facility_generatorPosted = obj.facility_generator == null ? "" : obj.facility_generator;




            //name_of_dormitoryPosted = "";
            //dormitory_typePosted = 0;
            //min_price_of_roomPosted = 0;
            //max_price_of_roomPosted = 4992;
            //room_areaPostedMin = 100000;
            //room_areaPostedMax = 0;
            //langIDPosted = 1;

            //facility_TVPosted = "";
            //facility_InternetPosted = "";
            //facility_Wc_showerPosted = "";
            //facility_KitchenettePosted = "";
            //facility_bedPosted = "";
            //sort_byPosted = "";
            //facility_air_conditionPosted = "";
            //facility_central_acPosted = "";
            //facility_refrigeratorPosted = "";
            //facility_laundryPosted = "";
            //facility_cafeteriaPosted = "";
            //facility_room_telPosted = "";
            //facility_generatorPosted = "";


            List<SearchResultData> arr = new List<SearchResultData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci = new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();


            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();




                usd_acct_num = new List<string>();
                usd_acct_num.Add("Account No: 6820-57259db");
                usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(dorm_trans =>
                    {




                        context.RoomTable.Where(r => r.DormitoryId == dorm.Id).Include(r => r.RoomTableTranslation).Include(r => r.RoomFacility).ToList().ForEach(room_t =>
                        {


                            room_t.RoomTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(room_trans =>
                            {
                                tr_acct_num = new List<string>();
                                ///  tr_acct_num.Add("Account No: 6820-174392db");
                                //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");
                                usd_acct_num = new List<string>();
                                string usdd = "";
                                string trr = "";
                                //usd_acct_num.Add("Account No: 6820-57259db");
                                //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                                context.DormitoryBankAccountTable.Include(r => r.BankCurrencyTable).Where(c => c.DormitoryId == room_t.DormitoryId && room_trans.RoomTableNonTransId == room_t.Id).ToList().ForEach(dorm_bank_acc =>
                                {
                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "USD").ToList().ForEach(bk_curr =>
                                    {
                                        usdd += dorm_bank_acc.BankName;
                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        usdd += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        usd_acct_num.Add(usdd);
                                        usdd = "";

                                    });



                                    dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "TL").ToList().ForEach(bk_curr =>
                                    {
                                        trr += dorm_bank_acc.BankName;

                                        context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                        {
                                            acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                            {
                                                // acc_param_val_trans.Value;

                                                context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                {
                                                    acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                    {
                                                        trr += " | " + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                        //acc_info_param_trans.Parameter;
                                                    });
                                                });
                                            });
                                        });

                                        tr_acct_num.Add(trr);
                                        trr = "";

                                    });
                                });

                                faci = new List<Facility>();
                                //I smell desaster from this part
                                context.RoomFacility.Where(r => r.RoomId == room_t.Id).Include(r => r.Facility).ToList().ForEach(room_faci =>
                                {
                                    context.FacilityTable.Where(r => r.Id == room_faci.FacilityId).Include(r => r.FacilityTableTranslation).ToList().ForEach(facii =>
                                    {
                                        facii.FacilityTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(faci_trans =>
                                        {
                                            string facility_o = "";
                                            context.FacilityOption.Where(r => r.FacilityId == room_faci.FacilityId && facii.Id == room_faci.FacilityId)
                                                        .Include(r => r.FacilityOptionTranslation).ToList().ForEach(faci_op =>
                                                        {
                                                            faci_op.FacilityOptionTranslation
                                                                        .Where(r => r.LanguageId == langIDPosted && r.FacilityOptionNonTransId == room_faci.FacilityOptionId)

                                                                    .ToList().ForEach(faci_op_trans =>
                                                                    {
                                                                        facility_o += " | " + faci_op_trans.FacilityOption;

                                                                    });

                                                        });

                                            faci.Add(new Facility { facility_name = faci_trans.FacilityTitle + facility_o, facility_icon_url = facii.FacilityIconUrl});




                                        });
                                    });


                                });






                                //faci.Add(new Facility { facility_name = "Room Area: " + room_t.room_area + " m" + "<sup style=\"font-size: smaller; \">2</sup>", facility_icon_url = "../../Content/Dormitories_files/room_area.jpg" });
                                //faci.Add(new Facility { facility_name = "<b style=\"color:#0ab21b\">Price: " + dorm.room_price_currency + " " + room_t.room_price + "</b>", facility_icon_url = "../../Content/Dormitories_files/price.png" });




                                //if (langIDPosted == 1)


                                //    if (room_t.num_rooms_left > 1)
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  rooms left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //    }
                                //    else
                                //    {
                                //        faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Only " + room_t.num_rooms_left + "  room left</b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });

                                //    }

                                //else

                                //       if (room_t.num_rooms_left > 1)
                                //{


                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + "  Oda  kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}
                                //else
                                //{
                                //    faci.Add(new Facility { facility_name = "<b  onMouseOver=\"this.style.color = '#0F0' onMouseOut = \"this.style.color='#00F'\">Sadece " + room_t.num_rooms_left + " oda kaldı </b>", facility_icon_url = "../../Content/Dormitories_files/image_key.png" });
                                //}


                                arr.Add(new SearchResultData
                                {
                                    name_of_dormitory = dorm_trans.DormitoryName,
                                    dormitory_address = dorm_trans.DormitoryAddress,
                                    name_of_room = room_trans.RoomTitle,
                                    gender_allocation = dorm_trans.GenderAllocation,
                                    room_price_currency = dorm.RoomPriceCurrency,
                                    map_latitude = dorm.MapLatitude,
                                    map_longitude = dorm.MapLongitude,
                                    url_of_room_image = room_t.RoomPictureUrl,
                                    facility = faci,
                                    dormitory_type = dorm.DormitoryTypeId,
                                    price_of_room = room_t.RoomPrice,
                                    room_area = room_t.RoomArea,
                                    num_rooms_left = room_t.NumRoomsLeft,
                                    dormitory_account = dorm_trans.DormitoryName,
                                    bank_name = "bank name",
                                    turkish_lira_account_number = tr_acct_num,
                                    usd_account_number = usd_acct_num,
                                    dormitory_website = dorm_trans.DormitoryAddress
                                });
                            });

                        });




                    });
                });










            }
            //tr_acct_num = new List<string>();
            //tr_acct_num.Add("Account No: 6820-174392db");
            //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");

            //usd_acct_num = new List<string>();
            //usd_acct_num.Add("Account No: 6820-57259db");
            //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

            //faci = new List<Facility>();
            //faci.Add(new Facility { facility_name = "buckets", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(5).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });
            //faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });

            //arr.Add(new PostData
            //{
            //    name_of_dormitory = "Sample dormitory",
            //    name_of_room = "Sample room",
            //    url_of_room_image = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TEK%20K%C4%B0%C5%9E%C4%B0L%C4%B0K%20EXCLUS%C4%B0VE.jpg?RenditionID=7",
            //    facility = faci,
            //    room_area = 25,
            //    dormitory_type = 1,
            //    dormitory_account = "dormitory_account",
            //    bank_name = "bank name",
            //    price_of_room = 2700,
            //    turkish_lira_account_number = tr_acct_num,
            //    usd_account_number = usd_acct_num,
            //    dormitory_website = "dormitory website"
            //});

            //var faci_query = from Facility f in arr
            //                 where (f.facility_name.Contains("TV"))
            //                 select f;
            //var query = from PostData s in arr
            //            where (s.facility.
            //            select s;

            //var query = from s in arr
            //            where s.Facility.Any(c => c.facility_name.contains("TV"))
            //            select s;

            //  PostData query = arr.fin
            ArrayList sa = new ArrayList();
            //sa.Add("Kitchenette | Flats");
            //sa.Add("TV | In room");
            //sa.Add("Central conditioning system | Cooling");

            sa.Add(facility_TVPosted);
            sa.Add(facility_InternetPosted);
            sa.Add(facility_Wc_showerPosted);
            sa.Add(facility_KitchenettePosted);
            sa.Add(facility_bedPosted);

            sa.Add(facility_air_conditionPosted);
            sa.Add(facility_central_acPosted);
            sa.Add(facility_refrigeratorPosted);
            sa.Add(facility_laundryPosted);
            sa.Add(facility_cafeteriaPosted);
            sa.Add(facility_room_telPosted);
            sa.Add(facility_generatorPosted);

            //string name_of_dormitoryPosted = " ";

            if (name_of_dormitoryPosted == " ")
                name_of_dormitoryPosted = "";

            var query = arr;










            if (dormitory_typePosted == 0)
            {



                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                     item.facility.Any(fac => fac.facility_name.Contains(q.ToString()))
                      )
                   .ToList();



            }
            else
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                      item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                      item.dormitory_type == dormitory_typePosted &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }














            ///highest to lowest
            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_greater_thanPosted_min && item.price_of_room <= price_greater_thanPosted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_5000_to_6000Posted_min && item.price_of_room <= price_5000_to_6000Posted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.price_of_room >= price_4000_to_4999Posted_min && item.price_of_room <= price_4000_to_4999Posted_max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= price_3000_to_3499Posted_min && item.price_of_room <= price_3000_to_3499Posted_max)

                  )
               .ToList();




            foreach (var q in sa)
                query = query
               .Where(item =>

                 (item.price_of_room >= price_2500_to_2999Posted_min && item.price_of_room <= price_2500_to_2999Posted_max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>


                  item.price_of_room >= price_2000_to_2499Posted_min && item.price_of_room <= price_2000_to_2499Posted_max

                  )
               .ToList();


            //end highest to lowest




            //highest to lowest begin
            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_greater_than_30Posted_min && item.room_area <= room_area_greater_than_30Posted_max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_26_to_30Posted_min && item.room_area <= room_area_26_to_30Posted_max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= room_area_21_to_25Posted_min && item.room_area <= room_area_21_to_25Posted_max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>


               (item.room_area >= room_area_10_to_20Posted_min && item.room_area <= room_area_10_to_20Posted_max)

                  )
               .ToList();



            if (sort_byPosted == "Price")
                query = query.OrderBy(s => s.price_of_room).ToList();
            else if (sort_byPosted == "a-z")
                query = query.OrderBy(s => s.name_of_dormitory).ToList();
            else if (sort_byPosted == "area")
                query = query.OrderBy(s => s.room_area).ToList();

            //ViewBag.PaginationCountCount = Math.Ceiling((decimal)(query.Count / 8));
            return PartialView("MapSearchResult_partialView", query);


        }





        public ActionResult GetDormitoriesBasedOnType(dormitory_struct data)
        {

            int dormitory_typePosted = 1;
            int langIDPosted = 0;
            var obj = data;

            dormitory_typePosted = obj.dormitory_type;
            langIDPosted = obj.langId;

            List<string> listDormitories = new List<string>();


            listDormitories.Add("");

            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



                context.DormitoriesTable.Where(d => d.DormitoryTypeId == dormitory_typePosted).ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(dorm_trans =>
                    {
                        listDormitories.Add(dorm_trans.DormitoryName);
                    });


                });

            }



            //   listDormitories.Add("Marmara");
            //listDormitories.Add("Marmara");
            //listDormitories.Add("Marmara");
            //listDormitories.Add("Marmara");
            //listDormitories.Add("Marmara");

            return PartialView("OptionsDropdownView", listDormitories);
        }



        public class PostDummy
        {
            public string name_of_dormitory { get; set; }
            public int dormitory_type { get; set; }
        }

        public class dormitory_struct
        {
            public int dormitory_type { get; set; }
            public int langId { get; set; }
        }

        public class PostData2
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

        public class MinMaxStruct
        {
            public int min { get; set; }
            public int max { get; set; }
        }
        public class PostDataResponsive
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
}