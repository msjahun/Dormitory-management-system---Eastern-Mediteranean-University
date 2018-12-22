using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public  class DormitoryTranslation : BaseLanguage
    {
        public string DormitoryName { get; set; }
        public string DormitoryDescription { get; set; }
        public string RatingText { get; set; }


        public string Option { get; set; }//staff
        public string OptionValue { get; set; }//staff are very friendly
        public string StandAloneOption { get; set; }//has a gym!


        public string LocationRemark { get; set; }

        public long DormitoryNonTransId { get; set; }
        public Dormitory DormitoryNonTrans { get; set; }
    }



}
