using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.SeoServices;
using Dau.Services.Languages;
using Dau.Services.Security;
using Dau.Tests;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Tests.Domain.SeoServices
{
    [TestFixture]
   public class SeoServiceTests
    {
        private Mock<IRepository<Seo>> _SeoRepo;
        private Mock<ILanguageService> _languageService;
        private Mock<IRepository<Dormitory>> _dormitoryRepo;
        private Mock<IRepository<DormitoryTranslation>> _dormitoryTransRepo;
        private Mock<IRepository<DormitoryType>> _dormitoryTypeRepo;
        private Mock<IRepository<DormitoryTypeTranslation>> _dormitoryTypeTransRepo;
        private Mock<IUserRolesService> _userRolesService;
        private SeoService _seoService;

        [SetUp]
        public void SetUp()
        {

            _SeoRepo = new Mock<IRepository<Seo>>();
            _languageService = new Mock<ILanguageService>();
            _dormitoryRepo = new Mock<IRepository<Dormitory>>();
            _dormitoryTransRepo = new Mock<IRepository<DormitoryTranslation>>();
            _dormitoryTypeRepo = new Mock<IRepository<DormitoryType>>();
            _dormitoryTypeTransRepo = new Mock<IRepository<DormitoryTypeTranslation>>();
            _userRolesService = new Mock<IUserRolesService>();


            _seoService = new SeoService(
                _SeoRepo.Object,
                _languageService.Object,
                 _dormitoryRepo.Object,
                _dormitoryTransRepo.Object,
                _dormitoryTypeRepo.Object,
                _dormitoryTypeTransRepo.Object,
                _userRolesService.Object
                );


        }


        [TestCase("test",3, "test-4")]
        [TestCase("test",0, "test")]
        [TestCase("test",1, "test-2")]
        [TestCase("test",300, "test-301")]
        [TestCase("test",-3, "test")]
        [TestCase("test",0000000, "test")]
        [TestCase("test",int.MaxValue, "test")]
        [TestCase("test",int.MinValue, "test")]
        [TestCase("test",0000000, "test")]
        public void Concatenate_Duplicate_Index_To_Seo_FriendlyName_Test(string SeoFriendlyName, int Count, string expected)
        {
           _seoService.ConcatenateDuplicateIndexToSeoFriendlyName(SeoFriendlyName, Count).ShouldEqual(expected);
        }


        [Test]
        public void Should_return_lowercase()
        {
            _seoService.RemoveSpecialCharacters("tEsT").ShouldEqual("test");
        }

        [Test]
        public void Should_allow_all_latin_chars()
        {
            _seoService.RemoveSpecialCharacters("abcdefghijklmnopqrstuvwxyz1234567890").ShouldEqual("abcdefghijklmnopqrstuvwxyz1234567890");
        }

        [Test]
        public void Should_remove_illegal_chars()
        {
            _seoService.RemoveSpecialCharacters("test!@#$%^&*()+<>?/Test").ShouldEqual("test-test");
            _seoService.RemoveSpecialCharacters("test!@#$%^&*()+<>?/").ShouldEqual("test-");
        }

        [Test]
        public void Should_replace_space_with_dash()
        {
            _seoService.RemoveSpecialCharacters("test test").ShouldEqual("test-test");
            _seoService.RemoveSpecialCharacters("test     test").ShouldEqual("test-test");
        }

        [Test]
        public void Can_convert_non_western_chars()
        {
            //German letters with diacritics
            _seoService.RemoveSpecialCharacters("testäöü").ShouldEqual("test-");
        }

        [Test]
        public void Can_allow_unicode_chars()
        {
            //Russian letters
            _seoService.RemoveSpecialCharacters("testтест").ShouldEqual("test-");
        }
    }
}
