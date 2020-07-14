using System;
using Tdd.Katas.LeapYearLib;
using Xunit;

namespace Tdd.Katas.LeapYearLibTests
{
    public class LeapYearUtilityTests
    {
        //A year is not a leap year if not divisible by 4
        [Fact]
        public void IsLeapYeat_WhenNotDiv4_ReturnFalse()
        {

            var actual=LeapYearUtility.IsLeapYear(1997);

            Assert.False(actual);
        }

        //A year is a leap year if divisible by 4

        [Fact]
        public void IsLeapYeat_WhenDiv4_ReturnTrue()
        {

            var actual = LeapYearUtility.IsLeapYear(2000);

            Assert.True( actual);
        }

        //A year is a leap year if divisible by 400
        [Fact]
        public void IsLeapYeat_WhenDiv400_ReturnTrue()
        {

            var actual = LeapYearUtility.IsLeapYear(1600);

            Assert.True(actual);
        }

        // A year is not a leap year if divisible by 100 but not by 400
        [Fact]
        public void IsLeapYeat_WhenDiv100_andNotDiv400_ReturnTrue()
        {

            var actual = LeapYearUtility.IsLeapYear(1500);

            Assert.True(actual);
        }
    }
}
