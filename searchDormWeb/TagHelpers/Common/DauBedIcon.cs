using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-bedicon")]
    public class DauBedIcon : TagHelper
    {

        // <dau-icon-repeater></dau-icon-repeater>
        public string Icon { get; set; }
        public int ReapeatNo { get; set; }





        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //tag details
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Clear();





            for (int i = 0; i < ReapeatNo; i++)
            {
                var icon = new TagBuilder("i");
               if(ReapeatNo >=5)
                    icon.Attributes.Add("class", "fas fa-bed ");
                
      
                
               else if(ReapeatNo >=2)
                    icon.Attributes.Add("class", "fas fa-bed fa-2x");

                else if(ReapeatNo >=1)
                    icon.Attributes.Add("class", "fas fa-bed fa-3x");
                
              

                output.PostContent.AppendHtml(" ");
                output.PostContent.AppendHtml(icon);
            }











        }
    }
}
