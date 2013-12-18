using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem7:IProblem
    {
        public string Description
        {
            get
            {
                return "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13." +
                    "What is the 10 001st prime number?";
            }
        }

        public long Solve(long limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("limit not positive");
            }
            var result = PrimeUtils.GetPrimes().
                Skip((int)limit-1).
                Take(1).
                Single();

            return result;
        }
    }
}
