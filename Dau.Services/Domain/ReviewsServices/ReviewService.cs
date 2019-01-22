using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Event;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dau.Services.Domain.ReviewsServices
{
   public class ReviewService : IReviewService
    {
        private readonly IEventService _eventService;
        private readonly IUserRolesService _userRolesService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Review> _reviewsRepo;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IStringLocalizer _localizer;

        public ReviewService(IRepository<Review> reviewsRepository,
            UserManager<User> userManager,
             IHttpContextAccessor httpContextAccessor,
             IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
              ILanguageService languageService,
               IUserRolesService userRolesService,
               IEventService eventService,
               IStringLocalizer stringLocalizer)
        {
            _eventService = eventService;
            _userRolesService = userRolesService;
            _languageService = languageService;
            _reviewsRepo =reviewsRepository;
            _userManager =userManager;
            _dormitoryRepo = dormitoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _dormitoryTransRepo = dormitoryTransRepository;
            _localizer = stringLocalizer;
        }

        public List<ReviewsTable> GetReviewsListTable()
        {


            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new
                            {
                                dorm.Id,
                                dormTrans.DormitoryName,
                                dorm.SKU,
                                dorm.Published
                            };


            var reviews = from review in _reviewsRepo.List().ToList()
                          select new ReviewsTable
                          {
                              DormitoryId= review.DormitoryId,
                              Dormitory = dormitory.ToList().Where(c=> c.Id == review.DormitoryId).FirstOrDefault().DormitoryName,
                              User = _userManager.Users.ToList().Where(c=> c.Id == review.UserId).FirstOrDefault().UserName,
                              ReviewText = review.Message,
                              Rating = review.Rating.ToString("N1"),
                              IsApproved = review.IsApproved,
                              createdOn = review.CreatedOn
                          };



            var model = reviews.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList();


            return model;
        }

        public bool AddReviewService(ReviewInputVm vm)
        {
            try
            {
                var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var reviewId=    _reviewsRepo.Insert(new Review
                {

                    DormitoryId = vm.DormitoryId,
                    Rating = vm.RatingNo,
                    IsApproved = true,
                    CreatedOn = DateTime.Now,
                    Message = vm.RatingText,
                    UserId = CurrentUserId

                });

                var dormitoryReviews = (from rev in _reviewsRepo.List().ToList()
                                       where rev.DormitoryId== vm.DormitoryId
                                       group rev by rev.Rating into g
                                       select new
                                       {
                                           
                                           sum = g.Sum(_ => _.Rating),
                                           Count = g.Count(),
                                       }).FirstOrDefault();

                var newRating = dormitoryReviews.sum / dormitoryReviews.Count;

                var dormitory=_dormitoryRepo.GetById(vm.DormitoryId);
                dormitory.RatingNo = newRating;
                _dormitoryRepo.Update(dormitory);

                _eventService.Trigger_Room_RoomReview_Event(reviewId);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string ResolveRatingText(double RatingNumber)
        {
            if (RatingNumber >= 9.5)
            {
                return _localizer["Wonderful"];
            }
            else if (RatingNumber >= 9)
            {
                return _localizer["Fantastic"];

            }
            else if (RatingNumber >= 8.5)
            {
                return _localizer["Excellent"];

            }
            else if (RatingNumber >= 7.5)
            {
                return _localizer["Very Good"];

            }
            else
            {
                return _localizer["Good"];

            }
        }
    }



    public class ReviewsTable
    {

        public long DormitoryId { get;  set; }
        public string Dormitory { get; set; }
        public string User { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime createdOn { get; set; }
        //public string Edit { get; set; }
    }

    public class ReviewInputVm
    {
        public long DormitoryId { get; set; }
        public long RatingNo { get; set; }
        public string RatingText { get; set; }
    }
}
