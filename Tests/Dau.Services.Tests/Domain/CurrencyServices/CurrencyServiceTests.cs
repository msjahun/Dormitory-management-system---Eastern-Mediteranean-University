using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.CurrencyInformation;
using Dau.Data.Repository;
using Dau.Services.Domain.CurrencyServices;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Tests.Domain.CurrencyServices
{
    [TestFixture]
    public class CurrencyServiceTests
    {
        private Mock<IRepository<Currency>> _currencyRepo;
        private Mock<IRepository<Dormitory>> _dormitoryRepo;
        private Mock<IRepository<Room>> _roomRepo;
        private CurrencyService _currencyService;

        [SetUp]
        public void SetUp()
        {

            _currencyRepo = new Mock<IRepository<Currency>>();
            _dormitoryRepo = new Mock<IRepository<Dormitory>>();
            _roomRepo = new Mock<IRepository<Room>>();

            _currencyService = new CurrencyService(
              _currencyRepo.Object, 
                 _dormitoryRepo.Object,
                _roomRepo.Object
                );

        }


        [TestCase("$ {0}","USD",500,"$ 500.00")]
        [TestCase("{0} TL","TRY",500,"500.00 TL")]
        [TestCase("","USD",500,"500.00 USD")]
        [TestCase("","TRY",500,"500.00 TRY")]
      
        public void Currency_Formatter_Test(string Customformat, string CurrencyCode, double Amount, string expected)
        {
            var result = _currencyService.CurrencyFormatter(Customformat, CurrencyCode, Amount);
            Assert.AreEqual( expected, result);
        }

        [TestCase("", "TRY", double.MaxValue)]
        public void Currency_Formatter_Max_Double_Value_Test(string Customformat, string CurrencyCode, double Amount)
        {
            var format = "{0} {1}";
            string expected = string.Format(format, Amount.ToString("N2"), CurrencyCode);

            var result = _currencyService.CurrencyFormatter(Customformat, CurrencyCode, Amount);
            Assert.AreEqual(expected, result);
        }

        [TestCase("", "TRY", double.MinValue)]
        public void Currency_Formatter_Min_Double_Value_Test(string Customformat, string CurrencyCode, double Amount)
        {
            var format = "{0} {1}";
            string expected = string.Format(format, Amount.ToString("N2"),CurrencyCode);

         
            var result = _currencyService.CurrencyFormatter(Customformat, CurrencyCode, Amount);
            Assert.AreEqual(expected, result);
        }

    }
}
