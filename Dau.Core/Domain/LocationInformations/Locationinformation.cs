using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.EmuMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.LocationInformations
{

    public class Locationinformation : BaseEntity
    {
        public long DormitoryId { get; set; }
        public Dormitory Dormitory { get; set; }

        //public string NameOfLocation { get; set; } //mapsection has the names,
        //Dormitory has it's own location and gps coordinates
        
        public string DistanceText { get; set; }
        public string DurationText { get; set; }

        public int DistanceValue { get; set; }
        public int DurationValue { get; set; }



        public MapSection MapSection { get; set; }
        public long MapSectionId { get; set; }

        public DateTime CreateDate { get; set; }
       
    }
}
