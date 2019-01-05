using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DropdownServices
{
    public class DropdownService : IDropdownService
    {
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
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepository)
        {
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
        }

       public static SelectListGroup NorthAmericaGroup = new SelectListGroup { Name = "Europe" };
        public static SelectListGroup EuropeGroup = new SelectListGroup { Name = "Europe" };

        List<SelectListItem> model = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value ="1",
                Text = "Mexico",
                Group = NorthAmericaGroup
            },
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


        public List<SelectListItem> Dormitories()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
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

        

        public List<SelectListItem> Features()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new SelectListItem
                           {
                               Value = feature.Id.ToString(),
                               Text = featureTrans.FeatureName
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
                               Text = featureTrans.FeatureName
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
                Text = "1 Semester commitment"
            },
              new SelectListItem
            {
                Value ="2",
                Text = "1 Year commitment"
            },
             };
            return model;
        }


        public List<SelectListItem> BuildingsOnMap()
        {

            var model = new List<SelectListItem> {
            new SelectListItem
            {
                Value ="1",
                Text = "Alfam dormitory A block"
            },
              new SelectListItem
            {
                Value ="2",
                Text = "Akdeniz dormitory"
            },
                new SelectListItem
            {
                Value ="3",
                Text = "Sanel b block"
            },
             };
            return model;
        }

        public List<SelectListItem> LocationOnCampus()
        {

            var model = new List<SelectListItem> {
            new SelectListItem
            {
                Value ="1",
                Text = "South Campus"
            },
              new SelectListItem
            {
                Value ="2",
                Text = "North Campus"
            },
                new SelectListItem
            {
                Value ="3",
                Text = "Other"
            },
             };
            return model;
        }


         public List<SelectListItem> UserRoles()
        {
            return model;
        }


        public List<SelectListItem> Country()
        {
            return model;
        }


        public List<SelectListItem> City()
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
    }



}
