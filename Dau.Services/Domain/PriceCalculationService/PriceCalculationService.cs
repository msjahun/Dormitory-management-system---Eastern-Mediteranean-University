using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.PriceCalculationService
{
    public class PriceCalculationService : IPriceCalculationService
    {

        public double CalculateBookingTotal(bool IsPricePerYear, long SemesterPeriodId, double Price)
        {

            const int SemesterPeriodPerSemester = 1;
            // const int SemesterPeriodSummer = 2;
            const int SemesterPeriodOneYear = 3;
            const int SemesterPeriodTwoYear = 4;

            double priceMultiplier = 1;
            bool IsPerSemester = !IsPricePerYear;

            if (IsPerSemester)
            {//Persemester
                if (SemesterPeriodId == SemesterPeriodOneYear)
                    priceMultiplier = 2;

                else if (SemesterPeriodId == SemesterPeriodTwoYear)
                    priceMultiplier = 4;

            }
            else
            {//Per Year
                if (SemesterPeriodId == SemesterPeriodPerSemester)
                    priceMultiplier = 0.5; // half a year

                else if (SemesterPeriodId == SemesterPeriodTwoYear)
                    priceMultiplier = 2;
            }

            return Price * priceMultiplier;



        }
    }


}
