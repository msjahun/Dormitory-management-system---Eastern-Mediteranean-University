using Dau.Core.Domain.EmuMap;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.MapServices
{
    public class MapService : IMapService
    {
        private readonly IRepository<MapSection> _mapSectionRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<MapSectionTranslation> _mapSectionTransRepo;

        public MapService(IRepository<MapSection> mapSectionRepo,
            IRepository<MapSectionTranslation> mapSectionTransRepo,
            ILanguageService languageService)
        {

            _mapSectionRepo = mapSectionRepo;
            _languageService = languageService;
            _mapSectionTransRepo = mapSectionTransRepo;
        }


        public string GetMapSectionById(long id)
        {
            var mapSection = _mapSectionRepo.GetById(id);
            if (mapSection == null) return null;
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            if (CurrentLanguageId == 1)
                return "https://www.emu.edu.tr/campusmap?design=empty#" + "b" + mapSection.BuildingId;
            else
                return "https://www.emu.edu.tr/kampusharitasi?design=empty#" + "b" + mapSection.BuildingId;
        }


        public string GetMapSectionNameById(long id)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var mapSection = _mapSectionRepo.GetById(id);
            var mapSectionTrans = _mapSectionTransRepo.List().Where(c => c.MapSectionNonTransId == id && c.LanguageId == CurrentLanguageId).FirstOrDefault();
            if (mapSection == null || mapSectionTrans==null) return null;

            return mapSectionTrans.LocationName;
          
        }



        public string GetLatitudeLongitudeBySectionId(long id)
        {
            var mapSection = _mapSectionRepo.GetById(id);
            if (mapSection == null) return null;

            if (mapSection.Latitude == 0 || mapSection.Longitude == 0) return null;

            return mapSection.Latitude.ToString(CultureInfo.InvariantCulture) + "," + mapSection.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}
