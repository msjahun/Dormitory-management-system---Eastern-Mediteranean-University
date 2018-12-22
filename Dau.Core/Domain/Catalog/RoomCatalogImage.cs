using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class RoomCatalogImage:BaseEntity
    {

        public long RoomId { get; set; }
        public Room Room{ get; set; }

        public long CatalogImageId { get; set; }
        public CatalogImage CatalogImage { get; set; }
    }
}
