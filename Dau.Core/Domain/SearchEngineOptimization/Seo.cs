using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.SearchEngineOptimization
{
   public class Seo : BaseEntity
    {
        public Seo()
        {
            DormitoryBlocks = new HashSet<DormitoryBlock>();
            Topics = new HashSet<Topic>();
            Rooms = new HashSet<Room>();
            Dormitories = new HashSet<Dormitory>();

        }

        public string MetaKeywords { get; set; }


        public string MetaDescription { get; set; }


        public string MetaTitle { get; set; }


        public string SearchEngineFriendlyPageName { get; set; }

        public ICollection<Room> Rooms{ get; set; }
        public ICollection<Dormitory> Dormitories{ get; set; }

        public ICollection<DormitoryBlock> DormitoryBlocks{ get; set; }
        public ICollection<Topic> Topics{ get; set; }

       
    }
}
