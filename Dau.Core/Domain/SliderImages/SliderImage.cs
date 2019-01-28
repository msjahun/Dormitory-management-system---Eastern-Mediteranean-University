using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.SliderImages
{
 public  class SliderImage:BaseEntity
    {
       
        public string PictureUrl { get; set; }
        public int PictureHeight { get; set; }
        public int PictureWidth { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsVisible { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
