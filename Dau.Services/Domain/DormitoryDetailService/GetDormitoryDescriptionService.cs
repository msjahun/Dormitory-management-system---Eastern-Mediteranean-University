using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Domain.ReviewsServices;
using Dau.Services.Languages;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public class GetDormitoryDescriptionService : IGetDormitoryDescriptionService
    {
        private readonly IDropdownService _dropdownService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IReviewService _reviewService;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IStringLocalizer _Localizer;
        private readonly IMapService _mapService;

        public GetDormitoryDescriptionService(
             ILanguageService languageService,
            IRepository<Dormitory> dormitoryRepo, 
            IRepository<DormitoryTranslation> dormitoryTransRepo,
            IDropdownService dropdownService,
            IReviewService reviewService,
            IRepository<Review> reviewRepo,
            IStringLocalizer stringLocalizer,
            IMapService mapService
            )
        {
            _dropdownService = dropdownService;
            _languageService = languageService;
            _dormitoryRepo = dormitoryRepo;
            _dormitoryTransRepo = dormitoryTransRepo;
            _reviewService = reviewService;
            _reviewRepo = reviewRepo;
            _Localizer = stringLocalizer;
            _mapService = mapService;
        }

        public DormitoryDescriptionSectionViewModel GetDormitoryDescription(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dorm.Id == DormitoryId && dormTrans.LanguageId == CurrentLanguageId
                            select new DormitoryDescriptionSectionViewModel
                            {
                                
                                RatingNoRaw = dorm.RatingNo,
                                RatingNo = (_reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count <= 0) ? _Localizer[ "N.A"] : dorm.RatingNo.ToString("N1"),
                            
                                RatingText = (_reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count <= 0) ? _Localizer["Unrated"] : _reviewService.ResolveRatingText(dorm.RatingNo),
                                ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                Location =  _dropdownService.ResolveDropdown(dorm.LocationOnCampus,_dropdownService.LocationOnCampus()),
                                NoOfStudents = dorm.NoOfStudents,
                               
                             
                                NoOfAwards =dorm.NoOfAwards.ToString(),
                                NoOfNewFacilities = dorm.NoOfNewFacilities.ToString(),
                                NoOfStaff = dorm.NoOfStaff.ToString(),

                                DormitoryDescription=dormTrans.DormitoryDescription,
                                DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                DormitoryType = _Localizer["Dormitory belongs to the category of {0} ",(dorm.DormitoryTypeId==2)? _Localizer["private school dormitories/ accomodations (BOT)"]: _Localizer["School EMU dormitories"]],
                                DormitoryLogoUrl = dorm.DormitoryLogoUrl,
                                MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),


                            };


            DormitoryDescriptionSectionViewModel model = dormitory.FirstOrDefault();
            return model;

        }
    }

    public class DormitoryDescriptionSectionViewModel
    {
        public string MapSection { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryLogoUrl { get; set; }

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
        public double RatingNoRaw { get; internal set; }
    }

}
