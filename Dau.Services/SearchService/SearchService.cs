using Dau.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.SearchService
{
   public class SearchService
    {

        private fees_and_facilitiesContext _context = new fees_and_facilitiesContext();


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

        
    }
}
