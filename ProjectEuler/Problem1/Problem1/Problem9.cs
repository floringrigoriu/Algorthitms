using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem_9 : IProblem<long>
    {
        public string Description
        {
            get
            {
                return @"A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a^2 + b^2 = c^2
For example, 32 + 42 = 9 + 16 = 25 = 52.
There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc";
            }
        }

        public long Solve(long limit)
        {
            // 1. find numbers
            // numbers ar edges of a triange so
            // c < a + b , c > a - b
            long c = limit / 2 ;
            long a = limit / 4;
            long b = limit - c -a;
            bool found = false;
            while (c > 0 && !found)
            {
                a = (limit - c) / 2; // bigger of the  catheti
                b = limit - c -a;
                if(a > c)
                {
                    break;// c - no longer biggest - so aglorithm completed;   
                }
                while (!found && c > a - b)
                {
                    if (c * c == a * a + b * b)
                    {
                        found = true;
                    }
                    else 
                    {
                        a++;
                        b--;
                    }
                }
                if (!found)
                {
                    c--;
                }
            }

            if (!found)
            {
                throw new Exception(String.Format("No Pythagorean triplets  sum to {0}",limit));
            }
            // 2. return product
            return a * b * c;
        }
    }
}
