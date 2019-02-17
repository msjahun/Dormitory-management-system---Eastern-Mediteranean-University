using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.CurrencyInformation;
using Dau.Core.Domain.EmuMap;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DropdownServices
{
    public class DropdownService : IDropdownService
    {
        private readonly IRepository<Currency> _currencyRepo;
        private readonly IUserRolesService _userRolesService;
        private readonly IStringLocalizer _localizer;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTranslationRepo;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTransRepo;
        private readonly IRepository<FeaturesCategory> _featuresCategoryRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _featuresCategoryTransRepo;
        private readonly IRepository<MapSection> _mapSectionRepo;
        private readonly IRepository<MapSectionTranslation> _mapSectionTransRepo;
        private readonly IRepository<MapSectionCategory> _mapSectionCategoryRepo;
        private readonly IRepository<MapSectionCategoryTranslation> _mapSectionCategoryTransRepo;

        public DropdownService(
            IRepository<DormitoryBlock> dormitoryBlockRepo,
            IRepository<DormitoryBlockTranslation> dormitoryBlockTransRepo,
              ILanguageService languageService,
                   IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
             IRepository<Features> featuresRepository,
              IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTranslationRepository,
            IRepository<FeaturesTranslation> featuresTransRepository,
             IRepository<FeaturesCategory> featuresCategoryRepository,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepository,
            IRepository<MapSection> mapSectionRepo,
            IRepository<MapSectionTranslation> mapSectionTranslationRepo,
            IRepository<MapSectionCategory> mapSectionCategoryRepo,
            IRepository<MapSectionCategoryTranslation> mapSectionCategoryTranslationRepo,
            IStringLocalizer Localizer,
             IUserRolesService userRolesService,
             IRepository<Currency> currencyRepo)
        {
            _currencyRepo = currencyRepo;
            _userRolesService = userRolesService;
            _localizer = Localizer;
            _dormitoryBlockRepo = dormitoryBlockRepo;
            _dormitoryBlockTransRepo = dormitoryBlockTransRepo;
            _languageService = languageService;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _dormitoryTypeRepo = dormitoryTypeRepository;
            _dormitoryTypeTranslationRepo = dormitoryTypeTranslationRepository;
            _featuresRepo = featuresRepository;
            _featuresTransRepo=  featuresTransRepository;
            _featuresCategoryRepo=featuresCategoryRepository;
            _featuresCategoryTransRepo=featuresCategoryTransRepository;

            _mapSectionRepo=mapSectionRepo;
            _mapSectionTransRepo= mapSectionTranslationRepo;
            _mapSectionCategoryRepo=mapSectionCategoryRepo;
            _mapSectionCategoryTransRepo=mapSectionCategoryTranslationRepo;
        }

       public static SelectListGroup NorthAmericaGroup = new SelectListGroup { Name = "Europe" };
        public static SelectListGroup EuropeGroup = new SelectListGroup { Name = "Europe" };

        List<SelectListItem> model = new List<SelectListItem>
        {
            new SelectListItem{Value ="1",Text = "Mexico"},
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
      
        //list of dormitoryBlocks
        public List<SelectListItem> DormitoryBlocks()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 orderby dormBlock.DisplayOrder
                                 select new SelectListItem
                                 {
                                     Value = dormBlock.Id.ToString(),
                                     Text = dormBlockTrans.Name
                                 };


            return dormitoryBlock.ToList();
        }

        public List<SelectListItem> GetDormitoryBlockByDormitoryIdDropdown(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId && dormBlock.DormitoryId==DormitoryId
                                 orderby dormBlock.DisplayOrder
                                 select new SelectListItem
                                 {
                                     Value = dormBlock.Id.ToString(),
                                     Text = dormBlockTrans.Name
                                 };


            return dormitoryBlock.ToList();
        }


        public List<SelectListItem> Dormitories()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitory = from dorm in _dormitoryRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.Id)).ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new SelectListItem
                            {
                                Value = dorm.Id.ToString(),
                                Text = dormTrans.DormitoryName
                            };

            return dormitory.ToList();
        }


        public List<SelectListItem> FeatureCategory()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                           join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                           where featureCatTrans.LanguageId == CurrentLanguageId
                           select new SelectListItem
                           {
                               Value = featureCat.Id.ToString(),
                               Text = featureCatTrans.CategoryName
                           };

            return featuresCategory.ToList();
        }

                public List<SelectListItem> Currencies()
        {

            var Currencies = from Curr in _currencyRepo.List().ToList()
                             where Curr.Published == true
                           select new SelectListItem
                           {
                               Value = Curr.Id.ToString(),
                               Text = Curr.CurrencyCode
                           };

            return Currencies.ToList();
        }

        

        public List<SelectListItem> Features()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new SelectListItem
                           {
                               Value = feature.Id.ToString(),
                               Text = "<i class=\"" + feature.IconUrl + "\"></i> " + featureTrans.FeatureName
                           };
           
            return features.ToList();
        }


           public List<SelectListItem> FeaturesByCategoryId(long id)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId && feature.FeaturesCategoryId == id
                           select new SelectListItem
                           {
                               Value = feature.Id.ToString(),
                               Text = "<i class=\"" + feature.IconUrl + "\"></i> " +featureTrans.FeatureName
                           };
           
            return features.ToList();
        }



        public List<SelectListItem> DormitoryTypes()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new SelectListItem
                                {
                                    Value = dormType.Id.ToString(),
                                    Text = dormTypeTrans.Title
                                };
            return dormitoryType.ToList();
        }


        public List<SelectListItem> BookingLimit()
        {
            var model = new List<SelectListItem> {
            new SelectListItem
            {
                Value ="1",
                Text = _localizer["1 Semester commitment"]
            },
              new SelectListItem
            {
                Value ="2",
                Text = _localizer["1 Year commitment"]
            },
             };
            return model;
        }
       
        public string ResolveDropdown(int id,List<SelectListItem> dropdownList)
        {
            foreach(var item in dropdownList)
            {
                if (item.Value == id.ToString()) return item.Text;
            }
            return null;
        }
        public List<SelectListItem> DormitoryBuildingsOnMap()
        {
            //all the buildings in dormitory category
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var DormitoriesMapSectionCategoryId = _mapSectionCategoryTransRepo.List().ToList().Where(c => c.CategoryName == "Dormitories and accomodations").FirstOrDefault().MapSectionCategoryNonTransId;
            var locations = from mapSection in _mapSectionRepo.List().ToList()
                            join MapSectionTrans in _mapSectionTransRepo.List().ToList() on mapSection.Id equals MapSectionTrans.MapSectionNonTransId
                            where MapSectionTrans.LanguageId == CurrentLanguageId && mapSection.MapSectionCategoryId== DormitoriesMapSectionCategoryId
                            select new SelectListItem
                            {
                                Value = mapSection.Id.ToString(),
                                Text = MapSectionTrans.LocationName
                            };

             
            return locations.ToList();
        }

        public List<SelectListItem> BuildingsOnMap()
        {
            //all buildings with groupings
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var MapSections = from mapSection in _mapSectionRepo.List().ToList()
                            join MapSectionTrans in _mapSectionTransRepo.List().ToList() on mapSection.Id equals MapSectionTrans.MapSectionNonTransId
                            where MapSectionTrans.LanguageId == CurrentLanguageId
                            select new 
                            { mapSection.Id, MapSectionTrans.LocationName, mapSection.MapSectionCategoryId};



            var MapSectionCategories = from mapSectionCat in _mapSectionCategoryRepo.List().ToList()
                                       join mapSectionCatTrans in _mapSectionCategoryTransRepo.List().ToList() on mapSectionCat.Id equals mapSectionCatTrans.MapSectionCategoryNonTransId
                                       where mapSectionCatTrans.LanguageId == CurrentLanguageId
                                       select new
                                       {
                                           mapSectionCat.Id,
                                           mapSectionCatTrans.CategoryName
                                       };

            var MapSectionJoin = from mapSection in MapSections.ToList()
                                 join mapSectionCat in MapSectionCategories.ToList() on mapSection.MapSectionCategoryId equals mapSectionCat.Id
                               select new{ mapSection.Id, mapSection.LocationName, CategoryId = mapSectionCat.Id, CategoryName = mapSectionCat.CategoryName };

            var Groupings =
        from MapSection in MapSectionJoin
        group MapSection by MapSection.CategoryName  into newGroup
        orderby newGroup.Key
        select newGroup;
            //  group mapSectionCat by mapSectionCat.CategoryName into newGroup

            // select newGroup;


            var model = new List<SelectListItem>();
            foreach (var newGroup in Groupings)
            {
                SelectListGroup CategoryGroup = new SelectListGroup { Name = newGroup.Key };
                foreach (var mapSection in newGroup)
                {
                    model.Add(new SelectListItem
                    {

                        Value = mapSection.Id.ToString(),
                        Text = mapSection.LocationName,
                        Group = CategoryGroup

                    });
                }
            }

            //select new SelectListItem
            //{
            //    Value = mapSection.Id.ToString(),
            //    Text = mapSection.LocationName,

            //   // Group =   mapSectionCat.CategoryName
            //};


            return model;
          //  return MapSectionJoin.ToList();
        }

        public List<SelectListItem> LocationOnCampus()
        {

            var model = new List<SelectListItem> {
            new SelectListItem
            {
                Value ="1",
                Text = _localizer["South Campus"]
            },
              new SelectListItem
            {
                Value ="2",
                Text = _localizer["North Campus"]
            },
                new SelectListItem
            {
                Value ="3",
                Text = _localizer["Other"]
            },
             };
            return model;
        }


        public List<SelectListItem> Gender()
        {
            var model = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value="1",
                    Text =_localizer["Male"]
                },
                 new SelectListItem
                {
                    Value="2",
                    Text =_localizer["Female"]
                },
                  new SelectListItem
                {
                    Value="3",
                    Text =_localizer["Rather Not say"]
                }
            };
            return model;
        }

        public List<SelectListItem> TravelModes()
        {

            var model = new List<SelectListItem> {
            new SelectListItem
            {
                Value ="1",
                Text = _localizer["Walking"]
            },
              new SelectListItem
            {
                Value ="2",
                Text = _localizer["Driving"]
            },
                new SelectListItem
            {
                Value ="3",
                Text = _localizer["bicycle"]
            },
             };
            return model;
        }


        public List<SelectListItem> UserRoles()
        {
            return model;
        }




        public List<SelectListItem> City()
        {
            return model;
        }


        public List<SelectListItem> FontAwesomeIcons()
        {

  
            return model;
        }


        public List<SelectListItem> BookingStatus()
        {
            return model;
        }


        public List<SelectListItem> PaymentStatus()
        {
            return model;
        }



        public List<SelectListItem> ActivityLogType()
        {
            return model;
        }


        public List<SelectListItem> Published()
        {
            return model;
        }

        public List<SelectListItem> PaymentMethod()
        {
            return model;
        }

        public List<SelectListItem> CancellationStatus()
        {
            return model;
        }

        public List<SelectListItem> DiscountType()
        {
            return model;
        }

        public List<SelectListItem> Active()
        {
            return model;
        }

        public List<SelectListItem> Priority()
        {
            return model;
        }

        public List<SelectListItem> ExchangeRateProviders()
        {
            return model;
        }


        public List<SelectListItem> LogLevel()
        {
            return model;
        }



        public List<SelectListItem> Country()
        {

            var model = new List<SelectListItem> {

                new SelectListItem{Value ="1",Text = "Afghanistan "},
                    new SelectListItem{Value ="2",Text = "Albania "},
                    new SelectListItem{Value ="3",Text = "Algeria "},
                    new SelectListItem{Value ="4",Text = "American Samoa "},
                    new SelectListItem{Value ="5",Text = "Andorra "},
                    new SelectListItem{Value ="6",Text = "Angola "},
                    new SelectListItem{Value ="7",Text = "Anguilla "},
                    new SelectListItem{Value ="8",Text = "Antigua & Barbuda "},
                    new SelectListItem{Value ="9",Text = "Argentina "},
                    new SelectListItem{Value ="10",Text = "Armenia "},
                    new SelectListItem{Value ="11",Text = "Aruba "},
                    new SelectListItem{Value ="12",Text = "Australia "},
                    new SelectListItem{Value ="13",Text = "Austria "},
                    new SelectListItem{Value ="14",Text = "Azerbaijan "},
                    new SelectListItem{Value ="15",Text = "Bahamas, The "},
                    new SelectListItem{Value ="16",Text = "Bahrain "},
                    new SelectListItem{Value ="17",Text = "Bangladesh "},
                    new SelectListItem{Value ="18",Text = "Barbados "},
                    new SelectListItem{Value ="19",Text = "Belarus "},
                    new SelectListItem{Value ="20",Text = "Belgium "},
                    new SelectListItem{Value ="21",Text = "Belize "},
                    new SelectListItem{Value ="22",Text = "Benin "},
                    new SelectListItem{Value ="23",Text = "Bermuda "},
                    new SelectListItem{Value ="24",Text = "Bhutan "},
                    new SelectListItem{Value ="25",Text = "Bolivia "},
                    new SelectListItem{Value ="26",Text = "Bosnia & Herzegovina "},
                    new SelectListItem{Value ="27",Text = "Botswana "},
                    new SelectListItem{Value ="28",Text = "Brazil "},
                    new SelectListItem{Value ="29",Text = "British Virgin Is. "},
                    new SelectListItem{Value ="30",Text = "Brunei "},
                    new SelectListItem{Value ="31",Text = "Bulgaria "},
                    new SelectListItem{Value ="32",Text = "Burkina Faso "},
                    new SelectListItem{Value ="33",Text = "Burma "},
                    new SelectListItem{Value ="34",Text = "Burundi "},
                    new SelectListItem{Value ="35",Text = "Cambodia "},
                    new SelectListItem{Value ="36",Text = "Cameroon "},
                    new SelectListItem{Value ="37",Text = "Canada "},
                    new SelectListItem{Value ="38",Text = "Cape Verde "},
                    new SelectListItem{Value ="39",Text = "Cayman Islands "},
                    new SelectListItem{Value ="40",Text = "Central African Rep. "},
                    new SelectListItem{Value ="41",Text = "Chad "},
                    new SelectListItem{Value ="42",Text = "Chile "},
                    new SelectListItem{Value ="43",Text = "China "},
                    new SelectListItem{Value ="44",Text = "Colombia "},
                    new SelectListItem{Value ="45",Text = "Comoros "},
                    new SelectListItem{Value ="46",Text = "Congo, Dem. Rep. "},
                    new SelectListItem{Value ="47",Text = "Congo, Repub. of the "},
                    new SelectListItem{Value ="48",Text = "Cook Islands "},
                    new SelectListItem{Value ="49",Text = "Costa Rica "},
                    new SelectListItem{Value ="50",Text = "Cote d'Ivoire "},
                    new SelectListItem{Value ="51",Text = "Croatia "},
                    new SelectListItem{Value ="52",Text = "Cuba "},
                    new SelectListItem{Value ="53",Text = "Cyprus "},
                    new SelectListItem{Value ="54",Text = "Czech Republic "},
                    new SelectListItem{Value ="55",Text = "Denmark "},
                    new SelectListItem{Value ="56",Text = "Djibouti "},
                    new SelectListItem{Value ="57",Text = "Dominica "},
                    new SelectListItem{Value ="58",Text = "Dominican Republic "},
                    new SelectListItem{Value ="59",Text = "East Timor "},
                    new SelectListItem{Value ="60",Text = "Ecuador "},
                    new SelectListItem{Value ="61",Text = "Egypt "},
                    new SelectListItem{Value ="62",Text = "El Salvador "},
                    new SelectListItem{Value ="63",Text = "Equatorial Guinea "},
                    new SelectListItem{Value ="64",Text = "Eritrea "},
                    new SelectListItem{Value ="65",Text = "Estonia "},
                    new SelectListItem{Value ="66",Text = "Ethiopia "},
                    new SelectListItem{Value ="67",Text = "Faroe Islands "},
                    new SelectListItem{Value ="68",Text = "Fiji "},
                    new SelectListItem{Value ="69",Text = "Finland "},
                    new SelectListItem{Value ="70",Text = "France "},
                    new SelectListItem{Value ="71",Text = "French Guiana "},
                    new SelectListItem{Value ="72",Text = "French Polynesia "},
                    new SelectListItem{Value ="73",Text = "Gabon "},
                    new SelectListItem{Value ="74",Text = "Gambia, The "},
                    new SelectListItem{Value ="75",Text = "Gaza Strip "},
                    new SelectListItem{Value ="76",Text = "Georgia "},
                    new SelectListItem{Value ="77",Text = "Germany "},
                    new SelectListItem{Value ="78",Text = "Ghana "},
                    new SelectListItem{Value ="79",Text = "Gibraltar "},
                    new SelectListItem{Value ="80",Text = "Greece "},
                    new SelectListItem{Value ="81",Text = "Greenland "},
                    new SelectListItem{Value ="82",Text = "Grenada "},
                    new SelectListItem{Value ="83",Text = "Guadeloupe "},
                    new SelectListItem{Value ="84",Text = "Guam "},
                    new SelectListItem{Value ="85",Text = "Guatemala "},
                    new SelectListItem{Value ="86",Text = "Guernsey "},
                    new SelectListItem{Value ="87",Text = "Guinea "},
                    new SelectListItem{Value ="88",Text = "Guinea-Bissau "},
                    new SelectListItem{Value ="89",Text = "Guyana "},
                    new SelectListItem{Value ="90",Text = "Haiti "},
                    new SelectListItem{Value ="91",Text = "Honduras "},
                    new SelectListItem{Value ="92",Text = "Hong Kong "},
                    new SelectListItem{Value ="93",Text = "Hungary "},
                    new SelectListItem{Value ="94",Text = "Iceland "},
                    new SelectListItem{Value ="95",Text = "India "},
                    new SelectListItem{Value ="96",Text = "Indonesia "},
                    new SelectListItem{Value ="97",Text = "Iran "},
                    new SelectListItem{Value ="98",Text = "Iraq "},
                    new SelectListItem{Value ="99",Text = "Ireland "},
                    new SelectListItem{Value ="100",Text = "Isle of Man "},
                    new SelectListItem{Value ="101",Text = "Israel "},
                    new SelectListItem{Value ="102",Text = "Italy "},
                    new SelectListItem{Value ="103",Text = "Jamaica "},
                    new SelectListItem{Value ="104",Text = "Japan "},
                    new SelectListItem{Value ="105",Text = "Jersey "},
                    new SelectListItem{Value ="106",Text = "Jordan "},
                    new SelectListItem{Value ="107",Text = "Kazakhstan "},
                    new SelectListItem{Value ="108",Text = "Kenya "},
                    new SelectListItem{Value ="109",Text = "Kiribati "},
                    new SelectListItem{Value ="110",Text = "Korea, North "},
                    new SelectListItem{Value ="111",Text = "Korea, South "},
                    new SelectListItem{Value ="112",Text = "Kuwait "},
                    new SelectListItem{Value ="113",Text = "Kyrgyzstan "},
                    new SelectListItem{Value ="114",Text = "Laos "},
                    new SelectListItem{Value ="115",Text = "Latvia "},
                    new SelectListItem{Value ="116",Text = "Lebanon "},
                    new SelectListItem{Value ="117",Text = "Lesotho "},
                    new SelectListItem{Value ="118",Text = "Liberia "},
                    new SelectListItem{Value ="119",Text = "Libya "},
                    new SelectListItem{Value ="120",Text = "Liechtenstein "},
                    new SelectListItem{Value ="121",Text = "Lithuania "},
                    new SelectListItem{Value ="122",Text = "Luxembourg "},
                    new SelectListItem{Value ="123",Text = "Macau "},
                    new SelectListItem{Value ="124",Text = "Macedonia "},
                    new SelectListItem{Value ="125",Text = "Madagascar "},
                    new SelectListItem{Value ="126",Text = "Malawi "},
                    new SelectListItem{Value ="127",Text = "Malaysia "},
                    new SelectListItem{Value ="128",Text = "Maldives "},
                    new SelectListItem{Value ="129",Text = "Mali "},
                    new SelectListItem{Value ="130",Text = "Malta "},
                    new SelectListItem{Value ="131",Text = "Marshall Islands "},
                    new SelectListItem{Value ="132",Text = "Martinique "},
                    new SelectListItem{Value ="133",Text = "Mauritania "},
                    new SelectListItem{Value ="134",Text = "Mauritius "},
                    new SelectListItem{Value ="135",Text = "Mayotte "},
                    new SelectListItem{Value ="136",Text = "Mexico "},
                    new SelectListItem{Value ="137",Text = "Micronesia, Fed. St. "},
                    new SelectListItem{Value ="138",Text = "Moldova "},
                    new SelectListItem{Value ="139",Text = "Monaco "},
                    new SelectListItem{Value ="140",Text = "Mongolia "},
                    new SelectListItem{Value ="141",Text = "Montserrat "},
                    new SelectListItem{Value ="142",Text = "Morocco "},
                    new SelectListItem{Value ="143",Text = "Mozambique "},
                    new SelectListItem{Value ="144",Text = "Namibia "},
                    new SelectListItem{Value ="145",Text = "Nauru "},
                    new SelectListItem{Value ="146",Text = "Nepal "},
                    new SelectListItem{Value ="147",Text = "Netherlands "},
                    new SelectListItem{Value ="148",Text = "Netherlands Antilles "},
                    new SelectListItem{Value ="149",Text = "New Caledonia "},
                    new SelectListItem{Value ="150",Text = "New Zealand "},
                    new SelectListItem{Value ="151",Text = "Nicaragua "},
                    new SelectListItem{Value ="152",Text = "Niger "},
                    new SelectListItem{Value ="153",Text = "Nigeria "},
                    new SelectListItem{Value ="154",Text = "N. Mariana Islands "},
                    new SelectListItem{Value ="155",Text = "Norway "},
                    new SelectListItem{Value ="156",Text = "Oman "},
                    new SelectListItem{Value ="157",Text = "Pakistan "},
                    new SelectListItem{Value ="158",Text = "Palau "},
                    new SelectListItem{Value ="159",Text = "Panama "},
                    new SelectListItem{Value ="160",Text = "Papua New Guinea "},
                    new SelectListItem{Value ="161",Text = "Paraguay "},
                    new SelectListItem{Value ="162",Text = "Peru "},
                    new SelectListItem{Value ="163",Text = "Philippines "},
                    new SelectListItem{Value ="164",Text = "Poland "},
                    new SelectListItem{Value ="165",Text = "Portugal "},
                    new SelectListItem{Value ="166",Text = "Puerto Rico "},
                    new SelectListItem{Value ="167",Text = "Qatar "},
                    new SelectListItem{Value ="168",Text = "Reunion "},
                    new SelectListItem{Value ="169",Text = "Romania "},
                    new SelectListItem{Value ="170",Text = "Russia "},
                    new SelectListItem{Value ="171",Text = "Rwanda "},
                    new SelectListItem{Value ="172",Text = "Saint Helena "},
                    new SelectListItem{Value ="173",Text = "Saint Kitts & Nevis "},
                    new SelectListItem{Value ="174",Text = "Saint Lucia "},
                    new SelectListItem{Value ="175",Text = "St Pierre & Miquelon "},
                    new SelectListItem{Value ="176",Text = "Saint Vincent and the Grenadines "},
                    new SelectListItem{Value ="177",Text = "Samoa "},
                    new SelectListItem{Value ="178",Text = "San Marino "},
                    new SelectListItem{Value ="179",Text = "Sao Tome & Principe "},
                    new SelectListItem{Value ="180",Text = "Saudi Arabia "},
                    new SelectListItem{Value ="181",Text = "Senegal "},
                    new SelectListItem{Value ="182",Text = "Serbia "},
                    new SelectListItem{Value ="183",Text = "Seychelles "},
                    new SelectListItem{Value ="184",Text = "Sierra Leone "},
                    new SelectListItem{Value ="185",Text = "Singapore "},
                    new SelectListItem{Value ="186",Text = "Slovakia "},
                    new SelectListItem{Value ="187",Text = "Slovenia "},
                    new SelectListItem{Value ="188",Text = "Solomon Islands "},
                    new SelectListItem{Value ="189",Text = "Somalia "},
                    new SelectListItem{Value ="190",Text = "South Africa "},
                    new SelectListItem{Value ="191",Text = "Spain "},
                    new SelectListItem{Value ="192",Text = "Sri Lanka "},
                    new SelectListItem{Value ="193",Text = "Sudan "},
                    new SelectListItem{Value ="194",Text = "Suriname "},
                    new SelectListItem{Value ="195",Text = "Swaziland "},
                    new SelectListItem{Value ="196",Text = "Sweden "},
                    new SelectListItem{Value ="197",Text = "Switzerland "},
                    new SelectListItem{Value ="198",Text = "Syria "},
                    new SelectListItem{Value ="199",Text = "Taiwan "},
                    new SelectListItem{Value ="200",Text = "Tajikistan "},
                    new SelectListItem{Value ="201",Text = "Tanzania "},
                    new SelectListItem{Value ="202",Text = "Thailand "},
                    new SelectListItem{Value ="203",Text = "Togo "},
                    new SelectListItem{Value ="204",Text = "Tonga "},
                    new SelectListItem{Value ="205",Text = "Trinidad & Tobago "},
                    new SelectListItem{Value ="206",Text = "Tunisia "},
                    new SelectListItem{Value ="207",Text = "Turkey "},
                    new SelectListItem{Value ="208",Text = "Turkmenistan "},
                    new SelectListItem{Value ="209",Text = "Turks & Caicos Is "},
                    new SelectListItem{Value ="210",Text = "Tuvalu "},
                    new SelectListItem{Value ="211",Text = "Uganda "},
                    new SelectListItem{Value ="212",Text = "Ukraine "},
                    new SelectListItem{Value ="213",Text = "United Arab Emirates "},
                    new SelectListItem{Value ="214",Text = "United Kingdom "},
                    new SelectListItem{Value ="215",Text = "United States "},
                    new SelectListItem{Value ="216",Text = "Uruguay "},
                    new SelectListItem{Value ="217",Text = "Uzbekistan "},
                    new SelectListItem{Value ="218",Text = "Vanuatu "},
                    new SelectListItem{Value ="219",Text = "Venezuela "},
                    new SelectListItem{Value ="220",Text = "Vietnam "},
                    new SelectListItem{Value ="221",Text = "Virgin Islands "},
                    new SelectListItem{Value ="222",Text = "Wallis and Futuna "},
                    new SelectListItem{Value ="223",Text = "West Bank "},
                    new SelectListItem{Value ="224",Text = "Western Sahara "},
                    new SelectListItem{Value ="225",Text = "Yemen "},
                    new SelectListItem{Value ="226",Text = "Zambia "},
                    new SelectListItem{Value ="227",Text = "Zimbabwe "}


            };
            return model;
        }

    }



}
