using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DropdownServices
{
    public class DropdownService : IDropdownService
    {
        public DropdownService()
        {

        }


        //list of dormitoryBlocks
        public List<SelectListItem> DormitoryBlocks()
        {
            var NorthAmericaGroup = new SelectListGroup { Name = "Europe" };
            var EuropeGroup = new SelectListGroup { Name = "Europe" };

          var  model = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value ="1",
                Text = "Mexico",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value ="1",
                Text = "Canada",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value = "US",
                Text = "USA",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value = "2",
                Text = "France",
                Group = EuropeGroup
            },
            new SelectListItem
            {
                Value = "3",
                Text = "Spain",
                Group = EuropeGroup
            },
            new SelectListItem
            {
                Value = "4",
                Text = "Germany",
                Group = EuropeGroup
            }
      };

            return model;
        }

    }



}
