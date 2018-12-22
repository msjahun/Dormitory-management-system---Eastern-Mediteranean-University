using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class Room : BaseEntity, IBaseSeo
    {
        public Room()
        {
            RoomCatalogImage = new HashSet<RoomCatalogImage>();
             RoomTranslation = new HashSet<RoomTranslation>();
            RoomFeatures = new HashSet<RoomFeatures>();
        }
       
      
        public int NoOfStudents { get; set; }

      
        public int RoomsQuota { get; set; }
        public bool HasDeposit { get; set; }
        public bool ShowPrice { get; set; }
        public DormitoryBlock DormitoryBlock { get; set; }

        public long DormitoryId { get; set; }
        public Dormitory Dormitory { get; set; }
        public double Price { get; set; }
        public double PriceOld { get; set; }
        public int NoRoomQuota { get; set; }

        public ICollection<RoomCatalogImage> RoomCatalogImage { get; set; }
        public ICollection<RoomFeatures> RoomFeatures { get; set; }

  
        public Seo Seo { get; set; }

        public ICollection<RoomTranslation> RoomTranslation{ get; set; }

        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
    }

 
}
