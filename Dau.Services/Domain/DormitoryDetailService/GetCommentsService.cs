﻿using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.TimeServices;
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
        private readonly ITimeService _timeService;

        public GetCommentsService(
             IRepository<Review> ReviewRepository,
            UserManager<User> userManager,
            ITimeService timeService)
        {
            _reviewRepo = ReviewRepository;
            _userManager = userManager;
            _timeService = timeService;
        }

        public List<CommentSectionViewModel> GetComments(long DormitoryId)
        {


            var reviews = from _review in _reviewRepo.List().ToList()
                          where _review.DormitoryId == DormitoryId
                          select new { _review.UserId, _review.Message, _review.Rating, _review.CreatedOn };

                var ReviewUsers = from user in _userManager.Users.ToList()
                                      join review in reviews.ToList() on user.Id equals review.UserId
                                      orderby review.CreatedOn descending
                                      select new CommentSectionViewModel
                                      {
                                          UserFullName = user.FirstName + " " + user.LastName,
                                          UserRatingNo = review.Rating,
                                          UserImageUrl = user.UserImageUrl,
                                          UserComment = review.Message,
                                          ReviewDate = _timeService.TimeAgo( review.CreatedOn)
                                      };


            List<CommentSectionViewModel> modelList = ReviewUsers.Take(20).ToList();
            return modelList;
        }
    }


    public class CommentSectionViewModel
    {
        public string ReviewDate { get; set; }
        public string UserFullName { get; set; }
        public string UserImageUrl { get; set; }
        public string UserComment { get; set; }
        public double UserRatingNo { get; set; }
    }

}
