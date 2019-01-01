using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dau.Services.Domain.DropdownServices
{
    public interface IDropdownService
    {
        List<SelectListItem> DormitoryBlocks();
    }
}