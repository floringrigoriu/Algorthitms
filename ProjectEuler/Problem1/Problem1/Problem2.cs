using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem_2 : IProblem<long>
    {
        public string Description
        {
            get { return "By considering the terms in the Fibonacci sequence whose values"+
                " do not exceed four million, find the sum of the even-valued terms."; }
        }

        public long Solve(long limit)
        {
            if(limit < 0)
            {
                throw new ArgumentException("negative limit not supported");
            }
            long result = 0;
            long last = 0;
            long current = 1;
            while (last < limit)
            {
                if (last % 2 == 0) { result += last; };
                var next = current + last;
                last = current;
                current = next;
            }
            return result;
        }
    }
}
