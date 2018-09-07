using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-input", Attributes = ForAttributeName)]
    public class DauInputTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";
        private const string ValueAttributeName = "value";


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }


        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public string Type { get; set; }

        public string Disabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "col-sm-8");
            output.Content.Clear();
            var disabled = " ";
             disabled = (Disabled == "true")?"disabled": " ";

            if (For.Metadata.IsReadOnly)
                disabled = "disabled";
            var input = $"<input class=\"form-control\" {disabled} type=\"{Type}\" >";
           

            output.PreContent.SetHtmlContent(input);
          
   

            if (For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
            output.PostContent.SetHtmlContent("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i>");
           
        }
    }
}
