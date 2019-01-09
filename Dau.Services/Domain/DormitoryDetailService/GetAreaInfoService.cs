
using Dau.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dau.Services.Languages;
using Dau.Core.Domain.Catalog;
using Dau.Services.Domain.MapServices;
using Dau.Core.Domain.LocationInformations;
using Dau.Data.Repository;
using Dau.Core.Domain.EmuMap;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetAreaInfoService : IGetAreaInfoService
    {
        private readonly ILanguageService _languageService;
        private readonly IMapService _mapService;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IRepository<MapSection> _mapSectionRepo;
        private readonly IRepository<MapSectionTranslation> _mapSectionTransRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;

        public GetAreaInfoService(
              ILanguageService languageService,
                IMapService mapService,
                IRepository<Locationinformation> locationRepo,
                IRepository<MapSection> mapSectionRepo,
                IRepository<MapSectionTranslation> mapSectionTransRepo,
                IRepository<Dormitory> dormitoryRepo,
                IRepository<DormitoryTranslation> dormitoryTransRepo)
        {
            
            _languageService = languageService;
            _mapService = mapService;
            _locationRepo = locationRepo;
            _mapSectionRepo = mapSectionRepo;
            _mapSectionTransRepo = mapSectionTransRepo;
                _dormitoryRepo = dormitoryRepo;
            _dormitoryTransRepo = dormitoryTransRepo;

        }

        public AreaInfoSectionViewModel GetAreaInfo(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var locations = from location in _locationRepo.List().ToList()
                            where location.DormitoryId == DormitoryId
                            select location;

            var Dormitory = _dormitoryRepo.GetById(DormitoryId);
            var DormitoryTrans = _dormitoryTransRepo.List().Where(c => c.LanguageId == CurrentLanguageId && c.DormitoryNonTransId == DormitoryId).FirstOrDefault();


            var MapSection = from mapSection in _mapSectionRepo.List().ToList()
                             join mapSectionTrans in _mapSectionTransRepo.List().ToList() on mapSection.Id equals mapSectionTrans.MapSectionNonTransId
                             where mapSectionTrans.LanguageId == CurrentLanguageId
                             select new { mapSection.Id, mapSection.BuildingId, mapSectionTrans.LocationName };

            var MapSectionLocations = from mapSection in MapSection.ToList()
                                      join location in locations.ToList() on mapSection.Id equals location.MapSectionId
                                      select new LocationinformationViewModel
                                      { LocationName= mapSection.LocationName,
                                        MapSection= _mapService.GetMapSectionById(mapSection.Id),
                                      Distance=location.DistanceText,
                                      Duration=location.DurationText}; 

           
            AreaInfoSectionViewModel Model = new AreaInfoSectionViewModel { 
                DormitoryName = DormitoryTrans.DormitoryName,
               MapSection = _mapService.GetMapSectionById(Dormitory.MapSectionId),
                DormitoryStreetAddress = Dormitory.DormitoryStreetAddress,
                CloseLocations = MapSectionLocations.ToList()


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
        public List<LocationinformationViewModel> CloseLocations { get; set; }

        public int EmuLocation { get; set; }
        public int TravelMode { get; set; }

    }

    public class LocationinformationViewModel
    {
        public string LocationName { get; set; }
        public string MapSection { get; set; }
        public string Distance { get; set; }

        public string Duration { get; set; }

        //this field is only used for distanceToEMULocation
        public string ReferenceDormitory { get; set; }

    }


}
