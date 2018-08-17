using Dau.Core.Domain.Language;
using System;
using System.Collections.Generic;

namespace Dau.Core.Domain.Room
{
    public partial class RoomTableTranslation
    {
        public int LanguageId { get; set; }
        public int RoomTableNonTransId { get; set; }
        public string RoomType { get; set; }
        public string RoomTitle { get; set; }

        public LanguageTable Language { get; set; }
        public RoomTable RoomTableNonTrans { get; set; }
    }
}
