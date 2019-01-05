using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
    public class CatalogImage:BaseEntity
    {
        public CatalogImage()
        {
            RoomCatalogImage = new HashSet<RoomCatalogImage>();
        }

        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public ICollection<DormitoryCatalogImage> DormitoryCatalogImage { get; set; }
        public ICollection<RoomCatalogImage> RoomCatalogImage { get; set; }
    }
}
