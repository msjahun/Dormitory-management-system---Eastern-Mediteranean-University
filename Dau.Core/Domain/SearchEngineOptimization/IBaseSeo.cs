using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.SearchEngineOptimization
{
  public  interface IBaseSeo
    {
        int SeoId { get; set; }
         Seo Seo{ get; set; }
    }
}
