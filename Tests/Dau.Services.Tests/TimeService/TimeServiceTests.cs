using Dau.Services.TimeServices;
using Microsoft.Extensions.Localization;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dau.Services.Tests.TimeServices
{
    [TestFixture]
   public class TimeServiceTests
    {
        private Mock<IStringLocalizer> _stringLocalizer;
        private TimeService _timeService;

        [SetUp]
        public void SetUp()
        {
           var keys = new List<string>{
           "a minute ago",
           " minutes ago",
           "one second ago",
           " seconds ago",
           "an hour ago",
           " hours ago",
           "yesterday",
           " days ago"
           };
         

            var localizedStrings = new List<LocalizedString>();

            foreach (var key in keys) localizedStrings.Add(new LocalizedString(key, key));


            _stringLocalizer = new Mock<IStringLocalizer>();

           foreach(var localizedString in localizedStrings)
            _stringLocalizer.Setup(_ => _[localizedString.Name]).Returns(localizedString);

            _timeService = new TimeService(_stringLocalizer.Object);

        }

   



        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(40)]
        [TestCase(59)]
        public void TimeAgoSecondsAgo(int numberOfSeconds)
        {
            var expected = "";
            var result = "";


            if (numberOfSeconds == 1)
            {
                expected = "one second ago";
                result = _timeService.TimeAgo(DateTime.Now.AddSeconds(numberOfSeconds * -1));

            }
            else { 
             expected = numberOfSeconds + " seconds ago";
             result = _timeService.TimeAgo(DateTime.Now.AddSeconds(numberOfSeconds*-1));
            }
            //Assert
            Assert.AreEqual(expected, result);

        }


     
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(44)]
        public void TimeAgoMinutesAgo(int numberOfMinutes)
        {
            var expected = "";
            var result = "";


            if (numberOfMinutes == 1)
            {
                expected = "a minute ago";
                result = _timeService.TimeAgo(DateTime.Now.AddMinutes(numberOfMinutes * -1));

            }
            else
            {
                expected = numberOfMinutes + " minutes ago";
                result = _timeService.TimeAgo(DateTime.Now.AddMinutes(numberOfMinutes * -1));
            }
            

            //Assert
            Assert.AreEqual(expected, result);

        }

        [TestCase(45)]
        [TestCase(47)]
        [TestCase(69)]
        [TestCase(89)]
        public void TimeAgoAnHourAgo(int numberOfMinutes)
        {
            var expected = "an hour ago";
            var result = _timeService.TimeAgo(DateTime.Now.AddMinutes(numberOfMinutes * -1));

            //Assert
            Assert.AreEqual(expected, result);

        }


        
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(20)]
        [TestCase(23)]
        public void TimeAgoHoursAgo(int numberOfHours)
        {
            var expected = numberOfHours +" hours ago";
            var result = _timeService.TimeAgo(DateTime.Now.AddHours(numberOfHours * -1));

            //Assert
            Assert.AreEqual(expected, result);

        }


        [TestCase(24)]
        [TestCase(26)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(47)]
        public void TimeAgoYesterday(int numberOfHours)
        {
            var expected = "yesterday";
            var result = _timeService.TimeAgo(DateTime.Now.AddHours(numberOfHours * -1));

            //Assert
            Assert.AreEqual(expected, result);

        }

        [TestCase(2)]
        [TestCase(3)]
        public void TimeAgoDaysAgo(int numberOfDays)
        {
            var expected = numberOfDays + " days ago";
            var result = _timeService.TimeAgo(DateTime.Now.AddDays(numberOfDays * -1));

            //Assert
            Assert.AreEqual(expected, result);

        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(200)]
        [TestCase(10000)]
        public void TimeAgoGreaterThan3DaysAgo(int numberOfDays)
        {
            var inputDateTime = DateTime.Now.AddDays(numberOfDays *-1);
            var expected = inputDateTime.ToString("d");
            var result = _timeService.TimeAgo(inputDateTime);
            Assert.AreEqual(expected, result);


        }

    }
}
