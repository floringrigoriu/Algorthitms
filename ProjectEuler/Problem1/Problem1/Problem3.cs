using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem3 : IProblem<long>
    {
        
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
                current = PrimeUtils.NextPrime(current);
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
  }
}
