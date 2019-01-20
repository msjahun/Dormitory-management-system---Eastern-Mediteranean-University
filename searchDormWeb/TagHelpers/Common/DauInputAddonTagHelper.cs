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
    [HtmlTargetElement("dau-inputaddon", Attributes = ForAttributeName)]
    public class DauInputAddonTagHelper:InputTagHelper
    {

        private const string ForAttributeName = "asp-for";
        public string Type { get; set; }
        public string Text { get; set; }

        public string Disabled { get; set; }
        public string AddonType { get; set; }
        public string Icon { get; set; }
        public int Cols { get; set; }

        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }

        public DauInputAddonTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        /*   <div class="col-sm-4">
                  <div class="input-group">
                      <input type="number" class="form-control" min="0" value="0.00" step="1.00">
                      <span class="input-group-addon">USD</span>
                  </div>
              </div>*/

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("class", "form-control");

            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }

            output.PreElement.SetHtmlContent("<div class=\"col-sm-8\" >  <div class=\"input-group\">");


            if (AddonType == "button")
            {
                var ButtonId = For.Name + "Btn";
                output.PostElement.SetHtmlContent($"<span class=\"input-group-btn\"><button type=\"button\" Id=\"{ButtonId}\" class=\"btn btn-info btn-flat\">{Text}</button></span></div></div>");

            }
            else if (AddonType == "icon")
            {
                output.PostElement.SetHtmlContent($"<div class=\"input-group-addon\"><i class=\"{Icon}\"></i></div></div></div>");

            }
            else

                output.PostElement.SetHtmlContent($"<span class=\"input-group-addon\">{Text}</span></div></div>");






            base.Process(context, output);
        }


    }
}
//<div min = "0" class="col-sm-4">
//<div class="input-group">
//<input class="form-control" name="Price" for="Price" type="number">
//    <span class="input-group-addon">TRY</span>
//    </div>
//    </div>


    /*
     
        private const string ForAttributeName = "asp-for";
        private const string ValueAttributeName = "value";


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }


        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public string Type { get; set; }
        public string Text { get; set; }

        public string Disabled { get; set; }
        public string AddonType { get; set; }
        public string Icon { get; set; }
        public int Cols { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            if(Cols >0 && Cols <=12)
                output.Attributes.Add("class", "col-sm-"+Cols);
            else
            output.Attributes.Add("class", "col-sm-8");
            output.Content.Clear();

            var inputGroup = new TagBuilder("div");
            inputGroup.Attributes.Add("class", "input-group");

            var disabled = " ";
            if (For.Metadata.IsReadOnly || Disabled == "true")
                disabled = "disabled";



            var input = $"<input class=\"form-control\" name=\"{ For.Name }\" for=\"{ For.Name }\" {disabled} type=\"{Type}\" >";
            inputGroup.InnerHtml.AppendHtml(input);



            if (AddonType == "button")
            {
                var btnSpan = new TagBuilder("span");
                btnSpan.Attributes.Add("class", "input-group-btn");
                btnSpan.InnerHtml.AppendHtml($"<button type=\"button\" class=\"btn btn-info btn-flat\">{Text}</button>");
                inputGroup.InnerHtml.AppendHtml(btnSpan);

            }
            else if (AddonType=="icon") {
                var iconDiv = new TagBuilder("div");
                iconDiv.Attributes.Add("class", "input-group-addon");
                iconDiv.InnerHtml.AppendHtml($"<i class=\"{Icon}\"></i>");
                inputGroup.InnerHtml.AppendHtml(iconDiv);

            }
            else
            inputGroup.InnerHtml.AppendHtml($"<span class=\"input-group-addon\">{Text}</span>");

            output.PreContent.SetHtmlContent(inputGroup);
           

            if (For.Metadata.IsRequired && !For.Metadata.IsReadOnly)
                output.PostContent.SetHtmlContent("</div><div><i class=\"required hidden-xs \" style=\"color:red; \">*</i>");
     */