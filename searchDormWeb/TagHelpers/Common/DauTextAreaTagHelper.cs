using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-textarea")]
    public class DauTextAreaTagHelper : TextAreaTagHelper
    {
       
        public DauTextAreaTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "form-control");
            output.Attributes.Add("id", For.Name + "_id");
            output.Attributes.Add("rows","10");
            output.Attributes.Add("cols", "80");
        
            output.PreElement.SetHtmlContent("<div class=\"col-sm-9\">");
            output.PostElement.SetHtmlContent("</div>");

            //if (For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
            //    output.PostElement.AppendHtml("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i>");
        }
    }
}
