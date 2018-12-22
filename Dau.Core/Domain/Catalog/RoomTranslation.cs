using Dau.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Catalog
{
    public class RoomTranslation : BaseLanguage
    {
        public string RoomName { get; set; }
        public string GenderAllocation { get; set; }
        public string BedType { get; set; }

        public long RoomNonTransId { get; set; }
        public Room RoomNonTrans { get; set; }
    }
}
