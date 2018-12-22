using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class DormitoryCatalogImage:BaseEntity
    {

        public long DormitoryId { get; set; }
        public Dormitory Dormitory { get; set; }

        public long CatalogImageId{ get; set; }
        public CatalogImage CatalogImage{ get; set; }
    }
}
