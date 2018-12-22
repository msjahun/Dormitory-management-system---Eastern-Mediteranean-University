using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
  public  class GoodToKonwTitleValueTranslation : BaseLanguage
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public long GoodToKnowTitleValueNonTransId { get; set; }
        public GoodToKnowTitleValue GoodToKnowTitleValueNonTrans { get; set; }
    }
}
