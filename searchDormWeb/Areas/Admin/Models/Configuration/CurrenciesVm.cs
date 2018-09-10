using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class CurrenciesVm
    {
        [Display(Name = "Current exchange rate provider",
        Description = "Select an exchange rate provider."),
        MaxLength(256)]
        public int CurrentExchangeRateProvider { get; set; }

        [Display(Name = "Auto enabled",
        Description = "Determines whether exchange rates will be updated automatically.")]
        public bool AutoEnabled { get; set; }

    }
}
