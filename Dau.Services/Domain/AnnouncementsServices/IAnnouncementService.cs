using System.Collections.Generic;

namespace Dau.Services.Domain.AnnouncementsServices
{
    public interface IAnnouncementService
    {
        long AddNewAnnouncement(AnnouncementCrud vm);
        bool DeleteAnnouncement(AnnouncementCrud vm);
        AnnouncementCrud GetAnnouncementById(long Id);
        bool updateAnnoucement(AnnouncementCrud vm);
        List<ManageAnnoucementsTable> GetAnnoucementsTableList();
    }
}