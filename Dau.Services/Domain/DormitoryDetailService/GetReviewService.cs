using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public class GetReviewService : IGetReviewService
    {
        public ReviewButtomSectionViewModel GetReview()
        {
            ReviewButtomSectionViewModel model = new ReviewButtomSectionViewModel
            {
                LatestReview =
                       new CommentSectionViewModel
                       {
                           UserFullName = "Ahmed Bassiouny",
                           UserRatingNo = 8.7,
                           UserImageUrl = "https://scontent-vie1-1.xx.fbcdn.net/v/t1.0-0/p168x128/16472881_1354143061327538_335400885864373680_n.jpg?_nc_cat=104&_nc_ht=scontent-vie1-1.xx&oh=05d8c8f18b5014a974a5b90ff4a7f7ac&oe=5C8647DD",
                           UserComment = "Cras at, tempus viverra turpis..."
                       },
                SignedInUserId = "23243",
                SignedInUserImage = "https://www.facebook.com/search/async/profile_picture/?fbid=100000839361217&width=72&height=72"

            };

            return model;
        }
    }

    public class ReviewButtomSectionViewModel
    {
        public CommentSectionViewModel LatestReview { get; set; }
        public string SignedInUserId { get; set; }
        public string SignedInUserImage { get; set; }
    }
}
