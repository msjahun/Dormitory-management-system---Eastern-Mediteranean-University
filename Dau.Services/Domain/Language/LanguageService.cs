//using Dau.Core.Domain.Language;
using Dau.Core.Domain.Localization;
using Dau.Data;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _languageRepository;
        private readonly IHttpContextAccessor _context;

        public LanguageService(IHttpContextAccessor httpContextAccessor, IRepository<Language> LanguageRepository)
        {
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
    }
}
