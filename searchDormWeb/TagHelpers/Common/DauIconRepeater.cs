using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-icon-repeater")]
    public class DauIconRepeater : TagHelper
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



          

            for (int i = 0; i < ReapeatNo; i ++)
            {
                var icon = new TagBuilder("i");
                if (Icon == null) {
                icon.Attributes.Add("class", "fas fa-male fa-2x");
                }
                else
                {
                    icon.Attributes.Add("class", "fas "+Icon);

                }

                output.PostContent.AppendHtml(" ");
                output.PostContent.AppendHtml(icon);
            }







    



        }
    }
}
