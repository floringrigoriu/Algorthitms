using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem12:IProblem<long>
    {
        public string Description
        {
            get
            {
                return @"We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?";
            }
        }

        public long Solve(long limit)
        {
            long triangleIndex = 1;
            while (true)
            {
                var triagleSize = triangleIndex * (triangleIndex + 1) / 2;
                IDictionary<long,long> primeDivizors = getPrimeDivisors(triagleSize);
                long totalDivisorsCount = primeDivizors.Aggregate(1L, (res, kvp) => res * (kvp.Value + 1L));
                if (totalDivisorsCount >= limit)
                {
                    return triagleSize;
                }
                triangleIndex++;
            }
        }

        private IDictionary<long, long> getPrimeDivisors(long triagleSize)
        {
            var result = new Dictionary<long, long>();

            foreach (var prime in PrimeUtils.GetPrimes())
            {
                if (triagleSize == 1 || triagleSize < (prime * prime))
                { break; }
                if (triagleSize % prime == 0)
                {
                    result[prime] = 0;
                    while (triagleSize % prime==0)
                    {
                        result[prime]++; 
                        triagleSize /= prime;
                    }
                }
            }
            // assuming we are not skipping any prime number the remaining of the 
            // triangleSize is the biggest prime factor
            if (triagleSize > 1)
            {
                result[triagleSize] = 1;
            }
            return result;
        }

     
    }
}
