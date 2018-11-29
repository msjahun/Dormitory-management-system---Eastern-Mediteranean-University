using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.CountryInformation
{
  public  class StateAndProvince
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }


        public Country Country{ get; set; }
    }
}
