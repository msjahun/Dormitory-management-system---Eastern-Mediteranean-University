//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using Dau.Data;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dau.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Resource> _resourcesRepo;
        private readonly IRepository<Language> _languageRepository;
        private readonly IHttpContextAccessor _context;

        public LanguageService(IHttpContextAccessor httpContextAccessor, 
            IRepository<Language> LanguageRepository,
            IRepository<Resource> resourcesRepository)
        {
            _resourcesRepo = resourcesRepository;
            _languageRepository=LanguageRepository;
              _context = httpContextAccessor;
        }

     

        public long GetCurrentLanguageId()
        {
            var rqf = _context.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var Language = _languageRepository.List().Where(l => l.CultureName == culture.ToString()).FirstOrDefault();

            return Language.Id;
        }


        public string GetCurrentCode()
        {
            var rqf = _context.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var Language = _languageRepository.List().Where(l => l.CultureName == culture.ToString()).FirstOrDefault();
            if (Language == null) return null;
            return Language.CultureName;
        }




        public List<LanguagesTable> GetAllLanguagesTable()
        {
            var languages = from lang in _languageRepository.List().ToList()
                            select new LanguagesTable
                            {
                                Id = lang.Id,
                                Name = lang.DisplayName,
                                LanguageCulture = lang.CultureName,
                                DisplayOrder = (0).ToString(),
                                Published = true,
                                FlagImage = ""
                            };

            var model = languages.ToList();
            return model;
        }


        public List<ResourcesVm> GetResoucesByLanguageId(long Id)
        {
            var Resources = from resource in _resourcesRepo.List().ToList()
                            where resource.LanguageId == Id
                            select new ResourcesVm
                            {
                                ResourceId = resource.Id,
                                ResourceName = resource.Key,
                                ResourceValue = resource.Value
                            };

            return Resources.ToList();

        }


        public LanguageEdit GetLanguageById (long Id)
        {
            var language =  _languageRepository.GetById(Id);

            if (language == null) return null;
            var LanguageEdit = new LanguageEdit
            {
                Id = language.Id,
                Name = language.DisplayName,
                LanguageCulture= language.CultureName,
                UniqueSeoCode= language.CultureName,
                Country=language.Country
            };

            return LanguageEdit;

           
        }

        public ResourcesVm GetResourceById(long id)
        {
            try
            {
                var resource = _resourcesRepo.GetById(id);
                if (resource == null) return null;

                var ResourceResult = new ResourcesVm
                {
                    ResourceId = resource.Id,
                    ResourceName = resource.Key,
                    ResourceValue = resource.Value,
                    Success = true
                };

                return ResourceResult;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateResource(ResourcesVm vm)
        {
            try { 
            var resource = _resourcesRepo.GetById(vm.ResourceId);
            if (resource == null) return false;

            resource.Key = vm.ResourceName;
            resource.Value = vm.ResourceValue;

            _resourcesRepo.Update(resource);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddNewResource(ResourcesVm vm)
        {
            try { 
            var resource = new Resource
            {
                Key = vm.ResourceName,
                Value = vm.ResourceValue,
                LanguageId = vm.LanguageId,
                Comment = ""


            };

            _resourcesRepo.Insert(resource);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteResource(long id)
        {
            try
            {
                var resource = _resourcesRepo.GetById(id);
                if (resource == null) return false;
                _resourcesRepo.Delete(resource);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class LanguagesTable
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string FlagImage { get; set; }
            public string LanguageCulture { get; set; }
            public string DisplayOrder { get; set; }
            public bool Published { get; set; }
        }


        public class LanguageEdit
        {
            [Display(Name = "Name",
            Description = "The name of the language."), DataType(DataType.Text), MaxLength(256)]
            public string Name { get; set; }

            [Display(Name = "Language Culture",
            Description = "The language specific culture code."), MaxLength(256)]
            public string LanguageCulture { get; set; }

            [Display(Name = "Unique Seo Code",
            Description = "The unique two letter SEO code.It's used to generate URLs like 'http://www.site.com/en/' when you have more than one published language. 'SEO friendly URLs with multiple languages' option should also be enabled."), DataType(DataType.Text), MaxLength(256)]
            public string UniqueSeoCode { get; set; }

            [Display(Name = "Flag Image File Name",
            Description = "The flag image file name.The image should be saved into \\images\flags\\ directory."), DataType(DataType.Text), MaxLength(256)]
            public string FlagImageFileName { get; set; }
            public long Id { get; internal set; }
            public string Country { get; internal set; }


            [Display(Name = "Resource name",
                       Description = "Name of the language resource"), DataType(DataType.Text), MaxLength(256)]

            public string AddResourceName { get; set; }

            [Display(Name = "Resource name",
                        Description = "Name of the language resource"), DataType(DataType.Text), MaxLength(256)]

            public string EditResourceName { get; set; }


            [Display(Name = "Resource value",
           Description = "Value of the resource"), DataType(DataType.Text), MaxLength(256)]

            public string AddValue { get; set; }

            [Display(Name = "Resource value",
         Description = "Value of the resource"), DataType(DataType.Text), MaxLength(256)]

            public string EditValue { get; set; }

            public ResourceTab resourceTab { get; set; }
        }


        public class ResourceTab
        {
            [Display(Name = "Resource Name",
          Description = "The name of the language resource"), MaxLength(256)]

            public string ResourceName { get; set; }

            [Display(Name = "Resource Value",
          Description = "The translated value of the language resource"), MaxLength(256)]

            public string Value { get; set; }
        }
    }
}
