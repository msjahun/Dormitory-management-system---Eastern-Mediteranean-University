using Dau.Core.Domain.EmuMap;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.LocationInformations;
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


    
        public string SKU { get; set; }

        public int NoOfNewFacilities { get; set; }
        public int NoOfStaff { get; set; }
        public int NoOfAwards { get; set; }

     //   public string MapSection { get; set; }
    public long MapSectionId { get; set; }
        public MapSection MapSection { get; set; }
        public string DormitoryStreetAddress { get; set; }

        //public string DormitoryType { get; set; }//should be tableLized

        public string DormitoryLogoUrl { get; set; }
       
        
        public bool Published { get; set; }
        
        public DateTime WeekendsOpeningTime { get; set; }
        public DateTime WeekendsClosingTime { get; set; }
        public DateTime WeekdaysOpeningTime { get; set; }
        public DateTime WeekdaysClosingTime { get; set; }

        public long SeoId { get; set; }
        public Seo Seo { get; set; }
        public ICollection<Review> Reviews { get; set; }

      
     public int BookingLimit { get; set; }//1year, 1 semester
             
        public int LocationOnCampus { get; set; }//need to create tables for this
        public string AdminComment { get; set; }
              public DateTime  CreatedOn {get; set;}
              public DateTime UpdatedOn { get; set; }
              
        public int CancelWaitDays { get; set; }
               public bool MarkAsNew { get; set; }
               public bool AllowReviewsWithBookingOnly { get; set; }
               public bool OpenedOnSundays { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<DormitoryBlock> DormitoryBlocks { get; set; }
        public List<Locationinformation> CloseLocations { get; set; }

        public ICollection<DormitoryFeatures> DormitoryFeatures { get; set; }

        public ICollection<DormitoryCatalogImage> DormitoryCatalogImage { get; set; }
        public ICollection<DormitoryTranslation> DormitoryTranslation{ get; set; }

        public DormitoryType DormitoryType{ get; set; }
        public long DormitoryTypeId{ get; set; }



    }



    




    



 
}
