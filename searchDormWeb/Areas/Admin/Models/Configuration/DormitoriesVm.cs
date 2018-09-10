using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class DormitoriesVm
    {

        [Display(Name = "Dormitory name",
        Description = "A Dormitory name"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string  DormitoryName { get; set; }

        [Display(Name = "Dormitory type",
        Description = "Search by a specific Dormitory Type"),
        MaxLength(256)]
        public int DormitoryType { get; set; }

        [Display(Name = "Go directly to SKU",
        Description = "Enter dormitory SKU and click Go"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string GoDirectlyToSKU { get; set; }


    }
}
