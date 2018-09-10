using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class BulkEditRoomsVm
    {
        [Display(Name = "Room name",
        Description = "A room name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string RoomName { get; set; }


        [Display(Name = "Dormitory block",
        Description = "Search by a specific dormitory block."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string DormitoryBlock { get; set; }

    }
}
