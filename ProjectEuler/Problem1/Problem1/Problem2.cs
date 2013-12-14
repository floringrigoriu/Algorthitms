using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem2:IProblem
    {
        public string Description
        {
            get { return "By considering the terms in the Fibonacci sequence whose values"+
                " do not exceed four million, find the sum of the even-valued terms."; }
        }

        public int Solve(int limit)
        {
            if(limit < 0)
            {
                throw new ArgumentException("negative limit not supported");
            }
            var result = 0;
            int last = 0;
            int current = 1;
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
