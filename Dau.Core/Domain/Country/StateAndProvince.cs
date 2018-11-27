using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Country
{
  public  class StateAndProvince
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Published { get; set; }
        public string DisplayOrder { get; set; }


        public Country Country{ get; set; }
    }
}
