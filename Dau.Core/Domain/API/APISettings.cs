using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.API
{
  public  class APISettings : BaseEntity
    {//think of this tables relationship
        //set first and read first

    
        public bool EnableAPI { get; set; }
        public bool AllowRequestsFromSwagger { get; set; }
    }
}
