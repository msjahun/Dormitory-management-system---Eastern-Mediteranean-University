using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
    class DormitoryBlock
    {//think of this relationship


      public string Name { get; set; }


      public string Description { get; set; }


       public string Picture { get; set; }

       public string priceRange { get; set; }

        public bool IncludeInTopMenu { get; set; }

       public IEnumerable<int> Discount { get; set; }

        public IEnumerable<int> LimitedToCustomerRoles { get; set; }

        public IEnumerable<int> LimitToDormitories { get; set; }

       public bool Published { get; set; }

        public int DisplayOrder { get; set; }


       // public DormitoryBlockSeoTab[] seoTab { get; set; }
       //relationship with seo


      //  public DormitoryBlockContentLocalizedTab[] localizedContent { get; set; }
      //DormitoryBlock Translation

   




    }
}
