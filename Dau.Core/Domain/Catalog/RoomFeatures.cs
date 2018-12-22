using Dau.Core.Domain.Feature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class RoomFeatures:BaseEntity
    {

        public long RoomId { get; set; }
        public Room Room{ get; set; }

        public long FeaturesId { get; set; }
        public Features Features { get; set; }
    }
}
