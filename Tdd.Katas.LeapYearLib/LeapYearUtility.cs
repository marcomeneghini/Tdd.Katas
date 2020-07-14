using System;
using System.Collections.Generic;
using System.Text;

namespace Tdd.Katas.LeapYearLib
{
    public class LeapYearUtility
    {
        public static bool IsLeapYear(int year) 
        {
            var result = IsDivisible(year, 100) ? IsDivisible(year, 400) : IsDivisible(year, 4);
          
            return result;
        }

        private static bool IsDivisible(int year, int num)
        {
            return year % num == 0;
        }
    }
}
