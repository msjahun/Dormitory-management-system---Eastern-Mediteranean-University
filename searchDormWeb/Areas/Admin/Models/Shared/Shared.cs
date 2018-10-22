using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Shared
{
    public class SeoTab
    {

        [Display(Name = "MetaKeywords",
        Description = "Meta keywords to be added to dormitory page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords {get; set;}


        [Display(Name = "MetaDescription",
        Description = "Meta description to be added to dormitory page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription {get; set;}


        [Display(Name = "MetaTitle",
        Description = "Override the page title. The default is the name of the dormitory."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle {get; set;}


        [Display(Name = "SearchEngineFriendlyPageName",
        Description = "Set a search engine friendly page name e.g. 'the-best-dormitory' to make your page URL 'http://www.domain.com/the-best-dormitory'. Leave empty to generate it automatically based on the name of the Dormitory"), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName { get; set; }

    }
}
