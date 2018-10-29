﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ContentManagement
{
    public class TopicAdd
    {
        public LocalizedTopicsContent[] localizedTopicsContents { get; set; }


        [Display(Name = "SystemName",
        Description = "System name of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string SystemName { get; set; }


        [Display(Name = "Published",
        Description = "Determines whether this topic is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "PasswrodProtected",
        Description = "Check if this topic is password protected.")]
        public bool PasswrodProtected { get; set; }

        [Display(Name = "IncludeInTopMenu",
        Description = "Check to include this topic in the top menu.")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "IncludeInFooterColumn1",
        Description = "Check to include this topic in the footer (column 1). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn1 { get; set; }

        [Display(Name = "IncludeInFooterColumn2",
        Description = "Check to include this topic in the footer (column 2). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn2 { get; set; }

        [Display(Name = "IncludeInFooterColumn3",
        Description = "Check to include this topic in the footer (column 3). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn3 { get; set; }

        [Display(Name = "IncludeInSitemap",
        Description = "Check to include this topic in the sitemap.")]
        public bool IncludeInSitemap { get; set; }

        [Display(Name = "CustomerRoles",
        Description = "Select customer roles for which the topic will be shown.Leave empty if you want this topic to be visible to all users.")]
        public IEnumerable<int> CustomerRoles { get; set; }

        [Display(Name = "LimtedToDormitory",
      Description = "Option to limit this topic to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimtedToDormitory { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The topic display order. 1 represents the first item in the list. It's used with properties such as \"Include in top menu\" or \"Include in footer\"."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "AccessileWhenSiteIsClosed",
        Description = "Check to allow customer to view this topic details page when the site is closed.")]
        public bool AccessileWhenSiteIsClosed { get; set; }

        public TopicsSeoTab[] seoTab { get; set; }
    }

    public class TopicEdit
    {
        
        public LocalizedTopicsContent[] localizedTopicsContents { get; set; }

        [Display(Name = "SystemName",
        Description = "System name of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string SystemName { get; set; }

        [Display(Name = "Url",
        Description = "The URL of this topic."), DataType(DataType.Text), MaxLength(256)]
        public string Url { get; set; }

        [Display(Name = "Published",
        Description = "Determines whether this topic is published(visible) in the website.")]
        public bool Published { get; set; }

        [Display(Name = "PasswrodProtected",
        Description = "Check if this topic is password protected.")]
        public bool PasswrodProtected { get; set; }

        [Display(Name = "IncludeInTopMenu",
        Description = "Check to include this topic in the top menu.")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "IncludeInFooterColumn1",
        Description = "Check to include this topic in the footer (column 1). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn1 { get; set; }

        [Display(Name = "IncludeInFooterColumn2",
        Description = "Check to include this topic in the footer (column 2). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn2 { get; set; }

        [Display(Name = "IncludeInFooterColumn3",
        Description = "Check to include this topic in the footer (column 3). Ensure that that current system supports it.")]
        public bool IncludeInFooterColumn3 { get; set; }

        [Display(Name = "IncludeInSitemap",
        Description = "Check to include this topic in the sitemap.")]
        public bool IncludeInSitemap { get; set; }

        [Display(Name = "CustomerRoles",
        Description = "Select customer roles for which the topic will be shown.Leave empty if you want this topic to be visible to all users.")]
        public IEnumerable<int> CustomerRoles { get; set; }

        [Display(Name = "LimtedToDormitory",
        Description = "Option to limit this topic to a certain dormitory.If you have multiple dormitories, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimtedToDormitory { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The topic display order. 1 represents the first item in the list. It's used with properties such as \"Include in top menu\" or \"Include in footer\"."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "AccessileWhenSiteIsClosed",
        Description = "Check to allow customer to view this topic details page when the site is closed.")]
        public bool AccessileWhenSiteIsClosed { get; set; }

        public TopicsSeoTab[] seoTab { get; set; }

    }


    public  class TopicsSeoTab
    {
        [Display(Name = "MetaKeywords",
        Description = "Meta keywords to be added to topic page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords { get; set; }


        [Display(Name = "MetaDescription",
        Description = "Meta description to be added to topic page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription { get; set; }


        [Display(Name = "MetaTitle",
        Description = "Override the page title. The default is the name of the topic"), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle { get; set; }


        [Display(Name = "SearchEngineFriendlyPageName",
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
