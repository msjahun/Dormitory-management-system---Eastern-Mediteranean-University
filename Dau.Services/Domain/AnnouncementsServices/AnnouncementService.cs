using Dau.Core.Domain.Notifications;
using Dau.Data.Repository;
using Dau.Services.TimeServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.AnnouncementsServices
{
   public class AnnouncementService : IAnnouncementService
    {
        private IRepository<Announcement> _annoucementRepo;
        private readonly ITimeService _timeService;

        public AnnouncementService(IRepository<Announcement> annoucementRepo,
            ITimeService timeService)
        {
            _annoucementRepo = annoucementRepo;
            _timeService=timeService;
        }

        public AnnouncementCrud GetAnnouncementById(long Id)
        {
            try
            {
                var announcement = _annoucementRepo.GetById(Id);
                if (announcement == null) return null;

                var model = new AnnouncementCrud
                {
                    EndDate = announcement.EndDate.ToString("MM/dd/yyyy"),
                    Message = announcement.Message,
                    Priority = announcement.Priority,
                    Published = announcement.Published,
                    StartDate = announcement.StartDate.ToString("MM/dd/yyyy"),
                    Title = announcement.Title,
                    Id = announcement.Id,
                    CreatedOn = announcement.CreatedOn.ToString()
                };
                return model;
            }
            catch { return null; }

        } 

        public long AddNewAnnouncement(AnnouncementCrud vm)
        {
            try
            {

                string input = vm.StartDate;
                DateTime StartDate;
                DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out StartDate);
              

                string inputEndDate = vm.EndDate;
                DateTime EndDate;
                DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out EndDate);

                var announcement = new Announcement
                {
                   
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Message = vm.Message,
                    Priority = vm.Priority,
                    Title = vm.Title,
                    Published = vm.Published,
                    CreatedOn = DateTime.Now
                };

                var newAnnouncementId = _annoucementRepo.Insert(announcement);
                return newAnnouncementId;
            }
            catch { return 0; }
        }


        public bool updateAnnoucement (AnnouncementCrud vm)
        {
            try
            {
                var announcement = _annoucementRepo.GetById(vm.Id);
                if (announcement == null) return false;

                string input = vm.StartDate;
                DateTime StartDate;
                DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out StartDate);


                string inputEndDate = vm.EndDate;
                DateTime EndDate;
                DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out EndDate);

                announcement.EndDate = StartDate;
                announcement.Message = vm.Message;
                announcement.Priority = vm.Priority;
                announcement.Published = vm.Published;
                announcement.StartDate = EndDate;
                announcement.Title=vm.Title;

                _annoucementRepo.Update(announcement);
                return true;

            }
            catch { return false; }

        }

        public List<ManageAnnoucementsTable> GetAnnoucementsTableList()
        {
            var Annoncements = from ann in _annoucementRepo.List().ToList()
                               select new ManageAnnoucementsTable
                               {
                                   Id = ann.Id,
                                   Title = ann.Title,
                                   Priority = ann.Priority,
                                   Message = ann.Message,
                                   StartDate = ann.StartDate.ToString(),
                                   IsActive = ann.Published,
                                   CreatedOn = _timeService.TimeAgo(ann.CreatedOn)



                               };

            return Annoncements.ToList();

        }

        public bool DeleteAnnouncement (AnnouncementCrud vm)
        {
            try
            {
                var announcement = _annoucementRepo.GetById(vm.Id);
                if (announcement == null) return false;

                _annoucementRepo.Delete(announcement);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }



    public class ManageAnnoucementsTable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public string Message { get; set; }
        public string StartDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string Edit { get; set; }
    }

    public class AnnouncementCrud
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Title",
        Description = "Title of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Message",
        Description = "Message of the announcement."), DataType(DataType.Text), MaxLength(256)]
        public string Message { get; set; }

        [Required]
        [Display(Name = "Start Date",
        Description = "The start date/time the announcement will be displayed.")]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = "End Date",
        Description = "The end date/time the announcement will be displayed.")]
        public string EndDate { get; set; }

        [Display(Name = "Priority",
        Description = "The priority of the announcement.")]
        public int Priority { get; set; }

        [Display(Name = "Published",
        Description = "Check published to display annoucement to the dashboard.")]
        public bool Published { get; set; }

        public string CreatedOn { get; set; }



    }
}
