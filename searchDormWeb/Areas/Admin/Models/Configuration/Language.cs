using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class LanguageAdd
    {
        [Display(Name = "Name",
        Description = "The name of the language.")
       
,  DataType(DataType.Text), MaxLength(256)  ] public string Name { get; set; }
[Display(Name = "Language Culture",
        Description = "The language specific culture code.")
       
 ,   MaxLength(256) ] public int LanguageCulture { get; set; }
[Display(Name = "Unique SEO Code",
        Description = "The unique two letter SEO code.It's used to generate URLs like 'http://www.site.com/en/' when you have more than one published language. 'SEO friendly URLs with multiple languages' option should also be enabled.")
       
, DataType(DataType.Text), MaxLength(256)  ] public string UniqueSEOCode { get; set; }
[Display(Name = "Flag Image File Name",
        Description = "The flag image file name.The image should be saved into \\images\flags\\ directory.")
       
,  DataType(DataType.Text), MaxLength(256)  ] public string FlagImageFileName { get; set; }
[Display(Name = "Right To Left",
        Description = "Check to enable right-to-left support for this language.The active theme should support RTL(have appropriate CSS style file). And it affects only public store.")
       
  ] public bool RightToLeft { get; set; }
[Display(Name = "Default Currency",
        Description = "This property allows an administrator to specify a default currency for a language.If not specified, then the default currency display order will be used.")
       
 ,   MaxLength(256) ] public int DefaultCurrency { get; set; }
[Display(Name = "Limited To Dormitories",
        Description = "Option to limit this language to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")
       
  ] public IEnumerable<int> LimitedToDormitories { get; set; }
[Display(Name = "Published",
        Description = "Determines whether this language is published and can therefore be selected by visitors to site.")
       
  ] public bool Published { get; set; }
[Display(Name = "Display Order",
        Description = "The display order of this language. 1 represents the top of the list.")
       
 ,   MaxLength(256) ] public int DisplayOrder { get; set; }

    }

    public class LanguageEdit
    {
        [Display(Name = "Name",
        Description = "The name of the language."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Language Culture",
        Description = "The language specific culture code."), MaxLength(256)]
        public int LanguageCulture { get; set; }

        [Display(Name = "Unique Seo Code",
        Description = "The unique two letter SEO code.It's used to generate URLs like 'http://www.site.com/en/' when you have more than one published language. 'SEO friendly URLs with multiple languages' option should also be enabled."), DataType(DataType.Text), MaxLength(256)]
        public string UniqueSeoCode { get; set; }

        [Display(Name = "Flag Image File Name",
        Description = "The flag image file name.The image should be saved into \\images\flags\\ directory."), DataType(DataType.Text), MaxLength(256)]
        public string FlagImageFileName { get; set; }

        [Display(Name = "Right To Left",
        Description = "Check to enable right-to-left support for this language.The active theme should support RTL(have appropriate CSS style file). And it affects only public store.")]
        public bool RightToLeft { get; set; }

        [Display(Name = "Default Currency",
        Description = "This property allows an administrator to specify a default currency for a language.If not specified, then the default currency display order will be used."), MaxLength(256)]
        public int DefaultCurrency { get; set; }

        [Display(Name = "Limited To Dormitories",
        Description = "Option to limit this language to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitedToDormitories { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this language is published and can therefore be selected by visitors to site.")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order of this language. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        public ResourceTab resourceTab { get; set; }
    }

    public class ResourceTab
    {
        [Display(Name = "Resource Name",
      Description = "The name of the language resource"), MaxLength(256)]

        public string ResourceName { get; set;}

        [Display(Name = "Resource Value",
      Description = "The translated value of the language resource"), MaxLength(256)]

        public string Value { get; set; }
    }
}
