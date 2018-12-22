using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public class GetReviewService : IGetReviewService
    {
        private IRepository<Review> _reviewRepo;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signedInManager;

        public GetReviewService(
            IRepository<Review> ReviewRepository,
            UserManager<User> userManager,
          IHttpContextAccessor httpContextAccessor)
        {
            _reviewRepo = ReviewRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ReviewButtomSectionViewModel GetReview(long DormitoryId)
        {

            var reviews = from _review in _reviewRepo.List().ToList()
                          where _review.DormitoryId == DormitoryId
                          select new { _review.UserId, _review.Message, _review.Rating };
            var lastComment = new CommentSectionViewModel();

            if (reviews.Count() >0) { 

            var review = reviews.Last();

            var LastReviewUsers = from user in _userManager.Users.ToList()
                                  where user.Id == review.UserId
                                  select user;
            var LastReviewUser = LastReviewUsers.FirstOrDefault();

                lastComment = new CommentSectionViewModel
                {
                    UserFullName = LastReviewUser.FirstName + " " + LastReviewUser.LastName,
                    UserRatingNo = review.Rating,
                    UserImageUrl = LastReviewUser.UserImageUrl,
                    UserComment = review.Message
                };

            }
            else {

                lastComment = null;
            }

            var SignedInUserModel = new ReviewCurrentUserViewModel();


            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) { 
            var SignedInUser = from user in _userManager.Users.ToList()
                               where user.Id == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                               select user;
            var SignedInUserFullName = SignedInUser.FirstOrDefault().FirstName + " " + SignedInUser.FirstOrDefault().LastName;
            var SignedInUserImage = SignedInUser.FirstOrDefault().UserImageUrl;
            var SignedInUserId = SignedInUser.FirstOrDefault().Id;

            SignedInUserModel = new ReviewCurrentUserViewModel
            {
                SignedInUserId = SignedInUserId,
                SignedInUserImage = SignedInUserImage,
                SignedInUserName = SignedInUserFullName
            };

            }else
            {
                SignedInUserModel = null;
            }

            ReviewButtomSectionViewModel Reviewsmodel = new ReviewButtomSectionViewModel
            {
                LatestReview = lastComment,
                CurrentUser = SignedInUserModel

            };


            ReviewButtomSectionViewModel model = Reviewsmodel;
            return model;
        }
    }

    public class ReviewButtomSectionViewModel
    {
        public CommentSectionViewModel LatestReview { get; set; }
        public ReviewCurrentUserViewModel CurrentUser { get; set; }
    }

    public class ReviewCurrentUserViewModel
    {
        public string SignedInUserId { get; set; }
        public string SignedInUserImage { get; set; }
        public string SignedInUserName { get; set; }
    }
}
