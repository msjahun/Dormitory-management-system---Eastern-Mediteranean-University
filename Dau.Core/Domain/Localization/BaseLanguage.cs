using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Localization

{
    public abstract partial class BaseLanguage :BaseEntity
    {//all translation classes should inherit form this class
        public long LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
