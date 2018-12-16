using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetCommentsService : IGetCommentsService
    {
        public List<CommentSectionViewModel> GetComments()
        {
            List<CommentSectionViewModel> modelList = new List<CommentSectionViewModel>
            {
                 new CommentSectionViewModel
                {
                    UserFullName = "Ahmed Bassiouny",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://scontent-vie1-1.xx.fbcdn.net/v/t1.0-0/p168x128/16472881_1354143061327538_335400885864373680_n.jpg?_nc_cat=104&_nc_ht=scontent-vie1-1.xx&oh=05d8c8f18b5014a974a5b90ff4a7f7ac&oe=5C8647DD",
                    UserComment = "Cras at, tempus viverra turpis..."
                },
                   new CommentSectionViewModel
                {
                    UserFullName = "Ahmet Önder Beşiroğlu",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100000249531894&width=72&height=72",
                    UserComment = "Cras sitstibulum in vulputate at, tempus viverra turpis...."
                },

                            new CommentSectionViewModel
                {
                    UserFullName = "Abdullahi Ismail",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://avatars3.githubusercontent.com/u/35945225?s=460&v=4",
                    UserComment = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metusras purus odio, vestibulum in vulputate at, tempus viverra turpis."
                },
                     new CommentSectionViewModel
                {
                    UserFullName = "Ivy Thompson",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://avatars0.githubusercontent.com/u/14825113?s=400&v=4",
                    UserComment = "Cras at, tempus viverra turpis..."
                },

              

                         new CommentSectionViewModel
                {
                    UserFullName = "Kamal MG",
                    UserRatingNo = 8.7,
                    UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100001237759702&width=72&height=72",
                    UserComment = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metusras purus odio, vestibulum in vulputate at, tempus viverra turpis."
                }

               
            };
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
