using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Room
{
    public partial class RoomTableTranslation : BaseLanguage
    {
       
        public int RoomTableNonTransId { get; set; }
        public string RoomType { get; set; }
        public string RoomTitle { get; set; }

     
        public RoomTable RoomTableNonTrans { get; set; }
    }
}
