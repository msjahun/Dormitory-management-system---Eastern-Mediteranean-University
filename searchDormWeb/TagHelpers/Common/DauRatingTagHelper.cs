using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers.Common
{
    [HtmlTargetElement("dau-rating")]
    public class DauRatingTagHelper : TagHelper
    {
        //<dau-label></dau-label>
       public string Rating {get; set;}



      

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //tag details
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Clear();



            var RatingNo = Convert.ToDouble(Rating);
                
                for (int i = 0; i < 10; i += 2)
                {var star = new TagBuilder("i");
                    if (i < Math.Floor(RatingNo))
                    {
                    star.Attributes.Add("class", "star fas fa-star voted");

                    }
                    else
                    {
                    star.Attributes.Add("class", "star fas fa-star ");
                    }
                output.PostContent.AppendHtml(" ");
                output.PostContent.AppendHtml(star);
                }

               
              
            



            output.Attributes.Add("class", "static-rating static-rating-sm");
       


        }
    }
}
