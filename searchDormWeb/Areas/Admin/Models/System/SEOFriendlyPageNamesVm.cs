using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class SEOFriendlyPageNamesVm
    {
        [Display(Name = "Name",
        Description = "An Seo friendly name to find."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string Name { get; set; }
    }
}
