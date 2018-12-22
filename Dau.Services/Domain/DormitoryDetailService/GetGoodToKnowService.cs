using Dau.Core.Domain.Catalog;
using Dau.Data;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetGoodToKnowService : IGetGoodToKnowService
    {
        private readonly Fees_and_facilitiesContext _dbContext;
        private readonly ILanguageService _languageService;
        
        private readonly IRepository<GoodToKnow> _goodToKnowRepo;
        private readonly IRepository<GoodToKnowTitleValue> _goodToKnowTitleValueRepo;
        private readonly IRepository<GoodToKonwTitleValueTranslation> _goodToKnowTitleValueTransRepo;
        private readonly IRepository<OpeningClosingTime> _openingClosingTimeRepo;

        public GetGoodToKnowService(
            IRepository<GoodToKnow> goodToKnowRepo,
            IRepository<GoodToKnowTitleValue> goodToKnowTitleValueRepo,
            IRepository<GoodToKonwTitleValueTranslation> goodToKnowTitleValueTransRepo,
            IRepository<OpeningClosingTime> OpeningClosingTimeRepo,
              ILanguageService languageService,
              Fees_and_facilitiesContext dbContext
            )
        {
            _dbContext = dbContext;
            _languageService = languageService;
           
            _goodToKnowRepo= goodToKnowRepo;
            _goodToKnowTitleValueRepo= goodToKnowTitleValueRepo;
            _goodToKnowTitleValueTransRepo= goodToKnowTitleValueTransRepo;
            _openingClosingTimeRepo = OpeningClosingTimeRepo;
        }

        public GoodToKnowSectionViewModel GetGoodToKnowInfo(long DormitoryId)
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

           
            var goodToKnowInfo = from goodToKnow in _goodToKnowRepo.List().ToList()
                                 where goodToKnow.DormitoryId == DormitoryId
                                 select goodToKnow;

            var WeekdayOpeningTime = _dbContext.Dormitory.Include(c => c.GoodToKnowInfo.WeekdaysOpeningTime).Where(x => x.Id == DormitoryId).FirstOrDefault().GoodToKnowInfo.WeekdaysOpeningTime;
            var WeekendOpeningTime = _dbContext.Dormitory.Include(d => d.GoodToKnowInfo.WeekendsOpeningTime).Where(x => x.Id == DormitoryId).FirstOrDefault().GoodToKnowInfo.WeekendsOpeningTime;
                                 

            //var WeekdaysOpeningTime = from goodtoKnow in goodToKnowInfo.ToList()
            //                         join weekdayTime in _openingClosingTimeRepo.List().ToList() on goodtoKnow.Id equals weekdayTime.GoodToKnowId
            //                         select new OpeningClosingTime
            //                         {
            //                             OpeningTime = weekdayTime.OpeningTime,
            //                             ClosingTime = weekdayTime.ClosingTime
            //                         };



            var GoodToKnowTitleValue = from goodtoKnowTL in _goodToKnowTitleValueRepo.List().ToList()
                                       join goodToKnowTransTL in _goodToKnowTitleValueTransRepo.List().ToList() on goodtoKnowTL.Id equals goodToKnowTransTL.GoodToKnowTitleValueNonTransId
                                       where goodToKnowTransTL.LanguageId == CurrentLanguageId &&goodToKnowInfo.FirstOrDefault().Id == goodtoKnowTL.GoodToKnowId
                                       select new GoodToKnowTitleValueVM
                                       {
                                           Icon = goodtoKnowTL.Icon,
                                           Title = goodToKnowTransTL.Title,
                                           Value = goodToKnowTransTL.Value
                                       };




            GoodToKnowSectionViewModel model = new GoodToKnowSectionViewModel
            {
                WeekdaysOpeningTime = WeekdayOpeningTime,


                WeekendsOpeningTime = WeekendOpeningTime,
                OtherInfosList = GoodToKnowTitleValue.ToList()
            
            };

            return model;
        }
    }


    public class GoodToKnowSectionViewModel
    {
        public OpeningClosingTime WeekdaysOpeningTime { get; set; }
        public OpeningClosingTime WeekendsOpeningTime { get; set; }
        public List<GoodToKnowTitleValueVM> OtherInfosList { get; set; }
    }


    public class GoodToKnowTitleValueVM
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
