using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;

namespace Tdd.Katas.StringCalculatorLib
{
    public class StringCalculator
    {

        public event Action<string, int> AddOccurred;

        private int _calledCount = 0;

        // Declare the delegate (if using non-generic pattern).
        //public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        // Declare the event.
        //public event EventHandler AddOccurred;

        public int Add(string numbers)
        {
            var originalNumbers = numbers;
            _calledCount++;
            var delimitersList = new List<string>() { ",", "\n" };


            if (string.IsNullOrEmpty(numbers))
            {
                AddOccurred?.Invoke(numbers, 0);
                return 0;
            }
              
            if (numbers.StartsWith("//"))
            {
                // check if is single or multiple delimiter
                var delimiter = numbers.Split('\n').FirstOrDefault()?.Replace("//", "");
                if (delimiter.Contains("[") && delimiter.Contains("]"))
                {
                    var tmp1=  delimiter.Replace("[", "").Replace("]", ",");
                    delimitersList.AddRange(tmp1.Split(",").Select(x=>x));
                }
                else
                {
                    // we have a different delimiter
                    // //[delimiter]\n[numbers…]
                    delimitersList.Add(delimiter);
                }
                // reassign numbers, right after the first \n
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }
            var  nums = numbers.Split(delimitersList.ToArray(), StringSplitOptions.None).Select(x => int.Parse(x));
            if (nums.Any(x=>x<0))
            {
                var s = string.Join(",", nums.Where(p => p<0)
                    .Select(p => p.ToString()));
                throw new Exception($"negatives not allowed {s}");
            }
            var sum = nums.Where(x=>x<=1000).Sum();
            AddOccurred?.Invoke(originalNumbers, sum);

            return sum;
        }

        public int GetCalledCount()
        {
            return _calledCount;
        }

       
    }
}
