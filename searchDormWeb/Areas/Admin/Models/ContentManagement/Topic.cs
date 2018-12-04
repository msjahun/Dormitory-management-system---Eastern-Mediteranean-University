using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ContentManagement
{
    public class TopicAdd
    {
        public LocalizedTopicsContent[] localizedTopicsContents { get; set; }


        [Display(Name = "System Name",
        Description = "System name of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string SystemName { get; set; }


        [Display(Name = "Published",
        Description = "Determines whether this topic is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Passwrod Protected",
        Description = "Check if this topic is password protected.")]
        public bool PasswrodProtected { get; set; }

        [Display(Name = "Include In Top Menu",
        Description = "Check to include this topic in the top menu.")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "Include In Footer Column 1",
        Description = "Check to include this topic in the footer (column 1). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn1 { get; set; }

        [Display(Name = "Include In Footer Column 2",
        Description = "Check to include this topic in the footer (column 2). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn2 { get; set; }

        [Display(Name = "Include In Footer Column 3",
        Description = "Check to include this topic in the footer (column 3). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn3 { get; set; }

        [Display(Name = "Include In Sitemap",
        Description = "Check to include this topic in the sitemap.")]
        public bool IncludeInSitemap { get; set; }

        [Display(Name = "Customer Roles",
        Description = "Select customer roles for which the topic will be shown.Leave empty if you want this topic to be visible to all users.")]
        public IEnumerable<int> CustomerRoles { get; set; }

        [Display(Name = "Limted To Dormitory",
      Description = "Option to limit this topic to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimtedToDormitory { get; set; }

        [Display(Name = "Display Order",
        Description = "The topic display order. 1 represents the first item in the list. It's used with properties such as \"Include in top menu\" or \"Include in footer\"."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Accessile When Site Is Closed",
        Description = "Check to allow customer to view this topic details page when the site is closed.")]
        public bool AccessileWhenSiteIsClosed { get; set; }

        public TopicsSeoTab[] seoTab { get; set; }
    }

    public class TopicEdit
    {
        
        public LocalizedTopicsContent[] localizedTopicsContents { get; set; }

        [Display(Name = "System Name",
        Description = "System name of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string SystemName { get; set; }

        [Display(Name = "Url",
        Description = "The URL of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string Url { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this topic is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "Passwrod Protected",
        Description = "Check if this topic is password protected.")]
        public bool PasswrodProtected { get; set; }

        [Display(Name = "Include In Top Menu",
        Description = "Check to include this topic in the top menu.")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "Include In Footer Column 1",
        Description = "Check to include this topic in the footer (column 1). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn1 { get; set; }

        [Display(Name = "Include In Footer Column 2",
        Description = "Check to include this topic in the footer (column 2). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn2 { get; set; }

        [Display(Name = "Include In Footer Column 3",
        Description = "Check to include this topic in the footer (column 3). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn3 { get; set; }

        [Display(Name = "Include In Sitemap",
        Description = "Check to include this topic in the sitemap.")]
        public bool IncludeInSitemap { get; set; }

        [Display(Name = "Customer Roles",
        Description = "Select customer roles for which the topic will be shown.Leave empty if you want this topic to be visible to all users.")]
        public IEnumerable<int> CustomerRoles { get; set; }

        [Display(Name = "Limted To Dormitory",
        Description = "Option to limit this topic to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimtedToDormitory { get; set; }

        [Display(Name = "Display Order",
        Description = "The topic display order. 1 represents the first item in the list. It's used with properties such as \"Include in top menu\" or \"Include in footer\"."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Accessile When Site Is Closed",
        Description = "Check to allow customer to view this topic details page when the site is closed.")]
        public bool AccessileWhenSiteIsClosed { get; set; }

        public TopicsSeoTab[] seoTab { get; set; }

    }


    public  class TopicsSeoTab
    {
        [Display(Name = "Meta Keywords",
        Description = "Meta keywords to be added to topic page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords { get; set; }


        [Display(Name = "Meta Description",
        Description = "Meta description to be added to topic page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription { get; set; }


        [Display(Name = "Meta Title",
        Description = "Override the page title. The default is the name of the topic"), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle { get; set; }


        [Display(Name = "Search Engine Friendly Page Name",
        Description = "Set a search engine friendly page name e.g. 'the-best-topic' to make your page URL 'http://www.domain.com/the-best-topic'. Leave empty to generate it automatically based on the name of the Topic."), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName { get; set; }

    }

    public class LocalizedTopicsContent
    {
        [Display(Name = "Title",
           Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Title { get; set; }

        [Display(Name = "Body",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }
    }
}
