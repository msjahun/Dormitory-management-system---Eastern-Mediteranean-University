using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dau.Services.Domain.DropdownServices
{
    public interface IDropdownService
    {
        List<SelectListItem> Active();
        List<SelectListItem> ActivityLogType();
        List<SelectListItem> BookingStatus();
        List<SelectListItem> CancellationStatus();
        List<SelectListItem> City();
        List<SelectListItem> Country();
        List<SelectListItem> DiscountType();
        List<SelectListItem> Dormitories();
        List<SelectListItem> DormitoryBlocks();
        List<SelectListItem> ExchangeRateProviders();
        List<SelectListItem> LogLevel();
        List<SelectListItem> PaymentMethod();
        List<SelectListItem> PaymentStatus();
        List<SelectListItem> Priority();
        List<SelectListItem> Published();
        List<SelectListItem> UserRoles();
    }
}