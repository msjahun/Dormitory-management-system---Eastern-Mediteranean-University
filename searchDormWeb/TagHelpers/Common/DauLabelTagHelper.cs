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
    [HtmlTargetElement("dau-label", Attributes = ForAttributeName)]
    public class DauLabelTagHelper : TagHelper
    {
        //<dau-label></dau-label>
        private const string ForAttributeName = "asp-for";
        public string Hint { get; set; }


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //tag details
            output.TagName = "label";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Clear();


            if(For.Metadata.DisplayName!=null)
            output.Content.Append(For.Metadata.DisplayName);
            else
                output.Content.Append(For.Name);

            if (For.Metadata.Description != null) { 

            var hint = new TagBuilder("i");
            hint.Attributes.Add("class", "fa fa-question-circle");
            hint.Attributes.Add("style", "color:#134b88;");
            hint.Attributes.Add("data-toggle", "tooltip");
            hint.Attributes.Add("data-placement", "bottom");
            hint.Attributes.Add("title", For.Metadata.Description);
            hint.Attributes.Add("aria-hidden", "true");
            output.PostContent.AppendHtml(" ");
            output.PostContent.AppendHtml(hint);
            }


            output.Attributes.Add("class", "col-sm-3 control-label");
            output.Attributes.Add("id", For.Name+"_id");
            output.Attributes.Add("name", For.Name);
            output.Attributes.Add("for", For.Name);
            
           
        }
    }

 
}
