using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.SearchEngineOptimization
{
   public class Seo
    {
        public Seo()
        {
            DormitoryBlocks = new HashSet<DormitoryBlock>();
            Topics = new HashSet<Topic>();

        }

        public int Id { get; set; }
        public string MetaKeywords { get; set; }


        public string MetaDescription { get; set; }


        public string MetaTitle { get; set; }


        public string SearchEngineFriendlyPageName { get; set; }

        public ICollection<DormitoryBlock> DormitoryBlocks{ get; set; }
        public ICollection<Topic> Topics{ get; set; }

       
    }
}
