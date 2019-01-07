
using Dau.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dau.Services.Languages;
using Dau.Core.Domain.Catalog;
using Dau.Services.Domain.MapServices;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetAreaInfoService : IGetAreaInfoService
    {
        private readonly Fees_and_facilitiesContext _dbContext;
        private readonly ILanguageService _languageService;
        private readonly IMapService _mapService;

        public GetAreaInfoService(
            Fees_and_facilitiesContext dbContext,
              ILanguageService languageService,
                IMapService mapService)
        {
            _dbContext = dbContext;
            _languageService = languageService;
            _mapService = mapService;
        }

        public AreaInfoSectionViewModel GetAreaInfo(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var locations = _dbContext.Dormitory.Include(c => c.CloseLocations).Include(k=> k.DormitoryTranslation). Where(d => d.Id == DormitoryId).FirstOrDefault();
            foreach(var closeLocation in locations.CloseLocations)
            {
                closeLocation.MapSection = "https://www.emu.edu.tr/campusmap?design=empty#" + closeLocation.MapSection;
            }
            AreaInfoSectionViewModel Model = new AreaInfoSectionViewModel { 
                DormitoryName = locations.DormitoryTranslation.Where(l => l.LanguageId == CurrentLanguageId).FirstOrDefault().DormitoryName,
               MapSection = _mapService.GetMapSectionById(locations.MapSectionId),
                DormitoryStreetAddress = locations.DormitoryStreetAddress,
                CloseLocations = locations.CloseLocations.ToList()


            };


            AreaInfoSectionViewModel model = Model;
            return model;

        }
    }

    public class AreaInfoSectionViewModel
    {
        public string LocationRemark { get; set; }
        public string DormitoryName { get; set; }
        public string MapSection { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public List<Locationinformation> CloseLocations { get; set; }

    }


}
