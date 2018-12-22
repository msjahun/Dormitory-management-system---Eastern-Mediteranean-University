using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
   public class GoodToKnowTitleValue:BaseEntity
    {
        public GoodToKnowTitleValue()
        {
            GoodToKnowTitleValueTranslation = new HashSet<GoodToKonwTitleValueTranslation>();
        }

        public string Icon { get; set; }
       public long GoodToKnowId { get; set; }
        public ICollection<GoodToKonwTitleValueTranslation> GoodToKnowTitleValueTranslation { get; set; }
    }
}
