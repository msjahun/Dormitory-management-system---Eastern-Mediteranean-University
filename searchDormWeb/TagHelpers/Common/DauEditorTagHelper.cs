using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-editor", Attributes = ForAttributeName)]
    public class DauEditorTagHelper : TextAreaTagHelper
    {

        private const string ForAttributeName = "asp-for";
        public DauEditorTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";
            output.TagMode = TagMode.StartTagAndEndTag;

           
            output.Attributes.Add("id", For.Name + "Id");

            output.PreElement.SetHtmlContent("<div class=\"col-sm-9\">");
            output.PostElement.SetHtmlContent("</div>");
            base.Process(context, output);
            //if (For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
            //    output.PostElement.AppendHtml("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i></div>");
        }
    }
}
