﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.API
{
    class APISettings
    {//think of this tables relationship
        //set first and read first

     
        public bool EnableAPI { get; set; }


 
        public bool AllowRequestsFromSwagger { get; set; }
    }
}