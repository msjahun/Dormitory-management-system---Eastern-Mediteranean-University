using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain
{
  public  class ApiDebugLog :BaseEntity
    {

        public string ParameterRecieved { get; set; }
        public string ApiName { get; set; }
        public string Reponse { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
