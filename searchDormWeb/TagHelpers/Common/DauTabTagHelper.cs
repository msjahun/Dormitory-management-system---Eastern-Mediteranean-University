using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-tab", ParentTag = "dau-tabs")]
    public class DauTabTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string Id{ get; set; }
        public bool Active { get; set; }
        public string Flag { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var childContent = await output.GetChildContentAsync();

            //add to context
            var tabContext = (List<ModalContext>)context.Items[typeof(DauTabsTagHelper)];
            tabContext.Add(new ModalContext()
            {
                TabId =Id,
                TabContent = childContent,
                IsDefault=Active,
                Flag = Flag,
                DisplayName=Name
                
            });

            //generate nothing
            output.SuppressOutput();
            //output is suppressed so that we don't have any content rendered
            output.SuppressOutput();
           
        }
    }
}
