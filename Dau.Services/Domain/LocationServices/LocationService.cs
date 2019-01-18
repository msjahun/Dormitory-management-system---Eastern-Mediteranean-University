using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.EmuMap;
using Dau.Core.Domain.LocationInformations;
using Dau.Data.Repository;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dau.Services.Domain.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly ILanguageService _languageService;
        private readonly IMapService _mapService;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IRepository<MapSection> _mapSectionRepo;
        private readonly IRepository<MapSectionTranslation> _mapSectionTransRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IDormitoryService _dormitoryService;

        public LocationService(ILanguageService languageService,
                IMapService mapService,
                IRepository<Locationinformation> locationRepo,
                IRepository<MapSection> mapSectionRepo,
                IRepository<MapSectionTranslation> mapSectionTransRepo,
                IRepository<Dormitory> dormitoryRepo,
                IRepository<DormitoryTranslation> dormitoryTransRepo,
                IDormitoryService dormitoryService)
        {
            _languageService = languageService;
            _mapService = mapService;
            _locationRepo = locationRepo;
            _mapSectionRepo = mapSectionRepo;
            _mapSectionTransRepo = mapSectionTransRepo;
            _dormitoryRepo = dormitoryRepo;
            _dormitoryTransRepo = dormitoryTransRepo;
            _dormitoryService= dormitoryService;
        }
        static HttpClient client = new HttpClient();

        static async Task<GoogleMapApiResult> GetDistancematrixAsync(string path)
        {
            GoogleMapApiResult result= null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<GoogleMapApiResult>();
            }
            return result;
        }
        
            public List<CloseLocationsTable> GetDormitoryCloseLocationsListTable(long DormitoryId)
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
                                      orderby location.Id descending
                                      select new CloseLocationsTable
                                      {
                                          LocationName = mapSection.LocationName,
                                          Id = location.Id,
                                          Distance = location.DistanceText,
                                          TimeItTakes = location.DurationText
                                      };

            return MapSectionLocations.ToList();
            
        }
        public string GetClosestLandmark(long DormitoryId)
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

            var MapSLocation = (from mapSection in MapSection.ToList()
                                      join location in locations.ToList() on mapSection.Id equals location.MapSectionId
                                      orderby location.DistanceValue ascending
                                      select new CloseLocationsTable
                                      {
                                          LocationName = mapSection.LocationName,
                                          Id = location.Id,
                                          Distance = location.DistanceText,
                                          TimeItTakes = location.DurationText
                                      }).FirstOrDefault();
            return String.Format("({0} to {1})", MapSLocation.TimeItTakes, MapSLocation.LocationName);
        }

        public string GetClosestLandmarkMapSection(long DormitoryId)
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

            var MapSLocation = (from mapSection in MapSection.ToList()
                                join location in locations.ToList() on mapSection.Id equals location.MapSectionId
                                orderby location.DistanceValue ascending
                                select new 
                                {MapSectionId = mapSection.Id,
                                    LocationName = mapSection.LocationName,
                                    Id = location.Id,
                                    Distance = location.DistanceText,
                                    TimeItTakes = location.DurationText
                                }).FirstOrDefault();

            return _mapService.GetMapSectionById(MapSLocation.MapSectionId);
        }
       
        public async Task<bool> AddDormitoryCloseLocationAsync(CloseLocationVm vm)
        {
            var dormitory = _dormitoryRepo.GetById(vm.DormitoryId);
           
            //get dormitory map section information, get coordinates lat lan
            //get destination lat lan, then send  request
            var originCoordinate = _mapService.GetLatitudeLongitudeBySectionId(dormitory.MapSectionId);
            var destinationCoordinate = _mapService.GetLatitudeLongitudeBySectionId(vm.LocationId);

            if (originCoordinate == null || destinationCoordinate == null) return false;
            var googlemapApiKey = "AIzaSyBLcII2lrXK6o9fDCWBbwgf9OmbU5GxDJE";
            var path = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins="+ originCoordinate + "&destinations="+ destinationCoordinate + "&mode=walking&key=" + googlemapApiKey;
            var result =await GetDistancematrixAsync(path);

            if (result == null) return false;

            try {
                var location = new Locationinformation
                {
                    DormitoryId=vm.DormitoryId,
                    MapSectionId= vm.LocationId,
                    CreateDate=DateTime.Now,
                    DistanceText=result.rows.FirstOrDefault().elements.FirstOrDefault().distance.text,
                    DistanceValue= result.rows.FirstOrDefault().elements.FirstOrDefault().distance.value,
                    DurationText= result.rows.FirstOrDefault().elements.FirstOrDefault().duration.text,
                    DurationValue= result.rows.FirstOrDefault().elements.FirstOrDefault().distance.value,
                };

             var insertid=   _locationRepo.Insert(location);
                return (insertid>0)?true:false;
            }
            catch
            {
                return false;
            }
        }


        public bool RemoveDormitoryCloseLocation(CloseLocationVm vm)
        {
            try
            {
                var location=_locationRepo.GetById(vm.LocationId);

                if (location == null) return false;
                _locationRepo.Delete(location);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<LocationinformationViewModel> GetCalculatedDistanceToEmulocationAsync(CalculateDistanceToEMULocationVm vm)
        {
            //get dormitory id, use it to get dormitory name and coordinates
            //use the destination location id to get the coordinates of the location,

            var dormitory = _dormitoryRepo.GetById(vm.DormitoryId);

            //get dormitory map section information, get coordinates lat lan
            //get destination lat lan, then send  request
            var originCoordinate = _mapService.GetLatitudeLongitudeBySectionId(dormitory.MapSectionId);
            var destinationCoordinate = _mapService.GetLatitudeLongitudeBySectionId(vm.MapSectionId);

            var travelMode = "walking";
            switch (vm.TravelModeId)
            {
                case 1: travelMode = "walking"; break;
                case 2: travelMode = "driving"; break;
                case 3: travelMode = "bicycle"; break;
                default: travelMode = "walking";break;
            }

            var currentCulture = (_languageService.GetCurrentCode()!=null)?_languageService.GetCurrentCode():"en-US";
            


            if (originCoordinate == null || destinationCoordinate == null) return null;
            var googlemapApiKey = "AIzaSyBLcII2lrXK6o9fDCWBbwgf9OmbU5GxDJE";
            var path = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + originCoordinate + "&destinations=" + destinationCoordinate + "&mode="+travelMode+ "&language="+ currentCulture + "&key=" + googlemapApiKey;
            var result = await GetDistancematrixAsync(path);

            if (result == null) return null;

            try
            {
                //var location = new Locationinformation
                //{
                //    DormitoryId = vm.DormitoryId,
                //    MapSectionId = vm.MapSectionId,
                //    CreateDate = DateTime.Now,
                //    DistanceText = result.rows.FirstOrDefault().elements.FirstOrDefault().distance.text,
                //    DistanceValue = result.rows.FirstOrDefault().elements.FirstOrDefault().distance.value,
                //    DurationText = result.rows.FirstOrDefault().elements.FirstOrDefault().duration.text,
                //    DurationValue = result.rows.FirstOrDefault().elements.FirstOrDefault().distance.value,
                //};

                //log this if possible

                var model = new LocationinformationViewModel
                {
                    Distance = result.rows.FirstOrDefault().elements.FirstOrDefault().distance.text,
                    Duration = result.rows.FirstOrDefault().elements.FirstOrDefault().duration.text,
                    LocationName =_mapService.GetMapSectionNameById(vm.MapSectionId),
                    MapSection = _mapService.GetMapSectionById(vm.MapSectionId),
                    ReferenceDormitory = _dormitoryService.GetDormitoryNameById(vm.DormitoryId)

                };

                return model;

            }
            catch
            {
                return null;
            }
        }

    }



    public class CloseLocationsTable
    {
        public long Id { get; set; }
        public string LocationName { get; set; }
        public string Distance { get; set; }
        public string TimeItTakes { get; set; }

    }


    public class CalculateDistanceToEMULocationVm
    {
        public long DormitoryId { get; set; }
        public long MapSectionId { get; set; }
        public int TravelModeId { get; set; }
    }


    public class CloseLocationVm
    {
        public long DormitoryId { get; set; }
        public long LocationId { get; set; }
    }
    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }

    public class GoogleMapApiResult
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }


}
