using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem_6 : IProblem<long>
    {
        public string Description
        {
            get
            {
                return "Find the difference between the sum of the squares of the first" +
                    " one hundred natural numbers and the square of the sum.";
            }
        }

        public long Solve(long limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("limit not positive");
            }

            var squareSum = ((limit + 1) * limit / 2);
            squareSum *= squareSum;
            var sumSquare = 0;
            for(var i = 1 ;i <=limit ;i++){sumSquare += i*i;}
            return squareSum - sumSquare;
        }
    }
}
