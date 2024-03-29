﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class DormitoryBlocksVm
    {
        [Display(Name = "Block name",
        Description = "A dormitory block name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string BlockName { get; set; }
    }


  
    public class RoomsTable
    {
public string Room {get; set;}
public string isFeaturedRoom {get; set;}
public string DisplayOrder {get; set;}
public string View { get; set; }

    }

}
