using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetCommentsService : IGetCommentsService
    {
        private readonly IRepository<Review> _reviewRepo;
        private readonly UserManager<User> _userManager;

        public GetCommentsService(
             IRepository<Review> ReviewRepository,
            UserManager<User> userManager)
        {
            _reviewRepo = ReviewRepository;
            _userManager = userManager;
        }

        public List<CommentSectionViewModel> GetComments(long DormitoryId)
        {


            var reviews = from _review in _reviewRepo.List().ToList()
                          where _review.DormitoryId == DormitoryId
                          select new { _review.UserId, _review.Message, _review.Rating };

                var ReviewUsers = from user in _userManager.Users.ToList()
                                      join review in reviews.ToList() on user.Id equals review.UserId
                                      select new CommentSectionViewModel
                                      {
                                          UserFullName = user.FirstName + " " + user.LastName,
                                          UserRatingNo = review.Rating,
                                          UserImageUrl = user.UserImageUrl,
                                          UserComment = review.Message
                                      };


            List<CommentSectionViewModel> modelList = ReviewUsers.ToList();
            return modelList;
        }
    }


    public class CommentSectionViewModel
    {
        public string UserFullName { get; set; }
        public string UserImageUrl { get; set; }
        public string UserComment { get; set; }
        public double UserRatingNo { get; set; }
    }

}
