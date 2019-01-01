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

    //I'll be using this for testing
    [HtmlTargetElement("dau-datesdfsdfs", Attributes = ForAttributeName)]
    public class MyCustomTextArea : SelectTagHelper
    {
        private const string ForAttributeName = "asp-for";
      

        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }

        

        public bool MultipleSelect { set; get; }

        public bool Disabled { set; get; }

        public MyCustomTextArea(IHtmlGenerator generator) : base(generator)
        {
        }
        

        public override void Process(TagHelperContext context, TagHelperOutput output) { 
        output.TagName = "select";

            output.Attributes.Add("class", "form-control select2");
            output.Attributes.Add("data-width", "100%");
            if (MultipleSelect == true)
                output.Attributes.Add("multiple", "multiple");
            if (Disabled == true || For.Metadata.IsReadOnly)
                output.Attributes.Add("disabled", "true");


   

            output.PreElement.SetHtmlContent("<div class=\"col-sm-8\" > ");
            

                output.PostElement.SetHtmlContent($"</div>");

            

            base.Process(context, output);
        }
    }
}
