using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-select", Attributes = ForAttributeName)]
    public class DauSelectTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";
        private const string ItemsAttributeName = "asp-items";


        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { set; get; }

        [HtmlAttributeName(ItemsAttributeName)]
        public List<SelectListItem> Items { set; get; }

       public bool MultipleSelect { set; get; }

       public bool Disabled { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "col-sm-8");
            output.Content.Clear();

            var selectTag = new TagBuilder("select");
            selectTag.Attributes.Add("class", "form-control select2");
            selectTag.Attributes.Add("style=","width: 100%;");
            if (MultipleSelect == true)
                selectTag.Attributes.Add("multiple", "multiple");
            if(Disabled == true||For.Metadata.IsReadOnly)
                selectTag.Attributes.Add("disabled", "true");

            selectTag.Attributes.Add("name", For.Name);
           

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    var OptionTag = new TagBuilder("option");
                    OptionTag.Attributes.Add("value", item.Value);
                    OptionTag.InnerHtml.AppendHtml(item.Text.ToString());
                    if (item.Disabled == true)
                        OptionTag.Attributes.Add("disabled", item.Disabled.ToString());
                    selectTag.InnerHtml.AppendHtml(OptionTag);
                }

             
            }


            output.Content.SetHtmlContent(selectTag);
        }
    }
}
