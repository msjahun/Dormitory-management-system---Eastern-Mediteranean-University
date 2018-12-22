using Dau.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public  class Review :BaseEntity
    {
       public long DormitoryId { get; set; }
       public Dormitory Dormitory { get; set; }
      //  public string ReviewText { get; set; } ReviewText a service should generate that
        public double Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

        
    }


}
