using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public  class Review
    {
        //relationship with users class
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int DormitoryId { get; set; }
        public string UserGuid{ get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string ReplyText { get; set; }
        public double Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }


      //  public int Approved { get; set; }
      //Approved here is totally uncessary since we have IsApproved

        //  public string RoomName { get; set; }

        // public DateTime CreatedFrom { get; set; }


        // public DateTime CreatedTo { get; set; }

    }

}
