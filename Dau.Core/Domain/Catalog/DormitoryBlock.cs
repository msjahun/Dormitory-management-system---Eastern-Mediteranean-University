using Dau.Core.Domain.SearchEngineOptimization;

using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public class DormitoryBlock : IBaseSeo
    {//think of this relationship
        public DormitoryBlock()
        { DormitoryBlockTranslations = new HashSet<DormitoryBlockTranslation>();
        }

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


      

        //  public DormitoryBlockContentLocalizedTab[] localizedContent { get; set; }
        //DormitoryBlock Translation

        public ICollection<DormitoryBlockTranslation> DormitoryBlockTranslations{ get; set; }


  // public DormitoryBlockSeoTab[] seoTab { get; set; }
        //relationship with seo Table

        public int SeoId { get; set; }
        public Seo Seo { get; set; }



        //roomsInside a dormitory block, one to many relationship
        //** please treat as urgent important relationship




    }
}
