using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dau.Core.Domain.Localization
{
    [Table("Resource", Schema = "Localization")]
    public class Resource : BaseEntity
    {
       
        [Required]
        public long LanguageId { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Key")]
        public string Key { get; set; }

        [Required]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public virtual Language Language { get; set; }
    }
}
