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
    [HtmlTargetElement("dau-input", Attributes = ForAttributeName)]
    public class DauInputTagHelper : InputTagHelper
    {

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }

        public DauInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("class", "form-control");

            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }
            output.PreElement.SetHtmlContent("<div class=\"col-sm-8\" >");
            output.PostElement.SetHtmlContent("</div>");
            base.Process(context, output);
        }

    }
}



/*
 private const string ForAttributeName = "asp-for";
        private const string ValueAttributeName = "value";


       

        public DauInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

       

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
     */
