using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.CurrencyInformation;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.CurrencyServices
{
  public  class CurrencyService : ICurrencyService
    {
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<Currency> _currencyRepo;
        private readonly IRepository<Room> _roomRepo;

        public CurrencyService(
            IRepository<Currency> currencyRepo,
            IRepository<Dormitory> dormitoryRepo,
            IRepository<Room> roomRepo)
        {
            _dormitoryRepo = dormitoryRepo;
            _currencyRepo = currencyRepo;
            _roomRepo = roomRepo;
        }

        public long AddCurrency(CurrencyCrud vm)
        {
            try
            {


                var NewCurrency = new Currency
                {
                    Name = vm.Name,
                    CurrencyCode = vm.CurrencyCode,
                    Rate = vm.Rate,
                    CustomFormatting = vm.CustomFormatting,
                    Published = vm.Published,
                    DisplayOrder = vm.DisplayOrder,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                var newCurrencyId = _currencyRepo.Insert(NewCurrency);

                return newCurrencyId;
            }
            catch
            {
                return 0;
            }
        }


        public CurrencyCrud GetCurrencyById(long Id)
        {
            try
            {
                var vm = _currencyRepo.GetById(Id);
                if (vm == null) return null;

                var model = new CurrencyCrud
                {Id=vm.Id,
                    Name = vm.Name,
                    CurrencyCode = vm.CurrencyCode,
                    Rate = vm.Rate,
                    CustomFormatting = vm.CustomFormatting,
                    Published = vm.Published,
                    DisplayOrder = vm.DisplayOrder,
                    CreatedOn = vm.CreatedOn,
                    UpdatedOn = vm.UpdatedOn
                };


                return model;
            }
            catch
            {
                return null;
            }
        }


        public bool UpdateCurrency(CurrencyCrud vm)
        {
            try
            {
                var currency = _currencyRepo.GetById(vm.Id);
                if (currency == null) return false;

                currency.Name = vm.Name;
                currency.CurrencyCode = vm.CurrencyCode;
                currency.Rate = vm.Rate;
                currency.CustomFormatting = vm.CustomFormatting;
                currency.Published = vm.Published;
                currency.DisplayOrder = vm.DisplayOrder;
                currency.UpdatedOn = DateTime.Now;

                _currencyRepo.Update(currency);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteCurrency(long Id)
        {
            try
            {

         
            var currencyToDelete = _currencyRepo.GetById(Id);
            if (currencyToDelete == null) return false;

            _currencyRepo.Delete(currencyToDelete);

            return true;
            }
            catch
            {
                return false;
            }
        }


        public bool MarkAsPrimaryExchangeRateCurrency(long Id)
        {
            return true;
        }

       

        public List<CurrenciesTable> GetCurrenciesTablesList()
        {
            var currencies = from currency in _currencyRepo.List().ToList()
                             select new CurrenciesTable
                             {
                                 Id =currency.Id,
                                 Name= currency.Name,
                                 CurrencyCode = currency.CurrencyCode,
                                 Published = currency.Published,
                                 Rate = currency.Rate,
                                 DisplayOrder= currency.DisplayOrder,
                                 IsPrimaryExchangeRateCurrecy= true,
                                 IsPrimaryDormtoryCurrency= true

                             };


            return currencies.ToList();
        }

        public object GetDormitoryCurrencyCode(long id)
        {
            var dormitory = _dormitoryRepo.GetById(id);
            if(dormitory==null) return new { success = false};

            if(dormitory.CurrencyId<=0)
                return new { success = false};


            var currency = _currencyRepo.GetById(dormitory.CurrencyId);
            if(currency==null) return new { success = false};
            return new { success = true, currencyCode = currency.CurrencyCode };


        }

        public string CurrencyFormatterByRoomId(long Id, double Amount)
        {

            var room = _roomRepo.GetById(Id);
            if (room == null) return null;

            var dormitory = _dormitoryRepo.GetById(room.DormitoryId);
            if (dormitory == null) return null;

            if (dormitory.CurrencyId <= 0)
                return null;


            var currency = _currencyRepo.GetById(dormitory.CurrencyId);



            var formattedString = CurrencyFormatter(currency.CustomFormatting, currency.CurrencyCode, Amount);

            return formattedString;
            //get dormitory,
            //get dormitorycurrency
            //use currency id to
            //return "$ 500" or "500 TL" or "500 USD"
        }


        public string CurrencyFormatter(string Customformat,string CurrencyCode, double Amount)
        {
            var format = "{0} {1}";
            if (!string.IsNullOrEmpty(Customformat) && !string.IsNullOrWhiteSpace(Customformat))
                format = Customformat;

            var formattedString = string.Format(format, Amount.ToString("N2"), CurrencyCode);

            if (!string.IsNullOrEmpty(Customformat) && !string.IsNullOrWhiteSpace(Customformat))
                formattedString = string.Format(format, Amount.ToString("N2"));

            return formattedString;
        }

        public string CurrencyFormatterByDormitoryId(long Id, double Amount)
        {

            
            var dormitory = _dormitoryRepo.GetById(Id);
            if (dormitory == null) return null;

            if (dormitory.CurrencyId <= 0)
                return null;


            var currency = _currencyRepo.GetById(dormitory.CurrencyId);

            var formattedString = CurrencyFormatter(currency.CustomFormatting, currency.CurrencyCode, Amount);

            return formattedString;

        }
    }


    public class CurrenciesTable
    {
        public long Id;

        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public double Rate { get; set; }
        public bool IsPrimaryExchangeRateCurrecy { get; set; }
    
        public bool IsPrimaryDormtoryCurrency { get; set; }

        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
     
    }


    public class CurrencyCrud
    {

        public long Id { get; set; }
        [Required]
        [Display(Name = "Name",
      Description = "The name of the currency."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

      
        [Display(Name = "Custom Formatting",
      Description = "Custom Formatting, how prices displayed in this currency will be formatted."), DataType(DataType.Text), MaxLength(256)]
        public string CustomFormatting { get; set; }

        [Required]
        [Display(Name = "Currency Code",
    Description = "The currency code.For a list of currency codes, go to: http://www.iso.org/iso/support/currency_codes_list-1.htm."), DataType(DataType.Text), MaxLength(256)]
        public string CurrencyCode { get; set; }

        [Required]
        [Display(Name = "Rate",
    Description = "The exchange rate against the primary exchange rate currency.")]
        public double Rate { get; set; }


        [Display(Name = "Published",
        Description = "Determines whether the currency is published.")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order of this currency. 1 represents the top of the list.")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Created On",
           Description = "The date/time the currency was created.")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated On",
          Description = "The date/time the currency was updated.")]
        public DateTime UpdatedOn { get; set; }
    }


}
