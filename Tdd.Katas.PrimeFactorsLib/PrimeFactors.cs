using System;
using System.Collections.Generic;

namespace Tdd.Katas.PrimeFactorsLib
{
    public class PrimeFactors
    {
        public static List<int> Generate(int n)
        {
            List<int> primes=new List<int>();
            if (n==1)
            {
                return new List<int>(){1};
            }
            int candidate = 2;
            while (n > 1)
            {
                while (n % candidate == 0)
                {
                    primes.Add(candidate);
                    n /= candidate;
                }
                candidate++;
            }
            return primes;
        }
    }
}
