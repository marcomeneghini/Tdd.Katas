using System;
using System.Collections.Generic;

namespace Tdd.Katas.RomanNumbersLib
{
    public class RomanNumbersGenerator
    {
        public static string Generate(int number)
        {
            var result = string.Empty;
            var map = InitializeMap();
            foreach (KeyValuePair<int,string> item in map)
            {
                while (number>=item.Key)
                {
                    result += item.Value;
                    number -= item.Key;
                }
            }
           
            return result;
        }
    
        private static Dictionary<int, string> InitializeMap()
        {
            var map = new Dictionary<int, string>
            {
                {100,"C"},
                {90,"XC"},
                {50,"L"},
                {40,"XL"},
                {10,"X"},
                {9,"IX"},
                {5,"V"},
                {4,"IV"},
                { 1, "I" },
                
            };
            return map;
        }
    }
}
