using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class Dormitory:BaseEntity, IBaseSeo
    {
        public Dormitory()
        {
            DormitoryFeatures = new HashSet<DormitoryFeatures>();
            DormitoryCatalogImage = new HashSet<DormitoryCatalogImage>();
            DormitoryTranslation = new HashSet<DormitoryTranslation>();
            DormitoryBlocks = new HashSet<DormitoryBlock>();
    }
        //create a DormitoryType Table
      
        public int NoOfStudents { get; set; }
        public double RatingNo { get; set; }
        public int ReviewNo { get; set; }


        public string Location { get; set; }
        public string SKU { get; set; }

        public int NoOfNewFacilities { get; set; }
        public int NoOfStaff { get; set; }
        public int NoOfAwards { get; set; }

        public string MapSection { get; set; }
        public string DormitoryStreetAddress { get; set; }

        //public string DormitoryType { get; set; }//should be tableLized

        public string DormitoryLogoUrl { get; set; }
       
        
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public GoodToKnow GoodToKnowInfo { get; set; }

        public long SeoId { get; set; }
        public Seo Seo { get; set; }
        public ICollection<Review> Reviews { get; set; }


        public ICollection<Room> Rooms { get; set; }
        public ICollection<DormitoryBlock> DormitoryBlocks { get; set; }
        public List<Locationinformation> CloseLocations { get; set; }

        public ICollection<DormitoryFeatures> DormitoryFeatures { get; set; }

        public ICollection<DormitoryCatalogImage> DormitoryCatalogImage { get; set; }
        public ICollection<DormitoryTranslation> DormitoryTranslation{ get; set; }

        public DormitoryType DormitoryType{ get; set; }
        public long DormitoryTypeId{ get; set; }



    }



    
    public class Locationinformation:BaseEntity
    {
        public long DormitoryId { get; set; }
        public string NameOfLocation { get; set; }
        public string Distance { get; set; }
        public string MapSection { get; set; }
        public string Duration { get; set; }
    }




    public class OpeningClosingTime:BaseEntity
    {
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
    }




 
}
