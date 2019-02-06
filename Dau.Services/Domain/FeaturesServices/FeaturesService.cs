using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.FeaturesServices
{
    public class FeaturesService : IFeaturesService
    {
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTransRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<FeaturesCategory> _featuresCategoryRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _featuresCategoryTransRepo;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepository;
        private readonly IRepository<DormitoryFeatures> _dormFeaturesRepository;

        public FeaturesService(
            IRepository<Features> featuresRepository,
            IRepository<FeaturesTranslation> featuresTransRepository,
              IRepository<FeaturesCategory> featuresCategoryRepository,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepository,
            IRepository<RoomFeatures> roomFeaturesRepository,
             IRepository<DormitoryFeatures> dormFeaturesRepository,
            ILanguageService languageService
            )
        {
            _featuresRepo = featuresRepository;
            _featuresTransRepo = featuresTransRepository;
            _languageService = languageService;
            _featuresCategoryRepo = featuresCategoryRepository;
            _featuresCategoryTransRepo = featuresCategoryTransRepository;
            _roomFeaturesRepository = roomFeaturesRepository;
            _dormFeaturesRepository = dormFeaturesRepository;
        }

        public List<PopularFiltersTable> GetFeaturesHitCount()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId && feature.HitCount > 0
                           orderby feature.HitCount descending
                           select new PopularFiltersTable
                           {
                               Count = feature.HitCount.ToString(),
                               Filter = featureTrans.FeatureName
                           };

            return features.ToList();
        }


        public bool UpdateFeaturesHitCount(List<long> FeaturesIds)
        {
            if (FeaturesIds != null)
                foreach (var featureId in FeaturesIds)
                {
                    var feature = _featuresRepo.GetById(featureId);
                    feature.HitCount++;
                    _featuresRepo.Update(feature);

                }

            return true;
        }


        public List<RoomFeaturesTable> GetRoomFeatures(long RoomId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new
                           {
                               feature.Id,
                               feature.FeaturesCategoryId,
                               featureTrans.FeatureName,
                               feature.AllowFiltering,
                               feature.IconUrl
                           };


            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                                   join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                                   where featureCatTrans.LanguageId == CurrentLanguageId
                                   select new
                                   { featureCat.Id, featureCatTrans.CategoryName };


            var fullFeatures = from feature in features.ToList()
                               join featureCat in featuresCategory.ToList() on feature.FeaturesCategoryId equals featureCat.Id
                               select new
                               {
                                   feature.Id,
                                   feature.FeatureName,
                                   featureCat.CategoryName,
                                   feature.IconUrl,
                                   feature.AllowFiltering

                               };

            var RoomFeatures = from roomFeature in _roomFeaturesRepository.List().ToList()
                               join feature in fullFeatures.ToList() on roomFeature.FeaturesId equals feature.Id
                               where roomFeature.RoomId == RoomId
                               select new RoomFeaturesTable
                               {
                                   FeatureCategory = feature.CategoryName,
                                   Feature = "<i class=\"" + feature.IconUrl + "\"></i> " + feature.FeatureName,
                                   AllowFiltering = feature.AllowFiltering,
                                   ShowOnRoomPage = true,
                                   DisplayOrder = 4,
                                   Id=feature.Id
                               };


            var model = RoomFeatures.ToList();

            return model;

        }


        public List<DormitoryFeaturesTable> GetDormitoryFeatures(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new
                           {
                               feature.Id,
                               feature.FeaturesCategoryId,
                               featureTrans.FeatureName,
                               feature.IconUrl
                           };


            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                                   join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                                   where featureCatTrans.LanguageId == CurrentLanguageId
                                   select new
                                   { featureCat.Id, featureCatTrans.CategoryName };


            var fullFeatures = from feature in features.ToList()
                               join featureCat in featuresCategory.ToList() on feature.FeaturesCategoryId equals featureCat.Id
                               select new
                               {
                                   feature.Id,
                                   feature.FeatureName,
                                   featureCat.CategoryName,
                                   feature.IconUrl

                               };

            var DormFeatures = from dormFeature in _dormFeaturesRepository.List().ToList()
                               join feature in fullFeatures.ToList() on dormFeature.FeaturesId equals feature.Id
                               where dormFeature.DormitoryId== DormitoryId
                               select new DormitoryFeaturesTable
                               {
                                   FeatureCategory = feature.CategoryName,
                                   Feature = "<i class=\"" + feature.IconUrl + "\"></i> " + feature.FeatureName,
                                   AllowFiltering = true,
                                   Id=feature.Id
                               };


            var model = DormFeatures.ToList();

            return model;

        }

        public bool AddRoomFeature(FacilitiesTab vm)
        {
            try
            {
                var model = new RoomFeatures
                {
                    RoomId = vm.RoomId,
                    FeaturesId = vm.Feature
                    
                };
                _roomFeaturesRepository.Insert(model);
                return true;
            }
            catch
            {
                return false;
            }


        }

         public bool AddDormitoryFeature(FacilitiesTabDormitory vm)
        {
            try
            {
                var model = new DormitoryFeatures
                {
                    DormitoryId = vm.DormitoryId,
                    FeaturesId = vm.Feature
                    
                };
                _dormFeaturesRepository.Insert(model);
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool RemoveDormitoryFeature(FacilitiesTabDormitory vm)
        {
            try
            {
                var model = _dormFeaturesRepository.List().Where(c => c.DormitoryId== vm.DormitoryId && c.FeaturesId == vm.Feature).FirstOrDefault();


                _dormFeaturesRepository.Delete(model);
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool RemoveRoomFeature(FacilitiesTab vm)
        {
            try
            {
                var model = _roomFeaturesRepository.List().Where(c => c.RoomId == vm.RoomId && c.FeaturesId == vm.Feature).FirstOrDefault();
                   
               
                _roomFeaturesRepository.Delete(model);
                return true;
            }
            catch
            {
                return false;
            }


        }


        public List<FeaturesTable> GetFeaturesTableList()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new
                           {
                               feature.Id,
                               feature.FeaturesCategoryId,
                               featureTrans.FeatureName
                               ,feature.IconUrl,
                               feature.IsPublished,
                               feature.AllowFiltering,
                               feature.DisplayOrder,
                               feature.HitCount,
                             
                           };


            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                                   join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                                   where featureCatTrans.LanguageId == CurrentLanguageId
                                   select new
                                   { featureCat.Id, featureCatTrans.CategoryName };


            var fullFeatures = from feature in features.ToList()
                               join featureCat in featuresCategory.ToList() on feature.FeaturesCategoryId equals featureCat.Id
                               select new FeaturesTable
                               {
                                   Id =feature.Id,
                                   FeatureName= feature.FeatureName,
                                   FeatureCategory= featureCat.CategoryName,
                                   SearchCount= feature.HitCount,
                                   AllowFiltering= feature.AllowFiltering,
                                   Published = feature.IsPublished,
                                   DisplayOrder= feature.DisplayOrder,
                                   ImageUrl=(feature.IconUrl!=null)?  feature.IconUrl: ""



                               };

            return fullFeatures.ToList();

        }

        public List<FeaturesCategoryTable> GetFeaturesCategoryTablesList()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var featuresCategory = from featureCat in _featuresCategoryRepo.List().ToList()
                                   join featureCatTrans in _featuresCategoryTransRepo.List().ToList() on featureCat.Id equals featureCatTrans.FeaturesCategoryNonTransId
                                   where featureCatTrans.LanguageId == CurrentLanguageId
                                   select new FeaturesCategoryTable
                                   {
                                       Id = featureCat.Id,
                                       FeatureCategory = featureCatTrans.CategoryName,
                                       NumberOfFeatures = _featuresRepo.List().Where(c => c.FeaturesCategoryId == featureCat.Id).Count(),
                                       IsActive = true,
                                       DisplayOrder = 0

                                   };

            return featuresCategory.ToList();

        }

        public long AddNewFeature(FeaturesCrud vm)
        {
            try { 

            var EnglishId = 1;
            var TurkishId = 2;
            var newFeature = new Features
            {
                FeaturesCategoryId=vm.FeatureCategory,
                //created on, updated on
                HitCount = 0,
                IsPublished = vm.Published,
                AllowFiltering = vm.AllowFiltering,
               DisplayOrder = vm.DisplayOrder,
               CreatedOn = DateTime.Now,
               UpdatedOn= DateTime.Now,
             
                FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = vm.localizedFacilityContent[0].Name,
                                FeatureDescription = vm.localizedFacilityContent[0].Description
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = vm.localizedFacilityContent[1].Name,
                                FeatureDescription = vm.localizedFacilityContent[1].Description
                            }
                        }
            };

           var featureId= _featuresRepo.Insert(newFeature);
            return featureId;

            }
            catch
            {
                return 0;
            }
        }

        public FeaturesCrud GetFeatureById(long id)
        {
            try
            {
                var feature = _featuresRepo.GetById(id);
                if (feature == null) return null;

                var EnglishTransFeature = _featuresTransRepo.List().Where(c => c.LanguageId == 1 && c.FeaturesNonTransId == feature.Id).FirstOrDefault();
                var TurkishTransFeature = _featuresTransRepo.List().Where(c => c.LanguageId == 2 && c.FeaturesNonTransId == feature.Id).FirstOrDefault();

                var Feature = new FeaturesCrud
                {
                    localizedFacilityContent = new List<LocalizedFacilityContent>
               {
                   new LocalizedFacilityContent
                   {
                       Name=EnglishTransFeature.FeatureName,
                       Description=EnglishTransFeature.FeatureDescription
                   },
                   new LocalizedFacilityContent
                   {
                       Name=TurkishTransFeature.FeatureName,
                       Description=TurkishTransFeature.FeatureDescription
                   }

               },
                    Id = feature.Id,
                    FontAwesomeIcon= feature.IconUrl,
                    FeatureCategory = feature.FeaturesCategoryId,
                    DisplayOrder = feature.DisplayOrder,
                    Published = feature.IsPublished,
                    AllowFiltering = feature.AllowFiltering,
                    CreatedOn = feature.CreatedOn.ToString(),
                    UpdatedOn = feature.UpdatedOn.ToString()
                };

                return Feature;
            }
            catch
            {
                return null;
            }
    
        }

        public bool UpdateFeature(FeaturesCrud vm)
        {
            try
            {
                var feature = _featuresRepo.GetById(vm.Id);
                if (feature == null) return false;

                var EnglishTransFeature = _featuresTransRepo.List().Where(c => c.LanguageId == 1 && c.FeaturesNonTransId == feature.Id).FirstOrDefault();
                var TurkishTransFeature = _featuresTransRepo.List().Where(c => c.LanguageId == 2 && c.FeaturesNonTransId == feature.Id).FirstOrDefault();


                EnglishTransFeature.FeatureName = vm.localizedFacilityContent[0].Name;
                EnglishTransFeature.FeatureDescription = vm.localizedFacilityContent[0].Description;


                TurkishTransFeature.FeatureName = vm.localizedFacilityContent[1].Name;
                TurkishTransFeature.FeatureDescription = vm.localizedFacilityContent[1].Description;

                feature.Id = vm.Id;
                feature.IconUrl = vm.FontAwesomeIcon;
                feature.FeaturesCategoryId = vm.FeatureCategory;
                feature.IsPublished = vm.Published;
                feature.DisplayOrder = vm.DisplayOrder;
                feature.UpdatedOn = DateTime.Now;
                feature.AllowFiltering = vm.AllowFiltering;
                

                _featuresRepo.Update(feature);
                return true;
            }catch
            {
                return false;
            }

        }

        public bool DeleteFeature(FeaturesCrud vm)
        {
            try
            {
                var FeatureToDelete = _featuresRepo.GetById(vm.Id);
                if (FeatureToDelete == null) return false;

                _featuresRepo.Delete(FeatureToDelete);
                return true;
            }
            catch { return false; }
        }

        public bool RemoveFeatureIcon(long id)
        {
            try
            {
                var Feature = _featuresRepo.GetById(id);
                if (Feature == null) return false;
                Feature.IconUrl = null;
                _featuresRepo.Update(Feature);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }


    public class FeaturesCrud
    {
        public List<LocalizedFacilityContent> localizedFacilityContent { get; set; }

        public long Id { get; set; }

        [Display(Name = "Feature Icon",
 Description = "The Icon representing a feature "), DataType(DataType.Text), MaxLength(256)]
        public string FontAwesomeIcon{ get; set; }

        [Required]
        [Display(Name = "Feature Category",
       Description = "This is the Category the feature belongs to")]
        public long FeatureCategory { get; set; }

        [Required]
        [Display(Name = "Display Order",
        Description = "The display order of the facility specification attribute.")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Is Published",
        Description = "When checked it will be available for dormitories to use")]
        public bool Published { get; set; }


        [Display(Name = "Allow filtering",
        Description = "When checked it will it will be visible in filtering options on home page")]
        public bool AllowFiltering { get; set; }
        [Display(Name = "Created On",
       Description = "Date/Time this dormitory was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date/Time this dormitory was last updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }

    }



    public class FeaturesCategoryCrud
    {

        public long Id { get; set; }
        public List<LocalizedFacilityContent> localizedFacilityContent { get; set; }


        [Display(Name = "Display Order",
        Description = "The display order of the facility specification attribute.")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Is Published",
        Description = "When checked it will be available for dormitories to use")]
        public int Published { get; set; }


        [Display(Name = "Allow filtering",
        Description = "When checked it will it will be visible in filtering options on home page")]
        public int AllowFiltering { get; set; }


    }


    public class LocalizedFacilityContent
    {
        [Required]
        [Display(Name = "Feature Name",
          Description = "The name of the feature."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Feature Description",
         Description = "The Description of the feature."), DataType(DataType.Text), MaxLength(256)]
        public string Description { get; set; }


    }

    public class FacilityOptionsTable
    {
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public string NumberOfAssociatedRooms { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }

    }


    public class PopularFiltersTable
    {
        public string Filter { get; set; }
        public string Count { get; set; }


    }




    public class FeaturesTable
    {
        public long Id { get; set; }
        public string FeatureCategory { get; set; }
        public string FeatureName { get; set; }
        public bool AllowFiltering { get; set; }
        public int SearchCount { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageUrl { get; set; }
        public bool Published { get; internal set; }
    }
    public class FeaturesCategoryTable
    {
        public long Id { get; set; }
        public string FeatureCategory { get; set; }
        public int NumberOfFeatures { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class RoomFeaturesTable
    {
        public long Id { get; set; }
        public string FeatureCategory { get; set; }
        public string Feature { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnRoomPage { get; set; }
        public int DisplayOrder { get; set; }

    }



    public class DormitoryFeaturesTable
    {
        public long Id { get; set; }
        public string Feature { get; set; }
        public string FeatureCategory { get; set; }
        public bool AllowFiltering { get; set; }
    }

}
