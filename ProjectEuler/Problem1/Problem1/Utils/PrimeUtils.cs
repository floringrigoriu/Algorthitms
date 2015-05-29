using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Utils
{
    public static class PrimeUtils
    {
        private static IList<long> primes = new List<long>(); 
        private static long maxPrime = 1;

        public static long NextPrime(long current)
        {
            long? result = null;
            if (current < maxPrime)
            {
                result = primes.
                    SkipWhile(i => i <= current).
                    Take(1).
                    SingleOrDefault();
                if (default(long) != result)
                {
                    return result.Value;
                }
            }
            
            result = maxPrime + 1;
            for (; result < int.MaxValue; result++)
            {
                long maxDivisor = 2;
                var found = false;
                var upperLimit = Math.Sqrt(result.Value);
                foreach (var prime in primes)
                {
                    maxDivisor = prime;
                    if (result % prime == 0)
                    {
                        found = true;
                        break;
                    }
                    if (maxDivisor > upperLimit)
                    {
                        break;
                    }
                }
                if (!found)
                {
                    for (; !found && maxDivisor <= upperLimit; maxDivisor++)
                    {
                        found = (result % maxDivisor) == 0;
                    }
                    if (!found)
                    {
                        maxPrime = result.Value;
                        primes.Add(result.Value);
                        return result.Value;
                    }
                }
            }
            if (result == long.MaxValue)
            {
                throw new Exception("too big !");
            }
            else
            {
                throw new Exception("could not get here");
            }
            
        }

        public static IEnumerable<long> GetPrimes()
        {
            long last = 1;
            foreach (var i in primes)
            {
                last = i;
                yield return last;
            }
            while (true)
            {
                last = NextPrime(last);
                yield return last;
            }
        }


    }
}
