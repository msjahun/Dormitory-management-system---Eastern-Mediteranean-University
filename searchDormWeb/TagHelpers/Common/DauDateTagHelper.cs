using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-date", Attributes = ForAttributeName)]
    public class DauDateTagHelper : InputTagHelper
    {


        private const string ForAttributeName = "asp-for";
     

        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }

        public DauDateTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

     
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("class", "form-control date-control");
            output.Attributes.Add("type", "text");
            output.Attributes.Add("id", For.Name + "DateID");

            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }

            output.PreElement.SetHtmlContent("<div class=\"col-sm-8\" >  <div class=\"input-group\">");


            output.PostElement.SetHtmlContent($"<div class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></div></div></div>");

            base.Process(context, output);
        }
    }
}


/*
 

        private const string ForAttributeName = "asp-for";
        private const string ValueAttributeName = "value";


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }


        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public string DateRange { get; set; }

        public string Disabled { get; set; }
        public int Cols { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (Cols > 0 && Cols <= 12)
                output.Attributes.Add("class", "col-sm-" + Cols);
            else
                output.Attributes.Add("class", "col-sm-8 col-md-8 col-lg-4");
            output.Content.Clear();

            var inputGroup = new TagBuilder("div");
            inputGroup.Attributes.Add("class", "input-group");

            var disabled = " ";
            if (For.Metadata.IsReadOnly || Disabled == "true")
                disabled = "disabled";

            var classType = "date-control";
            if (DateRange == "true")
                classType = "date-range-control";
            var input = $"<input class=\"form-control {classType}\" {disabled} type=\"Text\" id=\"{For.Name+"DateID"}\" >";
          
            inputGroup.InnerHtml.AppendHtml(input);
          
           
                var iconDiv = new TagBuilder("div");
                iconDiv.Attributes.Add("class", "input-group-addon");
                iconDiv.InnerHtml.AppendHtml($"<i class=\"fa fa-calendar\"></i>");
                inputGroup.InnerHtml.AppendHtml(iconDiv);

          
            
            output.PreContent.SetHtmlContent(inputGroup);


            //if (For.Metadata.ModelType.IsValueType  && For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
            //    output.PostContent.SetHtmlContent("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i>");
*/
