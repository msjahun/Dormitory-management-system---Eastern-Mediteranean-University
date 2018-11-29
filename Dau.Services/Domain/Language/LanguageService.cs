using Dau.Core.Domain.Language;
using Dau.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Language
{
    class LanguageService
    {
        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();

        public void languageInitiate()
        {
           

                //   Adding the two languages done
                 _context .LanguageTable.Add(new LanguageTable { Name = "English Language", LanguageCode = "EN" });
                 _context .LanguageTable.Add(new LanguageTable { Name = "Turkish Language", LanguageCode = "TR" });
                 _context .SaveChanges();
            

        }
    }
}
