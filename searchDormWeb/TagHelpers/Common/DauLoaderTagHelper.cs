using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-loader")]
    public class DauLoaderTagHelper:TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //tag details
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Clear();



          

            for (int i = 0; i < 4; i++)
            {
                
                output.PostContent.AppendHtml("<div></div>");
            }

            output.PreElement.SetHtmlContent("<div class=\"text-center mt-5\">");
            output.PostElement.SetHtmlContent("</div>");





            output.Attributes.Add("class", "lds-ring");


        }}
    }
