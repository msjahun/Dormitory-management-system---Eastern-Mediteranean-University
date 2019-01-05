using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class RoomsVm
    {
        [Display(Name = "Room name",
        Description = "A room name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string RoomName { get; set; }

        [Display(Name = "Dormitory block",
        Description = "Search by a specific Dormitory Block"),
        MaxLength(256)]
        public int DormitoryBlock { get; set; }

        [Display(Name = "Published",
        Description = "Search by a \"published\" property"),
        MaxLength(256)]
        public int Published { get; set; }

        [Display(Name = "Go directly to Room SKU",
        Description = "Enter room SKU and click Go"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string GoDirectoryToRoomSKU { get; set; }

         public bool AlertSuccessful { get; set; }
        public string  AlertMessage { get; set; }

    }




}
