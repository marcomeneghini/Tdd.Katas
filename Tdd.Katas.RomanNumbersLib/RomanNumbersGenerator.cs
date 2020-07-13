using System;
using System.Collections.Generic;

namespace Tdd.Katas.RomanNumbersLib
{
    public class RomanNumbersGenerator
    {
        public static string Generate(int number)
        {
            var map = InitializeMap();
            return map[number];
        }
    
        private static Dictionary<int, string> InitializeMap()
        {
            var map = new Dictionary<int, string>
            {
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
