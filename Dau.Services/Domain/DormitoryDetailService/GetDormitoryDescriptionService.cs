using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public class GetDormitoryDescriptionService : IGetDormitoryDescriptionService
    {
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;

        public GetDormitoryDescriptionService(
             ILanguageService languageService,
            IRepository<Dormitory> dormitoryRepo, 
            IRepository<DormitoryTranslation> dormitoryTransRepo
            )
        {
            _languageService = languageService;
            _dormitoryRepo = dormitoryRepo;
            _dormitoryTransRepo = dormitoryTransRepo;
        }

        public DormitoryDescriptionSectionViewModel GetDormitoryDescription(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dorm.Id == DormitoryId && dormTrans.LanguageId == CurrentLanguageId
                            select new DormitoryDescriptionSectionViewModel
                            {RatingNo = dorm.RatingNo.ToString("N1"),
                                RatingText = "Excellent",
                             
                                ReviewNo = 23,
                                Location = dorm.Location,
                                NoOfStudents = dorm.NoOfStudents,
                                Option = dormTrans.Option,
                                OptionValue = dormTrans.OptionValue,
                                StandAloneOption = dormTrans.StandAloneOption,
                             
                                NoOfAwards =dorm.NoOfAwards.ToString(),
                                NoOfNewFacilities = dorm.NoOfNewFacilities.ToString(),
                                NoOfStaff = dorm.NoOfStaff.ToString(),

                                DormitoryDescription=dormTrans.DormitoryDescription


                            };


            DormitoryDescriptionSectionViewModel model = dormitory.FirstOrDefault();
            return model;

        }
    }

    public class DormitoryDescriptionSectionViewModel
    {
        public string DormitoryDescription { get; set; }
        public string RatingText { get; set; }
        public int NoOfStudents { get; set; }
        public string RatingNo { get; set; }
        public int ReviewNo { get; set; }
        public string Location { get; set; }
        public string Option { get; set; }//staff
        public string OptionValue { get; set; }//staff are very friendly
        public string StandAloneOption { get; set; }//has a gym!
        public string NoOfNewFacilities { get; set; }
        public string NoOfStaff { get; set; }
        public string NoOfAwards { get; set; }

    }

}
