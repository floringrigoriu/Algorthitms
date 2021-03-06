﻿
namespace Problem1
{
    public class Problem_1 : IProblem<long>
    {
        public long Solve(long limit)
        {
            long result = 0;
            for (long i = 1; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result+=i;
                }
            }
            return result;
        }

        public string Description 
        {
            get {
                return @"If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.";
            }
        }
    }
}
