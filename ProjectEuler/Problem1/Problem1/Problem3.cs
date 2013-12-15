using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem3:IProblem
    {
        IList<long> primes = new List<long>(); 

        public string Description
        {
            get { return "What is the largest prime factor of the number"; }
        }

        public long Solve(long limit)
        {
            long current = 1;
            long result = 1;
            while (current < limit)
            {
                current = nextPrime(current);
                // new max
                if (limit % current == 0)
                {
                    result = current;
                }
                // exponential divisors
                while (limit % current == 0)
                {
                    limit = limit / current;
                }

            }
            return result;
        }

        private long nextPrime(long current)
        {
            var result = primes.
                SkipWhile(i => i <= current).
                Take(1).
                SingleOrDefault();
            if (default(long) != result)
            {
                return result;
            }
            else 
            {
                result = current+1;
                for(;result<int.MaxValue;result++)
                {
                    long maxDivisor = 2;
                    var found = false;
                    foreach (var prime in this.primes)
                    {
                        maxDivisor = prime;
                        if (result % prime == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        for (;!found && maxDivisor <= Math.Sqrt(result);maxDivisor++ )
                        {
                            found = (result % maxDivisor) == 0;
                        }
                        if (!found)
                        {
                            this.primes.Add(result);
                            return result;
                        }
                    }
                }
                if (result == int.MaxValue)
                {
                    throw new Exception("too big !");
                }
                else
                {
                    throw new Exception("could not get here");
                }
            }
        }
    }
}
