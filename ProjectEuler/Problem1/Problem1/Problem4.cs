using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem4 : IProblem<long>
    {
        public string Description
        {
            get
            {
                return "A palindromic number reads the same both ways. " +
                    "The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99."
                    + "Find the largest palindrome made from the product of two N-digit numbers";
            }
        }

        public long Solve(long limit)
        {
            if(limit <1 || limit >3){throw new ArgumentException("invalid N - supported only 1, 2 or 3");};
            long minHalf = (long)Math.Pow(10, limit-1);
            long maxHalf = (long)Math.Pow(10, limit)-1;
            long upperHalf = maxHalf;
            for( ;upperHalf >= minHalf;upperHalf--)
            {
                long result = GetPalindrome(upperHalf);
                for (long devider = (long)Math.Ceiling(Math.Sqrt(result)); 
                    devider <= maxHalf;
                    devider ++)
                {
                    if (result / devider < minHalf)
                    {
                        break; // to much 
                    }
                    if (result % devider == 0)
                    {
                        return result; // we just find our gratest
                    }
                }
            }
            throw new Exception("Result could not be found for n = " + limit);
        }

        private static long GetPalindrome( long upperHalf)
        {
            long result = upperHalf;
            while (upperHalf > 0)
            {
                result = result * 10 + upperHalf % 10;
                upperHalf /= 10;
            }
            return result;
        }
    }
}
