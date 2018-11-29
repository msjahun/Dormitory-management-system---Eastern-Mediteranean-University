using Dau.Core.Domain.SearchEngineOptimization;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dau.Core.Domain.ContentManagement
{
    public class Topic :IBaseSeo
    {
        public Topic()
        {TopicTranslations = new HashSet<TopicTranslation>();
        }



        public int Id { get; set; }

        public string Name { get; set; }
        public string SystemName { get; set; }


        public bool Published { get; set; }

        public bool PasswordProtected { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool IncludeInFooterColumn1 { get; set; }

        public bool IncludeInFooterColumn2 { get; set; }

        public bool IncludeInFooterColumn3 { get; set; }

        public bool IncludeInSitemap { get; set; }

     //   public IEnumerable<int> CustomerRoles { get; set; }

      //  public IEnumerable<int> LimtedToDormitory { get; set; }
      //Icollection Issue that needs solving, relationship issue

        public int DisplayOrder { get; set; }

        public bool AccesibleWhenSiteIsClosed { get; set; }

       

        //  public LocalizedTopicsContent[] localizedTopicsContents { get; set; }
        //TopicTranslation 

        public ICollection<TopicTranslation> TopicTranslations { get; set; }
 
        
        
        // public TopicsSeoTab[] seoTab { get; set; }
        //seo table

        public int SeoId { get; set; }
        public Seo Seo { get; set; }
    }
}
