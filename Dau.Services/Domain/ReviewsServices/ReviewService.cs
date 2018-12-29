using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.ReviewsServices
{
   public class ReviewService : IReviewService
    {
        private readonly ILanguageService _languageService;
        private readonly IRepository<Review> _reviewsRepo;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;

        public ReviewService(IRepository<Review> reviewsRepository,
            UserManager<User> userManager,
             IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
              ILanguageService languageService)
        {
            _languageService = languageService;
            _reviewsRepo =reviewsRepository;
            _userManager =userManager;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
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

                              Dormitory = dormitory.ToList().Where(c=> c.Id == review.DormitoryId).FirstOrDefault().DormitoryName,
                              User = _userManager.Users.ToList().Where(c=> c.Id == review.UserId).FirstOrDefault().UserName,
                              ReviewText = review.Message,
                              Rating = review.Rating.ToString("N1"),
                              IsApproved = review.IsApproved,
                              createdOn = review.CreatedOn
                          };



            var model = reviews.ToList();


            return model;
        }

    }



    public class ReviewsTable
    {

        public string Dormitory { get; set; }
        public string User { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime createdOn { get; set; }
        //public string Edit { get; set; }
    }
}
