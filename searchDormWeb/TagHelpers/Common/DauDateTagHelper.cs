using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-date", Attributes = ForAttributeName)]
    public class DauDateTagHelper:TagHelper
    {


        private const string ForAttributeName = "asp-for";
        private const string ValueAttributeName = "value";


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }


        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        

        public string Disabled { get; set; }
        public int Cols { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (Cols > 0 && Cols <= 12)
                output.Attributes.Add("class", "col-sm-" + Cols);
            else
                output.Attributes.Add("class", "col-sm-4");
            output.Content.Clear();

            var inputGroup = new TagBuilder("div");
            inputGroup.Attributes.Add("class", "input-group");

            var disabled = " ";
            if (For.Metadata.IsReadOnly || Disabled == "true")
                disabled = "disabled";
            var input = $"<input class=\"form-control\" {disabled} type=\"Text\" id=\"{For.Name+"DateID"}\" >";
          
            inputGroup.InnerHtml.AppendHtml(input);
          
           
                var iconDiv = new TagBuilder("div");
                iconDiv.Attributes.Add("class", "input-group-addon");
                iconDiv.InnerHtml.AppendHtml($"<i class=\"fa fa-calendar\"></i>");
                inputGroup.InnerHtml.AppendHtml(iconDiv);

          
            
            output.PreContent.SetHtmlContent(inputGroup);


            if (For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
                output.PostContent.SetHtmlContent("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i>");

        }
    }
}
