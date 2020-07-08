using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tdd.Katas.StringCalculatorLib
{
    public class StringCalculator
    {
        private int _calledCount = 0;
        public int Add(string numbers)
        {
            _calledCount++;
            var delimitersList = new List<Char>() { ',', '\n' };

        
            if (string.IsNullOrEmpty(numbers))
                return 0;
            if (numbers.StartsWith("//"))
            {
                // we have a different delimiter
                // //[delimiter]\n[numbers…]
                var delimiter = char.Parse(numbers.Split('\n').FirstOrDefault()?.Replace("//", ""));
                delimitersList.Add(delimiter);
                // reassign numbers, right after the first \n
                numbers = numbers.Substring(numbers.IndexOf('\n')+1);
            }
            var  nums = numbers.Split(delimitersList.ToArray()).Select(x => int.Parse(x));
            if (nums.Any(x=>x<0))
            {
                var s = string.Join(",", nums.Where(p => p<0)
                    .Select(p => p.ToString()));
                throw new Exception($"negatives not allowed {s}");
            }
          
            return nums.Sum();
        }

        public int GetCalledCount()
        {
            return _calledCount;
        }
    }
}
