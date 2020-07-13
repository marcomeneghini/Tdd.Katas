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
            if (number<=10)
            {
                result = map[number];
                return result;
            }else
            {
                var tens = number / 10;
                for (int i = 0; i < tens; i++)
                {
                    result += map[10];
                }
                number = number - (tens*10);
            }
            result += map[number];
            return result;
        }
    
        private static Dictionary<int, string> InitializeMap()
        {
            var map = new Dictionary<int, string>
            {
                { 0, "" },
                { 1, "I" },
                {2,"II"},
                {3,"III"},
                {4,"IV"},
                {5,"V"},
                {6,"VI"},
                {7,"VII"},
                {8,"VIII"},
                {9,"IX"},
                {10,"X"}
            };
            return map;
        }
    }
}
