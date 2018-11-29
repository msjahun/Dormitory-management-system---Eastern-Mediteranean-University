using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dau.Core.Domain.Dormitory;
using Dau.Core.Domain.Language;
using Dau.Core.Domain.BankAccount;

namespace Dau.Services.Dormitory
{
   public class DormitoryService : IDormitoryService
    {
        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();

        public List<string> GetListAllDormitoriesByLangAndType (int _dormitory_type_id, int _lang_id)
        {
            List<string> listDormitories = new List<string>();
            using (var context = _context)
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



                context.DormitoriesTable.Where(d => d.DormitoryTypeId == _dormitory_type_id).ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == _lang_id).ToList().ForEach(dorm_trans =>
                    {
                        listDormitories.Add(dorm_trans.DormitoryName);
                    });


                });

            }

            return listDormitories;
        }


        public List<SelectListItem> GetSelectListDormitories(int _lang_id)
        {

            List<SelectListItem> Dormitories = new List<SelectListItem>();
            Dormitories.Add(new SelectListItem { Value = "-1", Text = ""});

            using (var context = _context)
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == _lang_id).ToList().ForEach(dorm_trans =>
                    {

                        Dormitories.Add(new SelectListItem { Value = dorm_trans.DormitoriesTableNonTransId.ToString(), Text = dorm_trans.DormitoryName });

                    });


                });

            }


            return Dormitories;
        }


        public void DormitoryAdd()
        {

            using (var context = _context)
            {
                dormitory_data data = new dormitory_data();
                


                    DormitoryType dormitory_Type = context.DormitoryType
                        .FirstOrDefault(l => l.Id == l.DormitoryTypeTranslation
                        .FirstOrDefault(x => x.TypeName == data.DormitoryType)
                        .DormitoryTypeNonTransId);
                    DormitoriesTable dormitory = new DormitoriesTable
                    {
                        DormitoryTypeId = dormitory_Type.Id,
                        RoomPriceCurrency = data.room_price_currency,
                       RoomPriceCurrencySymbol= data.room_price_currency_symbol,
                        MapLatitude = data.map_latitude,
                        MapLongitude = data.map_longitude
                    };
                    context.DormitoriesTable.Add(dormitory);
                    context.SaveChanges();

                    //English

                    LanguageTable language_Table_EN = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "EN");
                    context.DormitoriesTableTranslation.Add(new DormitoriesTableTranslation
                    {
                        LanguageId = language_Table_EN.Id,
                        DormitoriesTableNonTransId = dormitory.Id,
                        DormitoryAddress = data.dormitory_address_EN,
                        GenderAllocation = data.gender_allocation_EN,
                        RoomsPaymentPeriod = data.rooms_payment_period_EN,
                        DormitoryName = data.dormitory_name_EN
                    });
                    //Turkish
                    LanguageTable language_Table_TR = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "TR");
                    context.DormitoriesTableTranslation.Add(new DormitoriesTableTranslation
                    {
                        LanguageId = language_Table_TR.Id,
                        DormitoriesTableNonTransId = dormitory.Id,
                        DormitoryAddress = data.dormitory_address_TR,
                        GenderAllocation = data.gender_allocation_TR,
                        RoomsPaymentPeriod = data.rooms_payment_period_TR,
                        DormitoryName = data.dormitory_name_TR
                    });


                    context.SaveChanges();

             
            }
            }





        public List<DormitoriesDataTable> GetAllDormitoriesForTable()
        { var dormitories = new List<DormitoriesDataTable>();

            _context.DormitoriesTable.Select(p => new {
                
                DormitoryId=p.Id,
                domritoryName = p.DormitoriesTableTranslation.Where(r => r.LanguageId == 1).Select(c => c.DormitoryName).FirstOrDefault().ToString(),

             dormitoryPicture = p.RoomTable.Select(r => r.RoomPictureUrl).FirstOrDefault(),
                dormitoryType = p.DormitoryType.DormitoryTypeTranslation.Select(s => s.TypeName).FirstOrDefault()
            }).ToList().ForEach(j =>
            {
                dormitories.Add(new DormitoriesDataTable {
                    DormitoryName = j.domritoryName,
                    DormitoryType = j.dormitoryType,
                    Picture = j.dormitoryPicture,
                    Published = true,
                    DormitoryId= j.DormitoryId
                    
                });
            });


            return dormitories;
        }



        public void dormitories_types_initiate()
        { //dormitories_types_initiate done


            using (var context = _context)
            {
                context.DormitoryType.Add(new DormitoryType { });
                context.SaveChanges();
                DormitoryType dormitory_Type = context.DormitoryType.FirstOrDefault(l => l.Id > 0);
                LanguageTable language_Table_EN = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "EN");
                context.DormitoryTypeTranslation.Add(new DormitoryTypeTranslation
                { LanguageId = language_Table_EN.Id, DormitoryTypeNonTransId = dormitory_Type.Id, TypeName = "Eastern Mediterranean University Dormitories on Campus Residence" });
                //   context.SaveChanges();

                LanguageTable language_Table_TR = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "TR");
                //context.DormitoryTypeTranslation.Add(new DormitoryTypeTranslation
                //{ LanuageId = language_Table_TR.id, DormitoryTypeNonTransId = dormitory_Type.id, TypeName = "DAÜ Yurtları (DAÜ Yutlarında Kayıtlar Dönemlik Yapılmaktadır)" });
                //context.SaveChanges();


                context.DormitoryType.Add(new DormitoryType { });
                context.SaveChanges();

                DormitoryType dormitory_Type1 = context.DormitoryType.FirstOrDefault(l => l.Id > 1);


                context.DormitoryTypeTranslation.Add(new DormitoryTypeTranslation
                { LanguageId = language_Table_EN.Id, DormitoryTypeNonTransId = dormitory_Type1.Id, TypeName = "EMU BOT (build-operate-transfer) Dormitories on Campus Residence" });

                context.DormitoryTypeTranslation.Add(new DormitoryTypeTranslation
                { LanguageId = language_Table_TR.Id, DormitoryTypeNonTransId = dormitory_Type1.Id, TypeName = "DAÜ Yap - İşlet - Devret Yurtları (YİD Yurtlarına Kayıtlar Yıllık" });
                context.SaveChanges();

            }



        }


        public void dormitory_bank_account_details_initiate()
        {
            using ( var context = _context)
            {
                dormitory_bank_details_data ddt = new dormitory_bank_details_data();

         

                    LanguageTable language_Table_EN = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "EN");
                    LanguageTable language_Table_TR = context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "TR");
                    //query language ids


                    DormitoriesTable dormitory = context.DormitoriesTable
                    .FirstOrDefault(d => d.Id == d.DormitoriesTableTranslation
                    .FirstOrDefault(c => c.DormitoryName == ddt.dormitory_name)
                    .DormitoriesTableNonTransId);
                    //this brings back dormitory id.

                    //********************** DormitoryBankAccountTable & bank_currency_table
                    DormitoryBankAccountTable dormitory_Bank_Account = new DormitoryBankAccountTable
                    {
                        BankName = ddt.bank_name,
                        DormitoryId = dormitory.Id
                    };

                    context.DormitoryBankAccountTable.Add(dormitory_Bank_Account);
                    context.SaveChanges();
                    //  dormitory_Bank_Account.id;

                    BankCurrencyTable bank_Currency = new BankCurrencyTable
                    {
                        BankId = dormitory_Bank_Account.Id,
                        CurrencyName = ddt.bank_currency
                    };

                    context.BankCurrencyTable.Add(bank_Currency);
                    context.SaveChanges();


                    //************************ account_information_parameter & account_paratermeter_translation
                    AccountInformationParameter account_Information_Param = new AccountInformationParameter
                    {
                    };
                    context.AccountInformationParameter.Add(account_Information_Param);
                    context.SaveChanges();
                    //account_Information_Param.id;


                    //english_translation
                    context.AccountInformationParameterTranslation.Add(new AccountInformationParameterTranslation
                    {
                        AccountInfoNonTransId= account_Information_Param.Id,
                        LanguageId = language_Table_EN.Id,
                        Parameter = ddt.account_parameter_en
                    }); context.SaveChanges();

                    //turkish_translation
                    context.AccountInformationParameterTranslation.Add(new AccountInformationParameterTranslation
                    {
                        AccountInfoNonTransId= account_Information_Param.Id,
                        LanguageId = language_Table_TR.Id,
                        Parameter = ddt.account_parameter_TR
                    }); context.SaveChanges();



                    //********************* accoung_parater_values & translation_table
                    AccountParameterValues account_Parameter_Val = new AccountParameterValues
                    {
                        CurrencyId = bank_Currency.Id,
                        ParameterId = account_Information_Param.Id

                    };
                    context.AccountParameterValues.Add(account_Parameter_Val);
                    context.SaveChanges();


                    //english_translation
                    context.AccountParameterValuesTranslation.Add(new AccountParameterValuesTranslation
                    {
                        Value = ddt.account_parameter_value_en,
                        LanguageId = language_Table_EN.Id,
                        AccountParamsValuesNonTransId = account_Parameter_Val.Id
                    });
                    context.SaveChanges();


                    //turkish_translation
                    context.AccountParameterValuesTranslation.Add(new AccountParameterValuesTranslation
                    {
                        Value = ddt.account_parameter_value_tr,
                        LanguageId = language_Table_TR.Id,
                        AccountParamsValuesNonTransId = account_Parameter_Val.Id
                    });
                    context.SaveChanges();

               
            }

        }


    }



    class dormitory_data
    {
      
        public String DormitoryType { get; set; }
        public String room_price_currency { get; set; }
        public String room_price_currency_symbol { get; set; }
        public String dormitory_address_EN { get; set; }
        public String dormitory_address_TR { get; set; }
        public String gender_allocation_EN { get; set; }
        public String rooms_payment_period_EN { get; set; }
        public String dormitory_name_EN { get; set; }

        public String gender_allocation_TR { get; set; }
        public String rooms_payment_period_TR { get; set; }
        public String dormitory_name_TR { get; set; }
        public String map_latitude { get; set; }
        public string map_longitude { get; set; }

    }


    public class dormitory_bank_details_data
    {
        public string dormitory_name { get; set; }
        public string bank_name { get; set; }
        public string bank_currency { get; set; }
        public string account_parameter_en { get; set; }
        public string account_parameter_TR { get; set; }
        public string account_parameter_value_en { get; set; }
        public string account_parameter_value_tr { get; set; }

    }

    public class DormitoriesDataTable
    { public int DormitoryId { get; set; }
        public string Picture { get; set; }
        public string DormitoryName { get; set; }
        public string SKU { get; set; }
        public string DormitoryType { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }
}
