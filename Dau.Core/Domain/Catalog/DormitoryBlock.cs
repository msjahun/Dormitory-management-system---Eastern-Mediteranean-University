using Dau.Core.Domain.SearchEngineOptimization;

using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public class DormitoryBlock : BaseEntity, IBaseSeo
    {//think of this relationship
        public DormitoryBlock()
        { DormitoryBlockTranslations = new HashSet<DormitoryBlockTranslation>();
        }

     

        public string Name { get; set; }


      public string Description { get; set; }


       public string PictureUrl { get; set; }

      // public string priceRange { get; set; }
      //price range should be calculated, or you should store price min and price max
      //Consider removing this from the view
      //the service should calculate this
           

        public bool IncludeInTopMenu { get; set; }

       //I think all these IEnumerable are probably many to many Tables
       //change IEnumerable to ICollection and Create a link to a table

       //public IEnumerable<int> Discount { get; set; }

       // public IEnumerable<int> LimitedToCustomerRoles { get; set; }

       // public IEnumerable<int> LimitToDormitories { get; set; }

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
