using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class RoomsVm
    {
            public string RoomName { get; set; }
            public int DormitoryBlock { get; set; }
            public int Published { get; set; }
            public string GoDirectoryToRoomSKU { get; set; }

    }
}
