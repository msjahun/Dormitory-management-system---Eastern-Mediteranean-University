using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class FacilityAdd
    {
        public LocalizedFacilityContent[] localizedFacilityContent { get; set; }

         [Display(Name = "DisplayOrder",
        Description = "The display order of the facility specification attribute."), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }


    public class FacilityEdit
    {
        public LocalizedFacilityContent[] localizedFacilityContent { get; set; }


        [Display(Name = "DisplayOrder",
        Description = "The display order of the facility specification attribute."), MaxLength(256)]
        public int DisplayOrder { get; set; }

    }


    public class LocalizedFacilityContent
    {
        [Display(Name = "Name",
          Description = "The name of the facility specification attribute."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

    }

    public class FacilityOptionsTable
    {
public string Name {get; set;}
public string DisplayOrder {get; set;}
public string NumberOfAssociatedRooms {get; set;}
public string Edit {get; set;}
public string Delete { get; set; }

    }
}
