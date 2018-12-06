using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Language
{
    public abstract partial class BaseLanguage 
    {//all translation classes should inherit form this class
        public long LanguageId { get; set; }
        public LanguageTable Language { get; set; }
    }
}
