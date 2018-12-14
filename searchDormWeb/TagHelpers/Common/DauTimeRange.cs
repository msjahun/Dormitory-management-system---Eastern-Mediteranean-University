using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-timerange")]
    public class DauTimeRange : TagHelper
    {


      //  <dau-timerange min="7" max="16"></dau-timerange>
        
        public int Min{ get; set; }
        public int Max { get; set; }





        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            

            var parcentMin = ((Min - 6) * 100) / 18;
            var parcentMax = ((Max - 6) * 100) / 18;
            var range = parcentMax - parcentMin;
            var remainingParcentage = 100 - (parcentMin + range);
            var adjustedparcentMax = parcentMin+range-5;

            var DisplayedTimeMin = (Min <= 12) ? Min + ":00 am" : Min - 12 + ":00  pm";
            var DisplayedTimeMax = (Max <= 12) ? Max + ":00 am" : Max - 12 + ":00  pm";
            //tag details
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Clear();

            string Tooltips = String.Format(@" <div class=""progress-wrapper"">

                    <h4 class=""progress-tooltip"" style=""left: {0}%;"">{2}</h4>
                    <h4 class=""progress-tooltip"" style=""left: {1}%;"">{3}</h4>
                </div>",parcentMin, adjustedparcentMax,DisplayedTimeMin, DisplayedTimeMax);


            string Progressbar = String.Format(@" <div class=""progress "">

                    <div class=""progress-bar "" style="" background-color:#eaedf0; width: {0}%;"" ></div>
                    <div class=""progress-bar bg-success"" role=""progressbar"" style=""width: {1}%"" ></div>
                    <div class=""progress-bar ""  ></div>
                </div>",parcentMin,range);




            output.PostContent.AppendHtml(Tooltips);
                output.PostContent.AppendHtml(" ");
                output.PostContent.AppendHtml(Progressbar);
            }











        
    }
}
