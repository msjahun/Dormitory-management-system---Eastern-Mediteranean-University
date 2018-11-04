using Dau.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.SearchService
{
   public class SearchService : ISearchService
    {

        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();

        public SearchService(Fees_and_facilitiesContext _context)
        {
            this._context = _context;
        }

        public List<SearchResultData> GetSearchData(int langIDPosted)
        {


            List<SearchResultData> arr = new List<SearchResultData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci = new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();

            using (var context = _context)
            {
                //get all dormitories
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
                                usd_acct_num = new List<string>();
                                string usdd = "";
                                string trr = "";

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

                                            faci.Add(new Facility { facility_name = faci_trans.FacilityTitle + facility_o, facility_icon_url = facii.FacilityIconUrl });




                                        });
                                    });


                                });


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

       
            return arr;
        }

        public List<SearchResultData> SortSeachResult(List<SearchResultData> query, string _sort_by)
        {
            if (_sort_by == "Price")
                query = query.OrderBy(s => s.price_of_room).ToList();
            else if (_sort_by == "a-z")
                query = query.OrderBy(s => s.name_of_dormitory).ToList();
            else if (_sort_by == "area")
                query = query.OrderBy(s => s.room_area).ToList();
            return query;
        }


        public List<SearchResultData> Filtering(List<SearchResultData> query, PostedDormitoryFilters filter, ArrayList sa)
        {
            if (filter.dormitory_type == 0)
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(filter.name_of_dormitory) &&

                    item.room_area >= filter.room_areaMin && item.room_area <= filter.room_areaMax &&
                      item.price_of_room >= filter.min_price_of_room && item.price_of_room <= filter.max_price_of_room
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
                      item.name_of_dormitory.Contains(filter.name_of_dormitory) &&
                      item.dormitory_type == filter.dormitory_type &&
                      item.room_area >= filter.room_areaMin && item.room_area <= filter.room_areaMax &&
                      item.price_of_room >= filter.min_price_of_room && item.price_of_room <= filter.max_price_of_room &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }

            return query;
        }

        public List<SearchResultData> Filtering(List<SearchResultData> query, PostedDormitoryFiltersResponsive filter, ArrayList sa)
        {
            if (filter.dormitory_type == 0)
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                     item.name_of_dormitory.Contains(filter.name_of_dormitory) &&
                     item.facility.Any(fac => fac.facility_name.Contains(q.ToString()))
                      )
                   .ToList();



            }
            else
            {
                foreach (var q in sa)
                    query = query
                   .Where(item =>
                      item.name_of_dormitory.Contains(filter.name_of_dormitory) &&
                      item.dormitory_type == filter.dormitory_type &&
                      item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                   .ToList();
            }


            ///highest to lowest
            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= filter.price_greater_than_6000.min && item.price_of_room <= filter.price_greater_than_6000.max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= filter.price_5000_to_6000.min && item.price_of_room <= filter.price_5000_to_6000.max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.price_of_room >= filter.price_4000_to_4999.min && item.price_of_room <= filter.price_4000_to_4999.max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>
                  (item.price_of_room >= filter.price_3000_to_3499.min && item.price_of_room <= filter.price_3000_to_3499.max)

                  )
               .ToList();




            foreach (var q in sa)
                query = query
               .Where(item =>

                 (item.price_of_room >= filter.price_2500_to_2999.min && item.price_of_room <= filter.price_2500_to_2999.max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>


                  item.price_of_room >= filter.price_2000_to_2499.min && item.price_of_room <= filter.price_2000_to_2499.max

                  )
               .ToList();


            //end highest to lowest




            //highest to lowest begin
            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= filter.room_area_greater_than_30.min && item.room_area <= filter.room_area_greater_than_30.max)

                  )
               .ToList();



            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= filter.room_area_26_to_30.min && item.room_area <= filter.room_area_26_to_30.max)

                  )
               .ToList();

            foreach (var q in sa)
                query = query
               .Where(item =>

                  (item.room_area >= filter.room_area_21_to_25.min && item.room_area <= filter.room_area_21_to_25.max)

                  )
               .ToList();


            foreach (var q in sa)
                query = query
               .Where(item =>


               (item.room_area >= filter.room_area_10_to_20.min && item.room_area <= filter.room_area_10_to_20.max)

                  )
               .ToList();


            return query;
        }
    }
}
