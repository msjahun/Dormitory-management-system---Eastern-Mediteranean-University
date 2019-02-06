using Dau.Services.Domain.PriceCalculationService;
using Dau.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Tests.Domain.PriceCalculationServices
{
    [TestFixture]
    public class PriceCalculationServiceTests
    {
        public PriceCalculationService _priceCalculationService { get; private set; }
        const int SemesterPeriodPerSemester  = 1;
        const int SemesterPeriodOneYear = 3;
        const int SemesterPeriodTwoYear = 4;
        const bool IsPerSemester = false;
        const bool IsPerYear = true;

        [SetUp]
        public void SetUp()
        {
            _priceCalculationService = new PriceCalculationService();

           
        }

        [TestCase(IsPerSemester, SemesterPeriodPerSemester, 5000, 5000)]//x1
        [TestCase(IsPerSemester, SemesterPeriodOneYear, 5000, 10000)]//x2
        [TestCase(IsPerSemester, SemesterPeriodTwoYear, 5000, 20000)] //x4
        [TestCase(IsPerYear, SemesterPeriodPerSemester, 5000, 2500)] //x1/2
        [TestCase(IsPerYear, SemesterPeriodOneYear, 5000, 5000)]//x1
        [TestCase(IsPerYear, SemesterPeriodTwoYear, 10000, 20000)]//x2

        public void Calculate_Bookings_Totals_Price_Test(bool IsPricePerYear, long SemesterPeriodId, double Price, double expected)
        {
            _priceCalculationService.CalculateBookingTotal(IsPricePerYear,SemesterPeriodId, Price).ShouldEqual(expected);
        }
    }
}
