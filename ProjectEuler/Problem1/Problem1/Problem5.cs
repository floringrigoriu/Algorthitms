using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem_5 : IProblem<long>
    {
        public string Description
        {
            get
            { return
                @"2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";
            }
        }

        public long Solve(long limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("limit not positive");
            }
            // get prime members
            var primes = PrimeUtils.GetPrimes().TakeWhile(p => p < limit).ToDictionary(key=>key, val=>0L);
            
            // get exponents  to compute minimum common multiple
            for (long index = 1; index <= limit; index++)
            {
                var remainder = index;
                var primeIndex = 0;
                var primeExpenonent = 0L;
               
                while (remainder > 1 && primeIndex < primes.Count())
                {
                    if (remainder % primes.ElementAt(primeIndex).Key == 0)
                    {
                        primeExpenonent++;
                        remainder /= primes.ElementAt(primeIndex).Key;
                        primes[primes.ElementAt(primeIndex).Key] = Math.Max(primes[primes.ElementAt(primeIndex).Key], primeExpenonent);
                    }
                    else 
                    {
                        primeExpenonent = 0;
                        primeIndex++;
                    }
                }
            }
            // compute minimum common multiple 

            var result = primes.Aggregate(1L, 
                (seed, kvp) => seed * (long)(Math.Pow(kvp.Key, kvp.Value)));

            return result;
        }
    }
}
