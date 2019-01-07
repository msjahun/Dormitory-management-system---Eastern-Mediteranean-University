using Dau.Core.Domain.Catalog;

using Dau.Data.Repository;
using Dau.Services.Languages;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetGoodToKnowService : IGetGoodToKnowService
    {
        private readonly IRepository<Dormitory> _dormRepo;

        public GetGoodToKnowService(
              IRepository<Dormitory> dormitoryRepository,  ILanguageService languageService)
        {
            _dormRepo = dormitoryRepository;
        }

        public GoodToKnowSectionViewModel GetGoodToKnowInfo(long DormitoryId)
        {



            var dorm = _dormRepo.GetById(DormitoryId);

            GoodToKnowSectionViewModel model = new GoodToKnowSectionViewModel
            {
                WeekdaysOpeningTime =  new OpeningClosingTime
                {
                    OpeningTime = int.Parse(dorm.WeekdaysOpeningTime.ToString("HH")),
                    ClosingTime = int.Parse(dorm.WeekdaysClosingTime.ToString("HH")),
                   
                },


                WeekendsOpeningTime = new OpeningClosingTime
                {
                    OpeningTime = int.Parse(dorm.WeekendsOpeningTime.ToString("HH")),

                    ClosingTime = int.Parse(dorm.WeekendsClosingTime.ToString("HH"))
                }
              
            
            };

            return model;
        }
    }


    public class GoodToKnowSectionViewModel
    {
        public OpeningClosingTime WeekdaysOpeningTime { get; set; }
        public OpeningClosingTime WeekendsOpeningTime { get; set; }
    }

    

    public class OpeningClosingTime 
    {
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
    }
}
