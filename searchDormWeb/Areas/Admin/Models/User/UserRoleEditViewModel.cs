using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.User
{
    public class UserRoleEditViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }


        [Display(Name = "User role Name")]
        [StringLength(40)]
        [Required, MinLength(6), MaxLength(60)]
        public string Name { get; set; }

        [Display(Name = "System Name")]
        public string SystemName { get; set; }

        [Display(Name = "Is system role")]
        [Required]
        public bool IsSystemRole { get; set; }

        [Display(Name = "Is active")]
        [Required]
        public bool ISActive { get; set; }

    }
}
