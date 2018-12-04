using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class RoomReviewsVm
    {

        [Display(Name = "Created from",
       Description = "The creation from date for the search."),
       DataType(DataType.Date),
       MaxLength(256)]
        public DateTime CreatedFrom { get; set; }


        [Display(Name = "Created to",
     Description = "The creatino to date fro the serach."),
     DataType(DataType.Date),
     MaxLength(256)]
        public DateTime CreatedTo { get; set; }

        [Display(Name = "Message",
     Description = "Message."),
     DataType(DataType.Text),
     MaxLength(256)]
        public string Message { get; set; }

        [Display(Name = "Approved",
     Description = "Search by an approved status e.g. Approved or Not approved"),
     MaxLength(256)]
        public int Approved { get; set; }

        [Display(Name = "Room",
       Description = "A room name."),
       DataType(DataType.Text),
       MaxLength(256)]
        public string RoomName { get; set; }

    }


    public class ReviewEdit
    {
        [Display(Name = "Room",
        Description = "The name of the room that the review is for."), DataType(DataType.Text), MaxLength(256)]
        public string Room { get; set; }


        [Display(Name = "Dormitory",
                Description = "A dormitory name in which this review was written."), DataType(DataType.Text), MaxLength(256)]
        public string Dormitory { get; set; }


        [Display(Name = "Cutomer",
                Description = "The customer who created the review."), DataType(DataType.Text), MaxLength(256)]
        public string Cutomer { get; set; }


        [Display(Name = "Title",
                Description = "The title of the room review."), DataType(DataType.Text), MaxLength(256)]
        public string Title { get; set; }


        [Display(Name = "Review Text",
                Description = "The review text."), DataType(DataType.Text), MaxLength(256)]
        public string ReviewText { get; set; }


        [Display(Name = "Reply Text",
                Description = "The reply text(by a dormitory manager). If specified, then it'll be visible to a customer. Leave empty to ignore this functionality."), DataType(DataType.Text), MaxLength(256)]
        public string ReplyText { get; set; }


        [Display(Name = "Rating",
        Description = "The customer's room rating."), DataType(DataType.Text), MaxLength(256)]
        public string Rating { get; set; }


        [Display(Name = "Is Approved",
        Description = "Is the review approved? Marking it as approved means that it is visible to all your site's visitors.")]
        public bool isApproved { get; set; }



        [Display(Name = "Created On",
        Description = "The date/time that the review was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

    }
}
