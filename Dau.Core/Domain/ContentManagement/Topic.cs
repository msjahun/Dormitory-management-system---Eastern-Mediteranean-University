using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.ContentManagement
{
    class Topic
    {
        //  public LocalizedTopicsContent[] localizedTopicsContents { get; set; }
        //TopicTranslation 

        public string SystemName { get; set; }


        public bool Published { get; set; }

        public bool PasswrodProtected { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool IncludeInFooterColumn1 { get; set; }

        public bool IncludeInFooterColumn2 { get; set; }

        public bool IncludeInFooterColumn3 { get; set; }

        public bool IncludeInSitemap { get; set; }

        public IEnumerable<int> CustomerRoles { get; set; }

        public IEnumerable<int> LimtedToDormitory { get; set; }

        public int DisplayOrder { get; set; }

        public bool AccessileWhenSiteIsClosed { get; set; }

        // public TopicsSeoTab[] seoTab { get; set; }
        //seo table





    }
}
