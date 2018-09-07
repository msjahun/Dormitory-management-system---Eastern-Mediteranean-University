using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    public class DauEditorTagHelper : TextAreaTagHelper
    {
        public DauEditorTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";
            output.TagMode = TagMode.StartTagAndEndTag;

           
            output.Attributes.Add("id", For.Name + "Id");
        
            
        }
    }
}
