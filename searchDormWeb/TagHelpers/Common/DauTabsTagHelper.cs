using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace searchDormWeb.TagHelpers.Common
{
    [RestrictChildren("dau-tab")]
    public class DauTabsTagHelper:TagHelper
    {
       

        //modal context typeof itself, but this time a modalContext parameter is passed
        //probably context.Items is a shared tagHelper memory space or something
     public string Id { get; set; }

public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var tabContext = new List<ModalContext>();
            context.Items.Add(typeof(DauTabsTagHelper), tabContext);
            await output.GetChildContentAsync();


            var navTabsCustom = new TagBuilder("div");
            navTabsCustom.Attributes.Add("class", "nav-tabs-custom");

            var ulNavTabs = new TagBuilder("ul");
            ulNavTabs.Attributes.Add("class", "nav nav-tabs");

            foreach (var tab in tabContext)
            { var isActive = (tab.IsDefault == true) ? "active" : "";
                var imgTag = "";
                if (tab.Flag!=null)
               imgTag =$"<img alt=\"\" src=\"{tab.Flag}\">";

                var DisplayName = tab.TabId;
                if (tab.DisplayName != null)
                    DisplayName = tab.DisplayName;
                ulNavTabs.InnerHtml.AppendHtml($"<li class=\"{isActive }\"><a href=\"#{Id+tab.TabId}\" data-toggle=\"tab\" aria-expanded=\"false\">{imgTag} {DisplayName}</a></li>");

            }
            navTabsCustom.InnerHtml.AppendHtml(ulNavTabs);

            var tabContent = new TagBuilder("div");
            tabContent.Attributes.Add("class", "tab-content");


            foreach (var tab in tabContext)
            {
                var tabPane = new TagBuilder("div");
                var isActive = (tab.IsDefault == true) ? "active" : "";
                tabPane.Attributes.Add("class", $"tab-pane {isActive}");
               

                tabPane.Attributes.Add("id", Id + tab.TabId);
                tabPane.InnerHtml.AppendHtml(tab.TabContent);

                tabContent.InnerHtml.AppendHtml(tabPane);
            }

            navTabsCustom.InnerHtml.AppendHtml(tabContent);

            output.Content.SetHtmlContent(navTabsCustom);

            
        }
    }


    public class ModalContext
    {
        public bool IsDefault { get; set; }
        public string TabId { get; set; }
        public string DisplayName { get; set; }
        public string Flag { get; set; }
        public IHtmlContent TabContent { get; set; }
       
    }
}
